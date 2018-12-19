# SDK on TX2

[https://mikeisted.wordpress.com/2018/04/09/intel-realsense-d435-on-jetson-tx2/](https://mikeisted.wordpress.com/2018/04/09/intel-realsense-d435-on-jetson-tx2/)

- Flash the TX2 with JetPack 3.2
- git clone https://github.com/IntelRealSense/librealsense.git
- cd librealsense
- sudo apt-get update
- modify librealsense/src/image.cpp as per gist above
- sudo apt-get install git cmake libssl-dev libusb-1.0-0-dev pkg-config libgtk-3-dev libglfw3 libglfw3-dev libudev-dev cmake-curses-gui
- sudo cp config/99-realsense-libusb.rules /etc/udev/rules.d/
- sudo udevadm control –reload-rules && udevadm trigger
- reboot
- mkdir build && mkdir install
- cd build
- cmake ../ -DBUILD_EXAMPLES=true -DCMAKE_BUILD_TYPE=release -DBUILD_UNIT_TESTS=false
- make -j4
- sudo make install
- Connect D435 to the USB3 port
- Navigate to the tools at usr/local/bin, such as:<br>
./realsense-viewer


下面这个太旧了，不要用。

[~~https://github.com/jetsonhacks/installLibrealsenseTX2/blob/master/installLibrealsense.sh~~](https://github.com/jetsonhacks/installLibrealsenseTX2/blob/master/installLibrealsense.sh)

~~基本是可用的。~~

## ~~安装依赖~~

``` bash
sudo apt-get update
sudo apt-get install libusb-1.0-0-dev pkg-config -y
sudo apt-get install libglfw3-dev -y
sudo apt-get install qtcreator -y
sudo apt-get install cmake-curses-gui -y
```

## ~~Clone~~

``` bash
git clone https://github.com/IntelRealSense/librealsense.git
cd librealsense
git checkout v2.9.1
```

## ~~安装 QT~~

~~`scripts/install_qt.sh` 脚本中的源国内不好访问，无需添加，直接执行安装即可。中科大源里都是全的。~~

``` bash
sudo apt-get install qdbus qmlscene qt5-default qt5-qmake qtbase5-dev-tools qtchooser qtdeclarative5-dev xbitmaps xterm libqt5svg5-dev qttools5-dev qtscript5-dev qtdeclarative5-folderlistmodel-plugin qtdeclarative5-controls-plugin
```

## ~~配置 USB（不确定）~~

``` bash
sudo cp config/99-realsense-libusb.rules /etc/udev/rules.d/
sudo udevadm control --reload-rules && udevadm trigger
```
