using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SomeDemo
{
    public class AnalyzeCondition
    {
        public void Run()
        {
            var condition = @"switch [300]
[100]:abcdefg
[200]:1234567
";

            var subCondition = GetMatchSubCondition(condition);
        }

        private string GetFirstValue(string str)
        {
            var match = Regex.Match(str, @"\[[\s\S]+?\]");
            return match.Value.Trim(']', '[', ' ');
        }

        private string GetMatchSubCondition(string condition)
        {
            var lines = condition.Split('\n');
            var switchValue = GetFirstValue(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                if (switchValue == GetFirstValue(lines[i]))
                    return lines[i].Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
            }
            return "";
        }
    }
}
