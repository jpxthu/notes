# 搜索并删除行

> 引用自：[Stack Overflow - Delete lines in a text file that containing a specific string](https://stackoverflow.com/questions/5410757/delete-lines-in-a-text-file-that-containing-a-specific-string)

只输出处理后结果但不修改原文件：

``` bash
sed '/pattern to match/d' ./infile
```

处理原文件但不输出任何结果：

``` bash
sed -i '/pattern to match/d' ./infile
```

处理原文件之前保留备份：

``` bash
sed -i.bak '/pattern to match/d' ./infile
```

Mac OS X：

``` bash
sed -i '' '/pattern/d' ./infile
```
