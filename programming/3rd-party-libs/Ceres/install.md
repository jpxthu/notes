# 安装 Ceres

官方参考：[Installation - Ceres Solver](http://www.ceres-solver.org/installation.html)

## 注意

1. 正经使用时不要输出 log，会降低速度。


``` cpp
ceres::Solver::Options options;
options.minimizer_progress_to_stdout = false;
```

2. 尽量不要使用 miniglog，会输出很多 log 且无法关闭，而且速度比 glog 慢不少。

## Windows

Windows ~~平台比较特别~~ 支持比较烂，截止更新时（2018.12.3），官网的方法无法正确编译。按以下步骤尝试：

### 获得 `Eigen`、`gflags`、`glog`、`Ceres` 源代码

我使用了最新的 master。

``` bash
git clone https://github.com/eigenteam/eigen-git-mirror.git eigen
git clone https://github.com/gflags/gflags.git
git clone https://github.com/google/glog.git
git clone https://github.com/ceres-solver/ceres-solver.git
```

### 修改 glog 的 `CMakeLists.txt` 文件

- CMake 脚本写得不太好，配置 gflags 比较麻烦，直接省略。

``` cmake
option (WITH_GFLAGS "Use gflags" OFF)
```

- 存在一个动态库 export 的问题，直接编译为动态库比较省事。

``` cmake
option (BUILD_SHARED_LIBS "Build shared libraries" ON)
```

### 编译 gflags 和 glog

示例：

``` bash
cmake -G "Visual Studio 15 2017" ..
cmake -G "Visual Studio 15 2017 Win64" ..
msbuild xxx.sln /m /p:Configuration=Release
```

### 复制 gflags 库并改名

会生成默认和 nothreads 两个库，选择需要用的库并改名为 `gflags.lib`。我选择了默认库，看起来没什么问题。

### 修改 Ceres 的 `CMakeLists.txt` 文件

- 禁用 SuiteSparse、CXSparse、LAPACK、BLAS 简化配置。如果需要的话需要另行配置。

``` cmake
option(SUITESPARSE "Enable SuiteSparse." OFF)
option(CXSPARSE "Enable CXSparse." OFF)
option(ACCELERATESPARSE "Enable use of sparse solvers in Apple's Accelerate framework." OFF)
option(LAPACK "Enable use of LAPACK directly within Ceres." OFF)
option(CUSTOM_BLAS "Use handcoded BLAS routines (usually faster) instead of Eigen." OFF)
```

- 编译为动态库。可根据个人喜好设置。动态库和 testing 不兼容，如果编译动态库需要禁用 testing。

``` cmake
option(BUILD_SHARED_LIBS "Build Ceres as a shared library." ON)
option(BUILD_TESTING "Enable tests" OFF)
```

如果不手动禁用的话，脚本也会自动禁用，但是会出很多错误提示。所有的错误都需要额外关注，尽量避免不必要的干扰。

### 生成 `sln` 工程

需要指定依赖库的路径。建议编译和使用 64 位，Ceres 内用了大量的 double。

``` bash
cmake -DEIGEN_INCLUDE_DIR_HINTS="D:/3rd_party/eigen" -DGLOG_INCLUDE_DIR_HINTS="D:/3rd_party/glog/src/windows" -DGLOG_LIBRARY_DIR_HINTS="D:/3rd_party/glog/build_x64/Release" -DGFLAGS_INCLUDE_DIR_HINTS="D:/3rd_party/gflags/build_x64/include" -DGFLAGS_LIBRARY_DIR_HINTS="D:/3rd_party/gflags/build_x64/Release" -G "Visual Studio 15 2017 Win64" ..
```

### 用 `MSBuild` 编译

多线程编译不像 `make -j` 那样占用非常多内存。过程比较慢，如果需要做别的事情可以使用参数 `/m[:N]` 限制使用线程，`N` 为线程数。

``` bat
msbuild xxx.sln /m /p:Configuration=Release
```

### 使用时的引用项

`Include directory` 为：

``` bash
D:\3rd_party\ceres-solver\build_x64\config # 额外生成的配置文件
D:\3rd_party\ceres-solver\include
D:\3rd_party\eigen
D:\3rd_party\gflags\build_x64\include # 生成头文件才有 gflags/gflags.h 的目录结构
D:\3rd_party\glog\src\windows
```

引用库和库路径自行设定：`Ceres`、`gflags`、`glog`。因为 `Eigen` 为纯头文件，不需要库依赖。
