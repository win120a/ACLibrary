using System;
using System.Collections.Generic;
using System.Text;

namespace ACLibrary.TypeConvert
{
    public class NumberConverter
    {
        public static string Int2String(int oi)
        {
            StringBuilder s = new StringBuilder();
            s.Append(oi);
            return s.ToString();
        }

        public static List<string> IntCollectionToStringList(ICollection<int> ol)
        {
            if (ol is ISet<int>)
            {
                throw new NotSupportedException();
            }


            List<string> sl = new List<string>();

            foreach (int ti in ol)
            {
                StringBuilder s = new StringBuilder();
                s.Append(ti);
                sl.Add(s.ToString());
                GC.Collect();
            }


            return sl;
        }

        public static string Long2String(long ol)
        {
            StringBuilder s = new StringBuilder();
            s.Append(ol);
            return s.ToString();
        }

        public static List<string> LongCollectionToStringList(ICollection<long> ol)
        {
            if (ol is ISet<long>)
            {
                throw new NotSupportedException();
            }


            List<string> sl = new List<string>();

            foreach (long ti in ol)
            {
                StringBuilder s = new StringBuilder();
                s.Append(ti);
                sl.Add(s.ToString());
                GC.Collect();
            }


            return sl;
        }
    }
}
