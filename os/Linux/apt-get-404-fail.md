# apt-get 404 fail

## 错误

``` bash
E: Failed to fetch https://mirrors.tuna.tsinghua.edu.cn/ubuntu/dists/xenial/main/binary-arm64/Packages  404  Not Found
E: Failed to fetch https://mirrors.tuna.tsinghua.edu.cn/ubuntu/dists/xenial-updates/main/binary-arm64/Packages  404  Not Found
E: Failed to fetch https://mirrors.tuna.tsinghua.edu.cn/ubuntu/dists/xenial-backports/main/binary-arm64/Packages  404  Not Found
E: Failed to fetch https://mirrors.tuna.tsinghua.edu.cn/ubuntu/dists/xenial-security/main/binary-arm64/Packages  404  Not Found
E: Some index files failed to download. They have been ignored, or old ones used instead.
```

## 解决方法

``` bash
apt-get remove .*:arm64
dpkg --remove-architecture arm64
```
