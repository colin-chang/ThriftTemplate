namespace csharp ThriftDemo.Contract.Net
namespace netcore ThriftDemo.Contract.Core

service EmotionAnalyzer {
  void Stop(1: i64 key)
}