using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public abstract class BaseClass
    {
        protected virtual void Assert<T>(T o1, T o2)
        {
            if (o1 is IList list1)
            {
                var list2 = o2 as IList;
                if (list1.Count == list2.Count)
                {
                    for (int i = 0; i < list1.Count; i++)
                        if (!list1[i].Equals(list2[i]))
                            throw new Exception(i + ": " + list1[i] + " " + list2[i]);
                }
            }
            else
            {
                if (o1.Equals(o2))
                    return;
                throw new Exception(o1 + " " + o2);
            }

        }

        public abstract void Run();
    }
}
