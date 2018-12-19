# 终端中显示的计算机名

Terminal 中终端名称太长，会是这样：`jpx@your-long-device-name`。`your-long-device-name` 是安装时的设备名称，每个人都不一样。`@` 后面的终端名在 `/etc/hostname` 文件中：

``` bash
your-long-device-name
```

以及 `/etc/hosts` 文件中也会有影响：

``` bash
127.0.0.1       localhost
127.0.1.1       your-long-device-name
...
```

用文本编辑器打开这些文件，将其中的 `your-long-device-name` 修改掉就好了，需要加 `sudo`，重启后生效：

``` bash
sudo vim /etc/hostname
sudo vim /etc/hosts
sudo reboot
```
