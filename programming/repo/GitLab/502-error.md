# 502 Error

> 引用自 https://blog.csdn.net/wangxicoding/article/details/43738137

502 Error : Whoops, GitLab is taking too much time to respond.

可以用命令 `gitlab-ctl tail unicorn` 追踪问题 log。

一般为 8080 端口被占用，修改文件 `/etc/gitlab/gitlab.rb` 中的端口：

```
unicorn['port'] = 8080
```

然后用命令 `gitlab-ctl reconfigure` 重新配置即可。
