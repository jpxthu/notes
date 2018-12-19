# Python-pip 错误

## 系统找不到指定的路径

比如在卸载 `TensorFlow` 时可能遇到：

``` batch
FileNotFoundError: [WinError 3] 系统找不到指定的路径。: 'c:\\program files (x86)\\microsoft visual studio\\shared\\python36_64\\lib\\site-packages\\tensorflow\\contrib\\tensor_forest\\hybrid\\python\\models\\__pycache__\\stochastic_hard_decisions_to_data_then_nn.cpython-36.pyc' -> 'C:\\Users\\xxx\\AppData\\Local\\Temp\\pip-uninstall-8r7u4crg\\program files (x86)\\microsoft visual studio\\shared\\python36_64\\lib\\site-packages\\tensorflow\\contrib\\tensor_forest\\hybrid\\python\\models\\__pycache__\\stochastic_hard_decisions_to_data_then_nn.cpython-36.pyc'
```

造成错误的原因是路径过长，需要在注册表中开启长路径。将以下值改为 `1`：

```
HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\FileSystem@LongPathsEnabled 
```
