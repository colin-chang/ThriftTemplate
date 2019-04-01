using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftDemo.Contract.Std;

namespace ThriftDemo.Contract.Implement.Std
{
    public class StdEmotionAnalyzer : EmotionAnalyzer.Iface
    {
        public void Stop(long key)
        {
            Console.WriteLine("日了狗了 Net");
        }
    }
}
