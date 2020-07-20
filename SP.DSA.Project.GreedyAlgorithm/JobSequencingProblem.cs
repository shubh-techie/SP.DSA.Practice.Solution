using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.GreedyAlgorithm
{
    public class Job
    {
        public int JobID { get; set; }
        public int Deadline { get; set; }
        public int Profit { get; set; }

        public Job(int jobid, int deadline, int profit)
        {
            this.JobID = jobid;
            this.Deadline = deadline;
            this.Profit = profit;
        }

        public override string ToString()
        {
            return string.Format("id :{0} deadline :{1} profit: {2}", this.JobID, this.Deadline, this.Profit);
        }
    }

    public class SortByProfit : IComparer<Job>
    {
        public int Compare(Job x, Job y)
        {
            return y.Profit - x.Profit;
        }
    }
    public class JobSequencingProblem
    {
        public static void JobSequencingProblemDemo()
        {
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job(1, 4, 20));
            jobs.Add(new Job(2, 1, 10));
            jobs.Add(new Job(3, 1, 40));
            jobs.Add(new Job(4, 1, 30));

            //Input 
            foreach (var item in jobs)
            {
                Console.WriteLine(item.ToString());
            }

            jobs.Sort(new SortByProfit());

            //After sorting.... 
            Console.WriteLine();
            foreach (var item in jobs)
            {
                Console.WriteLine(item.ToString());
            }

            int maxProfit = GetMaxProfit(jobs);
            Console.WriteLine("max Profit :" + maxProfit);
        }

        private static int GetMaxProfit(List<Job> jobs)
        {
            int maxProfit = 0; int n = jobs.Count;
            bool[] slots = new bool[n];
            for (int i = 0; i < n; i++)
            {
                Job currJob = jobs[i];
                for (int j = currJob.Deadline - 1; j >= 0; j--)
                {
                    if (slots[j] == false)
                    {
                        slots[j] = true;
                        maxProfit += currJob.Profit;
                        break;
                    }
                }
            }
            return maxProfit;
        }
    }
}
