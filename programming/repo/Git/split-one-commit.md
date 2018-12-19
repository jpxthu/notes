# 将一个 commit 分割成多个

三个 commit，分别更新了 c0、c1、c2、c3 文件：

<pre class="code highlight js-syntax-highlight c white" lang="c" v-pre="true">
<code><span class="cm">$ git log --pretty=oneline
<font color="yellow">be529a5024dcb56e8f86c6c316aa6c194a62a5d7</font> c3
<font color="yellow">c97229a9a17063f627e6c44475f4a4c15ecfa0b4</font> c1 c2
<font color="yellow">7a6afe8daccf04ec45e0d7d0e29337910ebe3b89</font> c0</span></code></pre>

现在将 `c1 c2` 这个 commit 分割成两个 commit。使用 `rebase` 命令：

``` bash
$ git rebase -i 7a6afe8daccf04ec45e0d7d0e29337910ebe3b89
```

上面的 hash 对应 `c0` commit。出现 rebase 界面：

<pre class="code highlight js-syntax-highlight c white" lang="c" v-pre="true">
<code><span class="cm"><font color="yellow">pick</font> <font color="aqua">c97229a</font> <font color="fuchsia">c1 c2</font>
<font color="yellow">pick</font> <font color="aqua">be529a5</font> <font color="fuchsia">c3</font>
<font color="gray"># 省去 git rebase 提示</font></span></code></pre>

将要修改的 commit 设为“编辑”：`# e, edit = use commit, but stop for amending`

<pre class="code highlight js-syntax-highlight c white" lang="c" v-pre="true">
<code><span class="cm"><font color="blue">e</font> <font color="aqua">c97229a</font> <font color="fuchsia">c1 c2</font>
<font color="yellow">pick</font> <font color="aqua">be529a5</font> <font color="fuchsia">c3</font></span></code></pre>

保存退出后，会停留在这个 commit 之后（`git commit -m 'c1 c2'`）。然后使用 `git reset` 命令回到 `git commit` 和 `git add` 状态之前：

``` bash
$ git reset HEAD~
```

用 `git status` 查看当前状态验证：

<pre class="code highlight js-syntax-highlight c white" lang="c" v-pre="true">
<code><span class="cm">$ git status
Untracked files:
  (use "git add &ltfile&gt..." to include in what will be committed)

        <font color="red">c1</font>
        <font color="red">c2</font>

nothing added to commit but untracked files present (use "git add" to track)</span></code></pre>

这时就可以分别 `git add` 并生成两个 commit，然后结束 rebase 过程：

``` bash
$ git add c1 && git commit -m 'c1'
$ git add c2 && git commit -m 'c2'
$ git rebase --continue
```

再查看 `git log`：

<pre class="code highlight js-syntax-highlight c white" lang="c" v-pre="true">
<code><span class="cm">$ git log --pretty=oneline
<font color="yellow">4a93a6d33696d587d7bd150ba4e5885c09b0ba5f</font> c3
<font color="yellow">59090168934ec471d19832fb268920e3faebcd9e</font> c2
<font color="yellow">c72c0dda5f42baeca6eac853795031b8ee2b8d0f</font> c1
<font color="yellow">7a6afe8daccf04ec45e0d7d0e29337910ebe3b89</font> c0</span></code></pre>

可以用 `git show <hash>` 验证，commit `c1` 只修改了 c1 文件，commit `c2` 只修改了 c2 文件。c1、c2、c3 的 hash 都变了。

如果需要将单个 commit 内某一个文件的改动分离，可以用该方法，将改动比较少的那一部分从 commit 中撤销，`git commit` 之后再写在后面；或者开一个新分支，`git reset --hard` 到 commit 之前，单独写一个小 commit 包含改动比较少的那一部分，再回到原分支 `git rebase -i <新分支>`。
