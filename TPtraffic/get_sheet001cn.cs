rm sheet*.*
ints=%E8%B7%AF%E5%8F%A3
url=( \
http://163.29.251.188/botedata/交通流量/九十一年度/HTML/調查站一覽表.htm \
http://163.29.251.188/botedata/交通流量/九十二年度/調查站一覽表.htm \
http://163.29.251.188/botedata/交通流量/九十三年度/調查站總表.htm \
http://163.29.251.188/botedata/交通流量/九十四年度/HTML/94調查成果目錄.htm \
http://163.29.251.188/botedata/交通流量/九十五年度/HTML/95%E8%AA%BF%E6%9F%A5%E6%88%90%E6%9E%9C%E7%9B%AE%E9%8C%84_HTML.files/sheet001.htm \
http://163.29.251.188/botedata/交通流量/九十六年度/HTML/96年度%E5%8F%B0%E5%8C%97%E5%B8%82%E4%BA%A4%E9%80%9A%E7%89%B9%E6%80%A7%E8%AA%BF%E6%9F%A5.files/sheet001.htm \
http://163.29.251.188/botedata/交通流量/九十七年度/HTML/97年度%E5%8F%B0%E5%8C%97%E5%B8%82交通流量%E5%8F%8A%E7%89%B9%E6%80%A7%E8%AA%BF%E6%9F%A5.files/sheet001.htm \
http://163.29.251.188/botedata/交通流量/九十八年度/HTML/98年度%E5%8F%B0%E5%8C%97%E5%B8%82交通流量%E5%8F%8A%E7%89%B9%E6%80%A7%E8%AA%BF%E6%9F%A5.files/sheet001.htm \
http://163.29.251.188/botedata/交通流量/九十九年度/HTML/99年度%E5%8F%B0%E5%8C%97%E5%B8%82交通流量%E5%8F%8A%E7%89%B9%E6%80%A7%E8%AA%BF%E6%9F%A5.files/sheet001.htm \
http://163.29.251.188/botedata/交通流量/100年度/html/100年度%E8%87%BA%E5%8C%97%E5%B8%82交通流量%E5%8F%8A%E7%89%B9%E6%80%A7%E8%AA%BF%E6%9F%A5.files/sheet001.htm \
http://163.29.251.188/botedata/交通流量/101年度/html/101年度%E8%87%BA%E5%8C%97%E5%B8%82交通流量%E5%8F%8A%E7%89%B9%E6%80%A7%E8%AA%BF%E6%9F%A5.files/sheet001.htm \
http://163.29.251.188/botedata/交通流量/102年度/pdf/102年度%E8%87%BA%E5%8C%97%E5%B8%82交通流量%E5%8F%8A%E7%89%B9%E6%80%A7%E8%AA%BF%E6%9F%A5.files/sheet001.htm \
http://163.29.251.188/botedata/交通流量/103年度/103年度%E8%87%BA%E5%8C%97%E5%B8%82交通流量%E5%8F%8A%E7%89%B9%E6%80%A7%E8%AA%BF%E6%9F%A5.files/sheet001.htm \
http://163.29.251.188/botedata/交通流量/104年度/104年度%E8%87%BA%E5%8C%97%E5%B8%82交通流量%E5%8F%8A%E7%89%B9%E6%80%A7%E8%AA%BF%E6%9F%A5.files/sheet001.htm \
http://163.29.251.188/botedata/交通流量/105年度/105年度%E8%87%BA%E5%8C%97%E5%B8%82交通流量%E5%8F%8A%E7%89%B9%E6%80%A7%E8%AA%BF%E6%9F%A5.files/sheet001.htm \
)
for m in {12..13};do
n=$(( m - 1 ))
wget ${url[n]} 
python rd_sht1.py
mv sheet001.htm sht1_$m.htm

for i in $(cat inter_nam.txt);do
strA=${url[n]}
strB=`echo ${strA%/*}`
strC=`echo ${strB%/*}`

if [[ $m -eq 12 ||  $m -eq 13  ]] ;then
sht=$i".pdf"
htp=$strC'/'$ints'/'$sht
wget $htp
mv $sht sht3_$m"_$i".pdf
FILE=$sht
if [ -f $FILE ]; then rm $FILE;fi

else

for j in {1..5};do
sht=sheet00$j".htm"
htp=$strC'/'$ints'/'$i'.files/'$sht
wget $htp
p=`grep \>PHF\< $sht|wc|awkk 1`
if [ $p -eq 0 ]; then rm  $sht;fi
done
sleep 0
sht=`ls -rS sheet00?.htm|tail -n1`
mv $sht sht3_$m"_$i".htm
FILE=sheet00?".htm"
if [ -f $FILE ]; then rm $FILE;fi

fi

done
done
