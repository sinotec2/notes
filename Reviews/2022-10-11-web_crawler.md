---
title: 批次下載作業技術與實務
tags: python crawler
layout: article
aside:
  toc: true
sidebar:
  nav: layouts
date:  2022-10-11
modify_date: 2022-10-11 09:39:01
---
## 背景
### 基本說明
- [網路爬蟲][crawler]是一類越來越普及的資訊技術，此處使用此一名詞稱呼批次下載作業技術，僅為[網路爬蟲][crawler]部分功能，此處不涉及無特定目標的[索引作業](https://en.wikipedia.org/wiki/Search_engine_indexing)。
- 下載或上傳
  - 包括定期或不定期，前者是運用電腦的排程控制、定期執行特定程式上網進行驗證、搜尋、畫面截取、下載等，「合理流量」的作業。後者雖為手動批次進行，也可能因無約束而造成網路攻擊事件。
  - 至於上網填報、上傳檔案等上載作業，除非對方網站允許，一般是不接受機器人作業方式的。無目標、通用性目標之爬蟲行為，此處並不加以討論。
- 此處之作業對象包括：
  1. 官方網頁提供之公開數據、文件、圖片、或文字
  1. 官方或商務網頁提供之畫面、影片
- 下載頻度與流量之控制
  - 雖然大多數具有管理的網站，都會設定訪問頻率與下載流量的門檻，對不同需要的使用者提供不同程度的應對與資源分配，但下載者還是需要合理管理自己的程式與設定，避免造成遠端網站的拒絕或傷害。
  - 除此之外，因下載數據量很龐大，也需在本地儲存、處理、品管、應用等等，有良好的管理。
- 由於是專案性質的應用，因此詳盡的技術細節、設定說明、與應用實證，見諸專案筆記，此處僅就一般或共同部分加以彙總。
  1. 網站特性之解析與應對策略
  1. 電腦排程之設定
  1. 下載工具與程式
  1. 後續應用及發展

### 定期爬蟲專案簡介
- 自2016年以來陸續建置自動數據下載的專案條列如下。
- 氣象數據方面
  - 觀測與再分析數據
    1. 中央氣象局(CWB)每天公開其自動站觀測結果在[CODiS(CWB Observation Data Inquire System)網站](https://e-service.cwb.gov.tw/HistoryDataQuery/)，此處每日12時執行全國昨日監測結果的下載，詳[CODiS筆記](https://sinotec2.github.io/Focus-on-Air-Quality/wind_models/CODiS/)。
    1. 美國[NCEP數據之每日下載](https://sinotec2.github.io/Focus-on-Air-Quality/wind_models/NCEP/)：為氣象模式起始與邊界、同化等等所需要之觀測(或再分析)數據檔案，包括[再分析結果](https://sinotec2.github.io/Focus-on-Air-Quality/wind_models/NCEP/ff.py/)、[地面](https://sinotec2.github.io/Focus-on-Air-Quality/wind_models/NCEP/ss.py/)及[高空](https://sinotec2.github.io/Focus-on-Air-Quality/wind_models/NCEP/uu.py/)觀測、以及[海溫](https://sinotec2.github.io/Focus-on-Air-Quality/wind_models/SST/)。
  - 氣象模式產品
    1. 中央氣象局數[值預報產品之下載](https://sinotec2.github.io/Focus-on-Air-Quality/wind_models/cwbWRF_3Km/get_M-A0064/)：每日逐6小時下載，應用在[軌跡模式預報](https://sinotec2.github.io/cpuff_forecast/)、[網格空品模式預報][fcst]等等即時性的需求、同時也因應[MMIF](https://sinotec2.github.io/Focus-on-Air-Quality/PlumeModels/ME_pathways/mmif_caas/)、[歷史軌跡分析](https://sinotec2.github.io/Focus-on-Air-Quality/TrajModels/traj3D/)等等年度分析。  
    1. 美國國家氣象局(NWS)全球尺度氣象數值預報模式和變分分析([GFS](https://en.wikipedia.org/wiki/Global_Forecast_System))逐日預報檔案之[自動下載](https://sinotec2.github.io/FAQ/2022/08/10/GFStoWRF.html)：用在驅動每日的東亞、南中國等地區氣象場的模式模擬，用以進行[網格空品模式預報][fcst]
  - 天氣報告與天氣圖
    1. 中央氣象局逐6小時天氣預報(文字稿)及天氣圖
    1. 逐6小時NOAA天氣圖下載：[6-Hourly NCEP/NCAR Reanalysis Data Composite]()，提供東亞範圍之天氣圖。
- 空氣品質部分
  - 環保署空品監測數據下載
    1. 逐時aqi數據之下載
    1. 逐月全台空品測站數據之下載
  - 特殊性工業區空品監測數據下載
  - [CAMS預報數據](https://sinotec2.github.io/FAQ/2022/08/03/wind_ozone.html)
  - [日本大氣污染情報網站圖面之下載](https://sinotec2.github.io/Focus-on-Air-Quality/AQana/RegAQ/pm25.jp/)
- 排放活動部分
  - CEMS
  - 電廠運轉率
  - 交通量

### 批次爬蟲專案
- 全球空品模擬數據
  - [CAMS近實時空品數據之下載](https://sinotec2.github.io/Focus-on-Air-Quality/AQana/GAQuality/ECMWF/NRTdownload/)
  - [CAM-chem模擬結果之下載](https://sinotec2.github.io/Focus-on-Air-Quality/AQana/GAQuality/NCAR_ACOM/CAM-chem/)
  - [MOZART(WACCM)](https://sinotec2.github.io/Focus-on-Air-Quality/AQana/GAQuality/NCAR_ACOM/MOZART/)
- 空品畫面之截取
  - earth.nullschool.net
  - Windy網頁畫面
  - airvisual
- 癌症數據之下載
- 同仁發表文獻資料庫之建立

## 網站特性之解析與應對策略
- 
- 網站存放數據的型式不一而足，因此應對下載的方式也有很多種。截至目前的型式與因應方式列表如下

數據型態|範例|因應方式|說明
:-:|:-:|:-:|:-:
已知url目錄(規則)的特定檔案|CWBWRF、NCEP、CODiS、GFS|wget、curl|目錄、檔名規則可以在批次檔中、或在python檔中進行迴圈設定，再呼叫外部程式wget/curl
切割某龐大檔案進行後傳送|CAMS|特定API、|




## 電腦排程之設定
- 雖然window也可以設定自動運作之排程([工作排程器](https://ithelp.ithome.com.tw/articles/10276390))，但此處無法啟用，還是以工作站的[crontab][crontab]為主，原因：
  1. 個人電腦之電源為中央統一管控，切斷電源或使用者自己關機，程序就不能自動運作。
  1. 個人電腦雖有2~4個核心，背景執行仍會消耗計算資源，不適合(不可能)下載後接續執行模式這類完整的批次作業。  
  1. 設定及程式儲存在個人空間，不便於團隊協作。
  1. 設定界面太過複雜
- 這項選擇也意味者需有工作站使用者的身份及權限，來執行自動下載及後續應用的所有作業(工作站的使用詳見[linux快速入門](https://sinotec2.github.io/Focus-on-Air-Quality/utilities/OperationSystem/entry_linux/))。

### [crontab][crontab]的特性與強項
- 以單行文字檔即可完成複雜的設定，簡明易懂、容易檢查(`crontab -l`與/或文字檔`cat /etc/crontab`)，不會發生無法預期的結果。
- 背景執行、同步多工執行。即使在上班時間也不會干擾任何使用者。
- 執行結果如果沒有設計成引導到特定的檔案，程式也會將執行訊息傳送到使用者的電子郵件信箱，以瞭解執行情況。
- 需注意的是：
  1. [crontab][crontab]完全是系統自動執行，除了時間外，這個層級再沒有別的觸發機制，因此如果以root身份執行將有最高的權限，也會非常危險，須小心設定。
  1. 最高頻率可以設定到以分鐘為單位，沒有秒的頻率。如果需要到秒，可以在每分鐘執行的批次檔中，以迴圈及`sleep N`指令來控制系統停置的秒數。
  1. 沒有跨年之頻率、也沒有「N日」的周期，而是某月、某日，或是星期等日曆日架構。如果要設定Julian Day(如每2日、每7日執行)、或某幾年，需以每日執行方式，另在執行程式內以`date`指令判別是否符合日期或年度頻率要求。
  1. [crontab][crontab]雖會認得家目錄(~)，但不會自行啟動家目錄所隱含的設定，如執行檔路徑、或其他登入OS時自動執行的環境設定。必須自行一一設定。


### 運作中電腦排程之彙總
此處彙總目前運作中的下載排程。按照使用者名稱區分：
- root

```
$ cat /etc/crontab
SHELL=/bin/bash
PATH=/sbin:/bin:/usr/sbin:/usr/bin
MAILTO=root
HOME=/

# For details see man 4 crontabs

# Example of job definition:
# .---------------- minute (0 - 59)
# |  .------------- hour (0 - 23)
# |  |  .---------- day of month (1 - 31)
# |  |  |  .------- month (1 - 12) OR jan,feb,mar,apr ...
# |  |  |  |  .---- day of week (0 - 6) (Sunday=0 or 7) OR sun,mon,tue,wed,thu,fri,sat
# |  |  |  |  |
# *  *  *  *  * user-name command to be executed
# every day
  0  8  *  *  * kuang /home/backup/data/pm25.jp_yosoku_parts_casu/pm25.cs
  0  8  *  *  * kuang /home/backup/data/www.jma.go.jp/jma_cron.cs
  0  8  *  *  * kuang /home/backup/data/taqm.epa.gov.tw/dust/taqm.dust_cron.cs
  0 12  *  *  * kuang /home/backup/data/cwb/e-service/get_cwb.sh >& /home/backup/data/cwb/e-service/get_cwb.out
#every 5 min ($min%5==0)
#  *  *  *  *  * kuang /home/backup/data/ETC/DirectoreGeneralOfHighways/getTHBvd.cs
#every 5 min ($min%5==0)
   *  *  *  *  * kuang /home/backup/data/ETC/JiaYiVD/getJiayiVD_cron.cs
#   *  *  *  *  * kuang /home/backup/data/ETC/KaoxiongVD/KaoxiongGetVD_cron.cs
#every 5 min ($min%5==0)
   *  *  *  *  * kuang /home/backup/data/ETC/NewtaipeiVD/NewtpGetVD_cron.cs
  0  *  *  *  * kuang /home/backup/data/ETC/TaichungVD/getTaichongVD_cron.cs
   *  *  *  *  * kuang /home/backup/data/ETC/TainanVD/TainanGetVD_cron.cs
#every 5 min ($min%5==0)
   *  *  *  *  * kuang /home/backup/data/ETC/TaipeiVD/TaipeiGetVD_cron.cs
#every 5 min ($min%5==0)
#   *  *  *  *  * kuang /home/backup/data/ETC/TaoyuanVD/TaoyuanGetVD.cs

# every day from NCEP
0   0  *  *  * kuang /home/backup/data/NOAA/NCEP/fusv2.cs
0  12  *  *  * kuang /home/backup/data/NOAA/NCEP/SST/get_noaa.cs
```
- kuang：在calpuff模式每日自動執行程序中，下載CWB WRF數值預報之結果檔案

```
  0  0  *  *  *  /home/cpuff/UNRESPForecastingSystem/Run.sh -c > /home/cpuff/UNRESPForecastingSystem/Run.out
```
- sespub

```
0 0,6,12,18 * * * /home/sespub/cwb/cwb.cs &>/dev/null 2>&1
2 6 * * * /home/sespub/epa2/epa.cs &>/dev/null 2>&1
10,40 * * * * /home/sespub/aqi/aqi.cs &>/dev/null 2>&1
22 6 * * * /home/sespub/aqi/aqifix.cs &>/dev/null 2>&1
23 * * * * /home/sespub/power/pw.cs &>/dev/null 2>&1
25 5,20 * * * /home/sespub/airbox/box.cs &>/dev/null 2>&1
30 * * * * /home/sespub/aqi/linux_ftp_saq.cs &>/dev/null 2>&1
```

## 下載工具與程式
- 有關wget、curl2個指令的用法與比較，可以參考[這篇][w_c]。基本上wget是比較簡單的指令，如果wget不穩定、或需要傳遞特殊指令，curl會比較彈性一些。

## 後續應用及發展

[crawler]: <http://200.200.12.191/?c=SinoTech&m=load_one&r=hour&s=by%20name&hc=4&mc=2> "網路爬蟲（英語：web crawler），也叫網路蜘蛛（spider），是一種用來自動瀏覽全球資訊網的網路機器人。其目的一般為編纂網路索引。"
[fcst]: <http://125.229.149.182:8084/> "運用GFS/CWB/CAMS數值預報數進行台灣地區CMAQ模擬實例"
[crontab]: <https://blog.gtwang.org/linux/linux-crontab-cron-job-tutorial-and-examples/> "G. T. Wang, Linux 設定 crontab 例行性工作排程教學與範例,G. T. Wang, 2019/06/28"
[w_c]: <https://www.zhihu.com/question/19598302> "知乎：cURL 和 Wget 的优缺点各是什么？"