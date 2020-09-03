using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    public class _剑指Offer20 : BaseClass
    {
        public override void Run()
        {
            var t = IsNumber("1");
            Assert(t, true);
            t = IsNumber(" ");
            Assert(t, false);
            t = IsNumber(" 005047e+6");
            Assert(t, true);
            t = IsNumber("+.8");
            Assert(t, true);
            t = IsNumber("-.");
            Assert(t, false);
            t = IsNumber(".");
            Assert(t, false);
            t = IsNumber(".e1");
            Assert(t, false);
            t = IsNumber(".1");
            Assert(t, true);
            t = IsNumber("1.");
            Assert(t, true);
            t = IsNumber("e9");
            Assert(t, false);
            t = IsNumber("3");
            Assert(t, true);
            t = IsNumber("3.14.1");
            Assert(t, false);
            t = IsNumber("3,14");
            Assert(t, false);
        }

        public bool IsNumber(string s)
        {
            var sps = s.Trim().Split(new char[]{'e','E'});
            if (sps.Length > 2)
                return false;
            if (sps[0].All(ch => !char.IsNumber(ch)))
                return false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(sps[0], @"^([+-]?\d*)?(\.\d*)?$"))
                return false;
            if (sps.Length == 2)
                return System.Text.RegularExpressions.Regex.IsMatch(sps[1], @"^[+-]?\d+$");
            return true;
        }
    }
}