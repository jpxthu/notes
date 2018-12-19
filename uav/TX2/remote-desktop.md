# 远程桌面

> 作者：jiangchao3392<br>
> 来源：CSDN<br>
> 原文：[https://blog.csdn.net/jiangchao3392/article/details/73252291](https://blog.csdn.net/jiangchao3392/article/details/73252291)<br>
> 版权声明：本文为博主原创文章，转载请附上博文链接！

# 安装 xrdp

Windows 远程桌面使用的是 RDP 协议，所以 Ubuntu 上就要先安装 `xrdp`。

终端命令行输入安装：

``` bash
sudo apt-get install xrdp vnc4server xbase-clients
```

# 设置打开桌面共享

安装完后在 `/usr/share/applications` 目录下打开 `桌面共享` 选项，进一步设定。

桌面共享选项中首先要开启共享，关于是否允许其他用户控制，远程连接时是否需要本机确认，远程连接的密码等项目根据需要自己设定。如果需要从公网即外部网络访问此 Ubuntu 计算机需要开启 `自动配置 UPnP 路由器开放和转发端口项目` 。一般建议如下图：

![22](/uav/TX2/img/22.png)
![23](/uav/TX2/img/23.png)

# 安装 dconf-editor

``` bash
sudo apt-get install dconf-editor
```

# 运行 dconf-editor

**注意一定要用当前用户来运行，不能加 sudo。安装还是需要 sudo 的。**

# 用 dconf-editor 调整

访问如下配置路径：`org > gnome > desktop > remote-access`

将 `promotion-enabled` 选项和 `requre-encryption` 去掉。

![24](/uav/TX2/img/24.png)

# 开始连接

在 Windows 电脑上我们打开远程桌面，输入 Ubuntu 电脑的 IP 地址，输入IP地址，端口不变（5900），你设定的密码，即可远程连接到ubuntu 16.04桌面。
