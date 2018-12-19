# 删除旧的 commit 历史

引用自：[Stack Overflow - How do I remove the old history from a git repository?](https://stackoverflow.com/questions/4515580/how-do-i-remove-the-old-history-from-a-git-repository)

将**想要保留的最早 commit**写入 `.git/info/grafts`：

``` bash
echo 4a46bc886318679d8b15e05aea40b83ff6c3bd47 > .git/info/grafts
```

之后用 `git log` 查看，可以看到该 commit 之前的历史都没有了，全部合并到该 commit：

``` bash
commit cb3da2d4d8c3378919844b29e815bfd5fdc0210c
Author: Your Name <your.email@example.com>
Date:   Fri May 24 14:04:10 2013 +0200

    Another message

commit 4a46bc886318679d8b15e05aea40b83ff6c3bd47 (grafted)
Author: Your Name <your.email@example.com>
Date:   Thu May 23 22:27:48 2013 +0200

    Some message
```

如果符合要求，则永久应用这个改变：

``` bash
git filter-branch -- --all
```

然后用 `git push -f` 将受影响的 branch 更新至服务器即可。
