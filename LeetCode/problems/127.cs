using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _127 : BaseClass
    {
        public override void Run()
        {
            var t = LadderLength("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" });
            Assert(t, 5);

            t = LadderLength("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" });
            Assert(t, 5);

            t = LadderLength("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log" });
            Assert(t, 0);
        }

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (beginWord.Length != endWord.Length)
                return 0;

            var q = new Queue<string>();
            q.Enqueue(beginWord);

            int cnt = 1;
            var visited = new bool[wordList.Count];
            while (q.Count > 0)
            {
                cnt += 1;
                int queueCount = q.Count;
                while (queueCount-- > 0)
                {
                    var curr = q.Dequeue();
                    for (int i = 0; i < wordList.Count; i++)
                        if (!visited[i] && IsMatch(wordList[i], curr))
                        {
                            if (wordList[i] == endWord)
                                return cnt;
                            visited[i] = true;
                            q.Enqueue(wordList[i]);
                        }
                }
            }
            return 0;
        }

        private bool IsMatch(string word1, string word2)
        {
            if (word1.Length != word2.Length)
                return false;

            byte cnt = 0;
            for (int i = 0; i < word1.Length; i++)
                if (word1[i] != word2[i])
                {
                    cnt += 1;
                    if (cnt == 2)
                        break;
                }
            return cnt == 1;
        }
    }
}
