# 类型检查

以下方法全部调用标准 C++ 库，全平台通用。[方法 1](#1) 简单、直观、灵活，但是有运算代价；[方法 2](#2) 和[方法 3](#3) 可以通过编译器优化实现 0 运算，但是需要编写模板函数。

声明如下类型和变量供测试：

``` cpp
// sample.hpp

struct A_s {
    int a;
};

struct B_s {
    int b;
};

typedef struct A_s A_t;

struct A_s as;
struct B_s bs;
A_t at;
```

**注意**：这个头文件的写法是不严谨的，仅仅是为了方便后续书写、保证代码可运行而已。

<span id="1"></span>

## 方法 1：调用 `typeid` 函数

`typeid(var)`（变量）或 `typeid(type)`（变量名）都可以得到一个 class，内有该 type 的名称、哈希值等信息，并重载了 `==` 运算符。需要引用头文件 `<typeinfo>`。

``` cpp
// main.cpp

#include "sample.hpp"

#include <iostream>
#include <typeinfo>

int main(void)
{
    std::cout << typeid(struct A_s).name() << std::endl;
    std::cout << typeid(as).name() << std::endl;
    std::cout << typeid(A_t).name() << std::endl;
    std::cout << typeid(bs).name() << std::endl;
    if (typeid(as) == typeid(A_t))
        std::cout << "same: as & at" << std::endl;
    if (typeid(struct A_s) != typeid(bs))
        std::cout << "different: struct A_s & bs" << std::endl;
    return 0;
}
```

运行结果：

```
struct A_s
struct A_s
struct A_s
struct B_s
same: as & at
different: struct A_s & bs
```

该方法的最大缺点是无法被编译器优化掉，无论用 `==` 还是比较 `name()`、`hash_code()`，程序运行时都需要计算得到结果。然而很多时候结果是显而易见的，我们希望编译器可以把 `if` 优化成 `true` / `false`。

<span id="2"></span>

## 方法 2：使用 `std::is_same`

需要调用头文件 `<type_traits>`。

``` cpp
// main.cpp

#include "sample.hpp"

#include <iostream>
#include <type_traits>

int main(void)
{
    if (std::is_same<struct A_s, A_t>::value)
        std::cout << "same: struct A_s & A_t" << std::endl;
    if (!std::is_same<struct A_s, struct B_s>::value)
        std::cout << "different: struct A_s & struct B_s" << std::endl;
    return 0;
}
```

运行结果：

```
same: struct A_s & A_t
different: struct A_s & struct B_s
```

功能具体实现可以参见头文件，使用了 C++ 模板，非常简单，也可以自己编写。因此编译时需要使用 `C++ 11` 或以上标准。`GCC` 编译时需要添加 `-std=c++11` 参数：

``` bash
g++ -std=c++11 -o main main.cpp
```

该方法在编译器打开速度优化选项后，`value` 会直接被优化成 `true` / `false`，例子中的 `if` 语句也会被优化掉。但是使用不是很方便，必须使用变量名，而不能直接使用变量。

<span id="3"></span>

## 方法 3：使用 `template`

在[方法 2](#2) 的基础上使用两个模板函数来实现。

``` cpp
// main.cpp

#include "sample.hpp"

#include <iostream>
#include <type_traits>

// 变量 比 变量
template<typename A, typename B>
inline bool is_same_type(A a, B b)
{
    return std::is_same<A, B>::value;
}

// 类型 比 变量
template<typename A, typename B>
inline bool is_same_type(B b)
{
    return std::is_same<A, B>::value;
}

int main(void)
{
    // 类型 比 类型
    if (std::is_same<struct A_s, A_t>::value)
        std::cout << "same: struct A_s & A_t" << std::endl;

    // 变量 比 变量
    if (is_same_type(as, at))
        std::cout << "same: as & at" << std::endl;
    if (!is_same_type(as, bs))
        std::cout << "different: as & bs" << std::endl;

    // 类型 比 变量
    if (is_same_type<struct A_s>(at))
        std::cout << "same: struct A_s & at" << std::endl;
    if (!is_same_type<struct A_s>(bs))
        std::cout << "different: struct A_s & bs" << std::endl;

    return 0;
}
```

运行结果：

```
same: struct A_s & A_t
same: as & at
different: as & bs
same: struct A_s & at
different: struct A_s & bs
```

同样需要 `C++ 11` 并且可以被完全优化。

---

返回 [C++](_main.md)
