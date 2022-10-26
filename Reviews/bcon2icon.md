---
title: BCON東西南北4面2維濃度檔之轉接程式
tags: BCON ICON
layout: article
aside:
  toc: true
sidebar:
  nav: layouts
date:  2022-10-26
modify_date: 2022-10-26 20:20:32
---

## 背景
- BCON檔案並沒有專用的顯示軟體，主要的困難：
  1. 垂直方向的範圍與水平範圍不成比例，網格解析度也差異很大。
  1. 垂直網格的數目遠遠不如水平方向，即使以網格為單位，也無法均衡展示。
  1. 就檔案的格式而言，BCON的[全域屬性FTYPE](https://sinotec2.github.io/Focus-on-Air-Quality/AQana/GAQuality/ECMWF_rean/grb2bc/#bcon模版之準備)=2,ICON則為1，需另存新檔。
- CAMx時代曾以某個單位高度(50m)作為單一垂直間距，重新將非等間距的垂直向轉成等間距系統
  - 最後結果再以SURFER軟體一併放大垂直高度，以與水平網格匹配
- [VERDI](https://sinotec2.github.io/Focus-on-Air-Quality/utilities/Graphics/VERDI)並沒有某一維度放大的功能。需以外部程式先予以處理。

## ICON模版之製作
- CWBWRF_45K範圍的水平網格約有200。垂直網格僅24，因此需予以增加。
- x方向設定(`$NCOLS`)
  - 南面及北面邊界：原東西向(`nc.NCOLS`)
  - 東面及西面邊界：原南北向(`nc.NROWS`)
- y方向設定為原垂直網格數的3倍
  `nc.NLAYS=1;nc.NROWS=72`
- ncks指令
  - `nc=../icon/ICON_today_CWBWRF_45k`
  - `ncks -O -d LAY,0 -d ROW,0,71 -d COL,1,$NCOLS $nc $tname`
- 檔名規則
  - `tpl={0:'SN',1:'WE',2:'SN',3:'WE'}`
  - `path='/nas1/cmaqruns/2022fcst/data/bcon'`
  - `tname=path+'/template'+tpl[i]+'_CWBWRF_45k.nc'`

## 程式設計
### BCON水平網格順序之轉換
- `nbnd=(nc.NROWS+nc.NCOLS)*2+4`
- 方向(`ibnd`角`drn`)
  1. 南側邊界：左下角(西南) -》右下(東南)，指標起訖：`(1,nc.NCOLS+1)`
  1. 西側邊界：右下角(東南)  -》右上(東北)，指標起訖：`(nc.NCOLS+2,nc.NCOLS+nc.NROWS+2)`
  1. 北側邊界：左上角(西北)  -》右上(東北)，指標起訖：`(nc.NCOLS*2+nc.NROWS+2,nc.NCOLS+nc.NROWS+2)`方向相反。
  1. 西側邊界：左下角(西南) -》左上角(西北)，指標起訖：`(nc.NCOLS*2+nc.NROWS*2+3,nc.NCOLS*2+nc.NROWS+3)`方向相反。
    - np.array的起訖無法表示0以下的指標。-1不是0以下，而是最末項，無法反轉，因此無法用作等式的左邊。
    - 只能在等式右邊使其翻轉順序(`[ibnd[i][0]:ibnd[i][1]:drn[i]]`)
- 等式右邊、BCON檔案指標

```python
drn={0:1,1:1,2:-1,3:-1}
ibnd={	0:(1,nc.NCOLS+1),
	1:(nc.NCOLS+2,nc.NCOLS+nc.NROWS+2),
	2:(nc.NCOLS*2+nc.NROWS+2,nc.NCOLS+nc.NROWS+2),
	3:(nc.NCOLS*2+nc.NROWS*2+3,nc.NCOLS*2+nc.NROWS+3)}
```
- 等式左邊、ICON檔案之指標

```python
i1s={0:0,1:0,2:0,3:0}
i2s={0:nc.NCOLS,1:nc.NROWS,2:nc.NCOLS,3:nc.NROWS}
```
- 新舊矩陣之對照

```python
nc1[v][:,0,1::3,i1s[i]:i2s[i]]=nc[v][:,:,ibnd[i][0]:ibnd[i][1]:drn[i]]
```

### 垂直方向的轉換
- 24層轉72層。
  - 72層每3格的中間、對照到24層。
  - 新檔案的y軸`[1::3]`對照到既有BCON檔案z軸`[:]`
- 中間以外的2層：線性加權漸變

```python
    nc1[v][:,0,0,:] =nc1[v][:,0,1,:]
    nc1[v][:,0,-1,:]=nc1[v][:,0,-2,:]
    nc1[v][:,0,2:-1:3,:]=(nc1[v][:,0,1:-2:3,:]*2+nc1[v][:,0,4::3,:]  )/3
    nc1[v][:,0,3:-1:3,:]=(nc1[v][:,0,1:-2:3,:]  +nc1[v][:,0,4::3,:]*2)/3
```

## 程式碼下載

{% include download.html content="BCON檔案4面2維濃度檔之轉接程式[bcon2icon.py][bcon2icon]" %}

[bcon2icon]: <https://github.com/sinotec2/Focus-on-Air-Quality/blob/main/GridModels/BCON/bcon2icon.py> "BCON檔案4面2維濃度檔之轉接程式"