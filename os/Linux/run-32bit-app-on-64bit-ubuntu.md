# 在 64 位 Ubuntu 上运行 32 位程序<br/>运行程序时报错 No such file or directory

会提示 `No such file or directory` 或者动态库缺失之类的问题。

可以尝试安装以下（也许只需要一部分）：

``` bash
sudo apt-get install libc6-i386 lib32stdc++6 lib32z1 lib32ncurses5
```
