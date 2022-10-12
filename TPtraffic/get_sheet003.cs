num=(%E4%B8%80 %E4%BA%8C %E4%B8%89 %E5%9B%9B %E4%BA%94 %E5%85%AD %E4%B8%83 %E5%85%AB %E4%B9%9D)
traf=%E4%BA%A4%E9%80%9A%E6%B5%81%E9%87%8F
ninety=%E4%B9%9D%E5%8D%81
year=%E5%B9%B4%E5%BA%A6
ints=%E8%B7%AF%E5%8F%A3

for m in {1..9};do
n=$(( m - 1 ))
file='http://163.29.251.188/botedata/'$traf'/'$ninety${num[$n]}$year'/HTML/'$ints'/I001-9'$m'.files/sheet003.htm'
wget $file
mv sheet003.htm 
done

