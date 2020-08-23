using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class FirstUnique
    {
        Queue<int> queue = new Queue<int>();
        Dictionary<int, bool> unique = new Dictionary<int, bool>();

        public FirstUnique(int[] nums)
        {
            unique = new Dictionary<int, bool>();
            foreach (var no in nums)
            {
                this.Add(no);
            }
        }
        public int ShowFirstUnique()
        {
            while (queue.Count > 0 && !unique[queue.Peek()])
            {
                queue.Dequeue();
            }

            if (queue.Count > 0)
            {
                return queue.Peek();
            }
            return -1;
        }

        public void Add(int value)
        {
            queue.Enqueue(value);
            if (unique.ContainsKey(value))
                unique[value] = false;
            else
                unique[value] = true;
        }
    }
    public class Ques1429FirstUniqueNumber
    {

    }
}
