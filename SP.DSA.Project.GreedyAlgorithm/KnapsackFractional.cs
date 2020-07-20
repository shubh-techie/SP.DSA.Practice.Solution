using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.GreedyAlgorithm
{
    public class KnapsackItem
    {
        public int index { get; set; }
        public int value { get; set; }
        public int weight { get; set; }
        public double density { get; set; }

        public KnapsackItem(int index, int value, int weight)
        {
            this.index = index;
            this.value = value;
            this.weight = weight;
            this.density = value * 1.0 / weight * 1.0;
        }
        public override string ToString()
        {
            return string.Format("index :{0}, value :{1}, weight :{2}, density:{3}", index, value, weight, this.density);
        }
    }

    public class sortbydensity : IComparer<KnapsackItem>
    {
        public int Compare(KnapsackItem x, KnapsackItem y)
        {
            return y.density.CompareTo(x.density);
        }
    }

    public class KnapsackFractional
    {
        public static void KnapsackFractionalDemo()
        {
            List<KnapsackItem> itemCollection = new List<KnapsackItem>();
            int[] value = { 6, 2, 1, 8, 3, 5 };
            int[] weight = { 6, 10, 3, 5, 1, 3 };

            for (int i = 0; i < value.Length; i++)
            {
                itemCollection.Add(new KnapsackItem(i + 1, value[i], weight[i]));
            }

            Console.WriteLine("input item is here.");
            foreach (var item in itemCollection)
            {
                Console.WriteLine(item.ToString());
            }

            itemCollection.Sort(new sortbydensity());

            Console.WriteLine("input after sorting.");
            foreach (var item in itemCollection)
            {
                Console.WriteLine(item.ToString());
            }

            int capacity = 10;
            double MaxItem = GetMaxItemInKnapsack(itemCollection, capacity);
            Console.WriteLine("MaxItem :{0}", MaxItem);

        }

        private static double GetMaxItemInKnapsack(List<KnapsackItem> itemCollection, int capacity)
        {
            double maxitem = 0;
            int itemCount = itemCollection.Count;

            for (int i = 0; i < itemCount; i++)
            {
                var currItem = itemCollection[i];
                if (capacity >= currItem.weight)
                {
                    maxitem += currItem.value;
                    //updating the capacity
                    capacity = capacity - currItem.weight;
                }
                else
                {
                    double fraction = capacity * 1.0 / currItem.weight;
                    maxitem += fraction * currItem.value;
                    capacity = capacity - (int)(currItem.weight * fraction);
                }
                if (capacity == 0)
                    break;
            }

            return maxitem;
        }
    }
}
