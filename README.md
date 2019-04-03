# ThriftTemplate

Template projects of thrift on .net platform.Including .Net Framework,Mono,.NET Core.

**Generate .Net Core**

```sh
# Generate C# sync code
docker run -v "$PWD:/data" thrift thrift -o /data --gen csharp /data/UserService.thrift
cp gen-csharp/ThriftDemo/Contract/Net/*.cs ThriftDemo.Contract.Net/
cp gen-csharp/ThriftDemo/Contract/Net/*.cs ThriftDemo.Contract.Std/
rm -rf gen-csharp

# Generate C# async code
docker run -v "$PWD:/data" thrift thrift -o /data --gen netcore /data/UserService.thrift
cp gen-netcore/ThriftDemo/Contract/Core/*.cs ThriftDemo.Contract.Core/
rm -rf gen-netcore
```

**Tips**

The projects under `Core` and `Net` use Apache official nuget package [ApacheThrift](https://www.nuget.org/packages/ApacheThrift/).It provides different dll files in different platforms.But you can not ues a netcore client to call a .net framework server.

The projects under `Cross` use a third part nuget package [apache-thrift-netcore](https://www.nuget.org/packages/apache-thrift-netcore/).It can be used cross any platforms.
