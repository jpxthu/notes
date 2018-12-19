# 删除无用的 commit

引用自：[Stack Overflow - Listing and deleting Git commits that are under no branch (dangling?)](https://stackoverflow.com/questions/3765234/listing-and-deleting-git-commits-that-are-under-no-branch-dangling)

删除未被 merge 的 branch、使用 rebase 命令等都会留下一些 commit，这些 commit 不会被任何一个 branch 记录，但是仍然占用空间；以及有时候错误地将一些额外的文件加入 commit，通过 rebase 等手段无法彻底清除，通过访问 commit 仍然可以得到这些文件。可以通过该方法快速删除这些 unreachable/dangling commit：

``` bash
git reflog expire --expire-unreachable=now --all
git gc --prune=now
```

但是该更改只会影响本地 git 库，要更改远程库，需要登录远程库进行管理操作，或者在 web 页面中寻找相关的选项。
