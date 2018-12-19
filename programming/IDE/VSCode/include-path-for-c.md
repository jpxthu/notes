# C/C++ include path 设置

引用自 [VS Code 官方文档](https://github.com/Microsoft/vscode-cpptools/blob/master/Documentation/Getting%20started.md)

当某一条 `#include` 找不到时，会划绿线、显示黄灯泡。点击黄灯泡，选择 `Edit "includePath" setting`，生成并编辑 `c_cpp_properties.json` 文件。

### 1. 手动添加

在 `"includePath"` 条目中直接手动添加。

### 2. 使用 CMake 自动生成依赖

在 `CMakeLists.txt` 中添加如下命令：

``` cmake
set(CMAKE_EXPORT_COMPILE_COMMANDS on)
```

在执行 `cmake` 的时候就会生成 `compile_conmmands.json` 文件。比如执行：

``` bash
mkdir -p build
cd build
cmake ..
```

就会生成 `build/compile_commands.json` 文件。在 `c_cpp_properties.json` 中添加 `compileCommands` 属性：

``` json
"defines": [],
"compileCommands": "build/compile_commands.json",
"intelliSenseMode": ...
```
