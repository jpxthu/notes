# Pixracer 飞控板

[https://docs.px4.io/en/flight_controller/pixracer.html](https://docs.px4.io/en/flight_controller/pixracer.html)

淘宝有售。我买的链接：[https://item.taobao.com/item.htm?spm=a1z09.2.0.0.6d9e2e8dvo5SfH&id=559369662646&_u=b8kecdh8d84](https://item.taobao.com/item.htm?spm=a1z09.2.0.0.6d9e2e8dvo5SfH&id=559369662646&_u=b8kecdh8d84)

## 选择理由

1. 量产产品，容易购买，便宜

2. 软件硬件开源，方便在开发时参考

3. 烧写方便
	- 带有一个 6-pin 的 DEBUG 接口，4-pin 可以连接 ST-Link 进行烧写，其余 2-pin 为串口（TX & RX）。
	- Pixhawk 2.4.8 必须用 USB 通过 Bootloader 更新固件，直接对 STM32 烧写需要自己焊 10-pin JTAG 插座，难度比较高。

4. 体积小：Pixhawk 系列体积最小的板子之一

5. 功能全
	- Main System-on-Chip: STM32F427VIT6 rev.3
	- CPU: 180 MHz ARM Cortex® M4 with single-precision FPU
	- RAM: 256 KB SRAM (L1)
	- Standard FPV form factor: 36x36 mm with standard 30.5 mm hole pattern
	- Invensense® ICM-20608 Accel / Gyro (4 KHz) / MPU9250 Accel / Gyro / Mag (4 KHz)
	- HMC5983 magnetometer with temperature compensation
	- Measurement Specialties MS5611 barometer
	- JST GH connectors
	- microSD (logging)
	- Futaba S.BUS and S.BUS2 / Spektrum DSM2 and DSMX / Graupner SUMD / PPM input / Yuneec ST24
	- FrSky® telemetry port
	- OneShot PWM out (configurable)
	- Optional: Safety switch and buzzer
	- 来自 <https://docs.px4.io/en/flight_controller/pixracer.html>

## 原理图

见官网页面
