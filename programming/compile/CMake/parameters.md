# 生成参数

## 32/64 位 VS 工程

``` bash
cmake -G "Visual Studio 15 2017" ..
cmake -G "Visual Studio 15 2017 Win64" ..
```

## Debug/Release

``` bash
cmake -DCMAKE_BUILD_TYPE=Debug ..
cmake -DCMAKE_BUILD_TYPE=Release ..
```

注意在生成 VS 工程（Windows）时不需要此参数。生成的 sln 中包含四个配置，分别使用不同的优化配置。
