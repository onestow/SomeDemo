using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _415 : BaseClass
    {
        public override void Run()
        {
            var t = AddStrings("12345", "5");
            Assert(t, "12350");
            t = AddStrings("111", "999");
            Assert(t, "1110");
        }

        public string AddStrings(string num1, string num2)
        {
            if (num1.Length > num2.Length)
                num2 = num2.PadLeft(num1.Length, '0');
            else if (num1.Length < num2.Length)
                num1 = num1.PadLeft(num2.Length, '0');

            int jw = 0;
            var chs = new char[num1.Length + 1];
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                var sum = (byte)num1[i] - '0' + (byte)num2[i] - '0' + jw;
                if (sum > 9)
                {
                    jw = 1;
                    chs[i+1] = Convert.ToChar(sum % 10 + '0');
                }
                else
                {
                    jw = 0;
                    chs[i+1] = Convert.ToChar(sum + '0');
                }
            }

            if (jw == 0)
                return new string(chs.Skip(1).ToArray());
            chs[0] = '1';
            return new string(chs);
        }

    }
}
