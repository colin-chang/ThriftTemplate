using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftDemo.Contract.Net;

namespace ThriftDemo.Contract.Implement.Net
{
    public class NetEmotionAnalyzer : EmotionAnalyzer.Iface
    {
        public void Stop(long key)
        {
            Console.WriteLine("日了狗了 Net");
        }
    }
}
