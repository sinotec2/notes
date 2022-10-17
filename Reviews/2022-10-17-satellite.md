---
title: 衛星遙測數據在水質監測之應用
tags: 
layout: article
aside:
  toc: true
sidebar:
  nav: layouts
date:  2022-10-17
modify_date: 2022-10-17 14:03:32
---

## News
- [2022/07/05 衛星幫你巡田水！日衛星服務商「天地人」今起開放查詢][inside]
  - 日本衛星資訊新創公司「天地人」，今（ 5 日）宣布將無償開放全日本的地形、地質、土壤、植被等資料。衛星圖上日本以外的所有地區，則可以免費取得 2021 年起的氣溫雨量推移資料。最大可同時顯示 3 處資訊。
  - [https://compass.tenchijin.co.jp/map](https://compass.tenchijin.co.jp/map) with UN(email) and PWD
  - leaflet, mapbox, OpenStreetMap, and Mapbox
- [衛星追蹤珊迪後污染趨勢][inside2021]
  - 劇烈的暴風混攪了許多污染物、廢棄物，產生汙水、沉積物，這個問題影響深遠，卻鮮少被注意到。
  - 「人們容易注意到珊迪颶風短暫的作用，像是橫掃我們居住環境的暴雨、暴風、巨浪以及暴風雪，但事實上超級颶風的影響力遠比我們的想像長久，包括颶風過後的沉積物和流入排水道的污染物。」美國地質調查局局長瑪西亞說明。
- [多時相衛星遙測技術]()
## Thesis and student's Competetion
- [應用不同尺度衛星影像於監測台灣內陸水體水質之研究][wange2010]
  - 水質遙測技術（Water Quality Remote Sensing Technology）是利用衛星影像能大範圍地反映出水庫區域之時空變化，有無需到達現地勘查與節省成本之優點，可成為一個快速且大面積的監測水體方法。然而各衛星有不同之功能特性，且所提供之影像亦有不同之尺度（Scale），即空間解析度（Spatial Resolution）與再訪率（Revisit Rate），即時間解析度（Temporal Resolution）之差異。
    - 不同尺度衛星影像：Formosat-2、SPOT-4、Landsat-7、Terra等衛星所分別提供8 m、20 m、30 m與250 m等之尺度影像，
    - 以葉綠素-a（Chlorophyll-a, Chl-a）、總磷（Total Phosphorus, TP）、懸浮固體（Suspended Sediment, SS）、濁度（Turbidity, TB）與透明度（Secchi Disk Depth, SDD）等水質參數為研究對象，
    - 並使用多元線性迴歸（Multiple Linear Regression, MLR）、類神經網路（Artificial Neural Network, ANN）與遺傳運算樹（Genetic Algorithm of Operation Tree, GAOT）等方法，分別建立各尺度影像之光譜波段（紅光波段與近紅外光短波段）與現地水質之預測模式。
  - 論文第二部份為提高對內陸水體之觀測頻率，使用遺傳運算樹建構不同水質參數於各尺度影像下，有高相關性之最佳組合波段型式，再以此型式亦利用遺傳運算樹建立不同兩尺度影像間之數據同化模式（Data Assimilation Model）。經研究案例顯示，各水質參數於尺度250 m與20 m之影像間進行數據同化作用，其濃度變化能成功地呈現於新尺度20 m之影像上。
  - [退役的福爾摩沙衛星二號 帶我們看見大自然的變遷過程](https://scitechvista.nat.gov.tw/Article/C000003/detail?ID=3c5202a7-3f23-400d-8ae9-d7f1d64aa3b8)
    - 王泰盛(財團法人農業工程研究中心)、劉說安(中央大學太空及遙測研究中心)、何淑霓(中央大學太空及遙測研究中心)
    105/11/23科技大觀園,Sci-Tech-Vista, NSTC
  - [陳莉、魏曉萍、王泰盛，2004，監督式分類法於遙測影像判釋之研究，農業工程學報第50卷第3期。][chen2004]
  - [應用預警模式推估藻華發生之可行性研究 王泰盛 王泰盛、劉說安]
- [利用人工智慧分析高屏溪海洋藻華現象的可能影響][yang2022]  

## Jurnals
- [結合衛星影像與模糊理論於水庫水質優養判釋與管理][YangDM2008]
  - 點狀採樣成果可能不足代表全水域優養程度，且既有卡爾森優養指標對各優養程度的數值無法全然詮釋氣候變化或人為觀點改變時水質潛在的優劣。
  - 本研究以翡翠水庫為研究區域，
    - 利用2004年二月SPOT4衛星影像萃取之水體影像，推求與葉綠素a、總磷及透明度等水質相關參數，以建立衛星影像轉換水質參數回歸模式，達成全水域優養評估；
    - 並引入模糊理論方法於傳統卡爾森指標，考慮使用者注重水質安全與管理者注重管理成本的立場設計對應的隸屬函數，以模糊綜合評價討論兩者對同一優養評等下的差異認定。
- [應用衛星影像監測石門水庫集水區水體濁度][chen2018]
  - 面對極端氣候，臺灣各地河川與蓄水設施的水質變動迅速，需要一套完善的水質監測模式供管理單位參考，然而目前現地監測站多為固定點，不足以代表整個流域。
  - 本研究使用水文模式(Soil and Water Assessment Tool, SWAT)與光學衛星影像(SPOT與Landsat系列)，首先探討石門水庫集水區上游與庫區內的水體濁度監測效率，使用衛星影像建立石門水庫集水區水質預測模型，並進行校準與驗證。而後使用SWAT模式進行篩選，找出濁度上升事件，再使用衛星影像之預測模型估算水體濁度，並與實測資料比對，討論其準確度與濁度上升之問題。
  - 根據結果衛星影像應用於預估石門水庫水面濁度可行度較高，平均相對誤差約30%。水庫庫區的水體預測比預測河道水面更為準確，主因是水庫庫區內面積範圍大，衛星光譜不易受到周圍沙洲或植被所影響。上游集水區則受限於水深，若在乾旱時期進行監測，容易因水位高度不足1公尺而產生誤差，導致獲得之反射率過高，易誤判水質呈現混濁狀態。  

## online resource
- [臺北市, 臺北市, 臺灣水蒸氣衛星天氣圖 | AccuWeather
](https://www.accuweather.com/zh/tw/taipei-city/315078/satellite-wv/315078)

[inside]: <https://www.inside.com.tw/article/28187-jaxa-tenchijin-bigdata> "土地・氣象資訊 - INSIDE：衛星幫你巡田水！日衛星服務商「天地人」今起開放查詢"
[wange2010]: <https://ndltd.ncl.edu.tw/cgi-bin/gs32/gsweb.cgi/login?o=dnclcdr&s=id=%22098CHPI5015038%22.&searchmode=basic> "王泰盛 (2010). 應用不同尺度衛星影像於監測台灣內陸水體水質之研究 土木與工程資訊學系(所). 中華大學, 新竹市."
[chen2004]: <https://tpl.ncl.edu.tw/NclService/JournalContentDetail?SysId=A04026775> "選擇水利會之竹東工作站為研究區域，主要以最大概似法(maximum-likelihood)和人工智慧領域之倒傳遞類神經網路(back-propagation neural network)進行影像分類，其訓練程序由地面調查可能之耕作面積和影像分類所判釋之面積兩者互相比較。本研究利用之監督分類方法具有高度之準確性，此外，這兩種方法可根據影像分類和生長及收成之圖像協助我們計算每一農作物所需之水量。"
[yang2022]: <https://sciexplore.colife.org.tw/uploadfiles/TM21831f1622/TM21831f1622.pdf> "2022全國科學探究競賽-這樣教我就懂，利用人工智慧分析高屏溪海洋藻華現象的可能影響，新竹縣國立竹東高級中學楊頤樺同學邱姿函同學葉鈞喬 老師"
[YangDM2008]: <https://www.airitilibrary.com/Publication/alDetailedMesh?docid=10155856-200806-20-2-205-215-a> "德楊明, 昌林佑, 鈺蔡婷, and 芬楊曄 (2008). 結合衛星影像與模糊理論於水庫水質優養判釋與管理. 中國土木水利工程學刊 20 (2):205–215. doi:10.6652/JoCICHE.200806_20(2).0005."
[inside2021]: <https://scitechvista.nat.gov.tw/Article/C000003/detail?ID=5eeca7f6-7077-460e-beb7-2d71a58b23d9> "陳慈忻(2011)衛星追蹤珊迪後污染趨勢"
[chen2018]: <http://twc.bse.ntu.edu.tw/upload/ckfinder/files/66-1-13-25.pdf> "陳永彧, 吳瑞賢, 曾國欣, and 彭新雅 (2018). 應用衛星影像監測石門水庫集水區水體濁度. 臺灣水利 第 66 卷 (第 1 期):13–25."