using System;
using System.Threading;
using System.Threading.Tasks;
using ThriftDemo.Contract.Core;

namespace ThriftDemo.Contract.Implement.Core
{
    public class CoreEmotionAnalyzer : EmotionAnalyzer.IAsync
    {
        public Task StopAsync(long key, CancellationToken cancellationToken)
        {
            Console.WriteLine("日了狗了 Core");
            return Task.CompletedTask;
        }
    }
}
