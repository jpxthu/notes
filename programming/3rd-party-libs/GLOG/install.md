# 安装 GLOG

通过宏 `GOOGLE_GLOG_DLL_DECL` 控制库函数 export 标识。在编译时 CMake 脚本会自动设置，但是在使用时，头文件中该宏会默认使用动态库的头。如果使用静态库，务必声明该宏为空，否则在 Windows 下按动态库处理会报错。
