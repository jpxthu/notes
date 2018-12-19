# 安装搜狗拼音输入法

1. 在[搜狗拼音官网](pinyin.sogou.com/linux)下载对应的安装包.

2. 打开终端，执行：

``` bash
cd Download
sudo dpkg -i sogouxxxx.deb
sudo apt-get install -f
```

3. 进入 `System Settings` -> `Language Support`.

4. 如果提示要安装，选择`是`。

5. `Keyboard input method system` 由 `iBus` 改为 `fcitx`，重启。

6. 右上角点输入法（键盘）符号，`Configure`，点`加号`，去掉 `Only Show Current Language`，找到 `Sogou Pinyin`，`OK`。
