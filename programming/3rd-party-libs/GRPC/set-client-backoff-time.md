# 修改客户端连接服务器失败后的等待时间（backoff）

GRPC 默认有一个保护机制：当客户端（Client）连接服务器（Server）失败（比如服务器未开启）后，将有一段无响应时间，这一段时间内会禁止一切连接服务器的动作。该 `backoff` 时间默认有 10 秒还是 30 秒，忘记了。

在很多时候连接失败重试不想等那么久，可以手动修改。该参数为 `grpc.testing.fixed_reconnect_backoff_ms`。

Google 提供了一些方法来修改这个私有成员。一般可以在构造的时候调用构造函数来实现。Client `stub` 在创建的时候需要 `std::shared_ptr<grpc::Channel>` 类型的参数，官方默认的 Channel 构造方法只提供了 IP 地址。有另外一个构造函数：

``` cpp
// c++
namespace grpc {
std::shared_ptr<Channel> CreateCustomChannel(
    const grpc::string& target,
    const std::shared_ptr<ChannelCredentials>& creds,
    const ChannelArguments& args);
}
```

这里可以用构造好的 args 来指定我们想要的参数。例程如下：

``` cpp
// c++
static grpc::ChannelArguments ChannelArgumentsSetBackoff(int backoff_ms)
{
    grpc::ChannelArguments ca = grpc::ChannelArguments();
    ca.SetInt("grpc.testing.fixed_reconnect_backoff_ms", backoff_ms);
    return ca;
}
CustomClient client(grpc::CreateCustomChannel(
    "localhost:50051",
    grpc::InsecureChannelCredentials(),
    ChannelArgumentsSetBackoff(1000)));
```

这样构造的 client 只有 1000 ms 的 backoff。其它语言可以寻找对应函数。
