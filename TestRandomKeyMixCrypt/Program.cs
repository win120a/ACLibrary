using ACLibrary.Crypto.RandomKeyMixCrypt;
using System;
using System.Text;

namespace TestRandomKeyMixCrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Mid engine = new Mid();

            ReturnStruct r = engine.EncryptString("test", "abc123");

            Console.WriteLine(r.Result);
            Console.WriteLine();

            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            int it = 0;

            foreach (int ti in r.RandomKeys)
            {
                sb.Append(ti);
                if (it != (r.RandomKeys.Length) - 1)
                {
                    sb.Append(",");
                }
                it++;
            }

            sb.Append("]");

            Console.WriteLine(sb.ToString());

            Console.ReadLine();

            Console.Clear();

            Console.WriteLine(engine.DecryptString(r.Result, "abc123", r.RandomKeys));

            Console.ReadLine();
        }
    }
}
