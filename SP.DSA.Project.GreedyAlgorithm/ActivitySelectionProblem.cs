using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.GreedyAlgorithm
{
    public class Activity
    {
        public string Name { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public Activity(string name, int startTime, int endTime)
        {
            this.Name = name;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
        public override string ToString()
        {
            return string.Format("name :{0}, startTime :{1}, endTime :{2}", this.Name, this.StartTime, this.EndTime);
        }
    }
    public class SoryByEndTime : IComparer<Activity>
    {
        public int Compare(Activity x, Activity y)
        {
            return x.EndTime - y.EndTime;
        }
    }
    public class ActivitySelectionProblem
    {
        public static void ActivitySelectionProblemDemo()
        {
            //List<Activity> activityList = new List<Activity>() {
            //new Activity("A1", 0, 6),
            //new Activity("A2", 3, 4),
            //new Activity("A3", 1, 2),
            //new Activity("A4", 5, 8),
            //new Activity("A5", 5, 7),
            //new Activity("A6", 9, 9),
            //};

            List<Activity> activityList = new List<Activity>() {
            new Activity("A6", 5, 9),
            new Activity("A4", 5, 7),
            new Activity("A1", 1, 2),
            new Activity("A2", 3, 4),
            new Activity("A5", 8, 9),
            new Activity("A3", 2, 6)
            };

            Console.WriteLine("Input list.");
            foreach (var item in activityList)
            {
                Console.WriteLine(item.ToString());
            }

            List<Activity> optimalList = GetOptimalActivitySolution(activityList);

            Console.WriteLine("Optimal Solution....");
            Console.WriteLine();
            foreach (var item in optimalList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static List<Activity> GetOptimalActivitySolution(List<Activity> activityList)
        {
            List<Activity> optimalList = new List<Activity>();
            activityList.Sort(new SoryByEndTime());

            Console.WriteLine();
            Console.WriteLine("After sorting activity list.");
            foreach (var item in activityList)
            {
                Console.WriteLine(item.ToString());
            }
            int totolAcitity = activityList.Count;

            //First activity will be always gets selected.
            int previousActivity = 0;
            optimalList.Add(activityList[previousActivity]);
            for (int i = 1; i < totolAcitity; i++)
            {
                if (activityList[i].StartTime > activityList[previousActivity].EndTime)
                {
                    optimalList.Add(activityList[i]);
                    previousActivity = i;
                }
            }

            return optimalList;
        }
    }
}
