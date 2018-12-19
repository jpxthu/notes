# rpath（Runtime Path）

## 编译前

gcc、g++ 可通过链接指令 `-Wl,-rpath` 指定 rpath。

## MacOS X

用工具 `otool` 查看程序链接库和 rpath 信息：

``` bash
otool -L $BIN
otool -l $BIN | grep "path"
```

用工具 `install_name_tool` 更改库引用路径：

``` bash
install_name_tool -change $OLD_LIB $NEW_LIB $BIN
```

同时可能还需要更改动态库的 `install_name`，编译动态库时同样需要指定。

``` bash
install_name_tool -id "@rpath/path/libxx.dylib" libxx.dylib
install_name_tool -id "full_path/libxx.dylib" libxx.dylib
```

## Linux

用工具 `ldd` 查看动态库链接信息：

``` bash
ldd $BIN
```

用工具 `chrpath` 和 `patchelf`，需要安装：

``` bash
sudo apt-get install chrpath patchelf

# 有 rpath 的时候：
chrpath -r $NEW_RPATH $BIN

# 没有 rpath 的时候：
patchelf --set-rpath $NEW_RPATH $BIN
```
