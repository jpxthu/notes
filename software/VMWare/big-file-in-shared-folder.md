# 共享文件夹内长文件报错

报错：`Value too large for defined data type` 等。

可以通过更改 mount 参数来解决：

``` bash
sudo vim /etc/vmware-tools/services.sh
```

找到 `vmware_mount_vmhgfs()` 函数，添加 `-o nounix,noserverino`，修改后结果如下：

``` bash
# Mount all hgfs filesystems
vmware_mount_vmhgfs() {
  if [ "`is_vmhgfs_mounted`" = "no" ]; then
    if [ "`vmware_vmhgfs_use_fuse`" = "yes" ]; then
      mkdir -p $vmhgfs_mnt
      vmware_exec_selinux "$vmdb_answer_BINDIR/vmhgfs-fuse \
         -o subtype=vmhgfs-fuse,allow_other $vmhgfs_mnt"
    else
      vmware_exec_selinux "mount -t vmhgfs .host:/ $vmhgfs_mnt -o nounix,noserverino"
    fi
  fi
}
```

之后重新启动虚拟机。
