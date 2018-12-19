# CMake 跳过编译器检查

如果不希望 CMake 检查工具链（比如用时过长、测试程序无法编译等），可以在 CMakeLists.txt 文件中添加：

``` cmake
set(CMAKE_<LANG>_COMPILER_WORKS 1)
set(CMAKE_C_COMPILER_WORKS      1)
```
