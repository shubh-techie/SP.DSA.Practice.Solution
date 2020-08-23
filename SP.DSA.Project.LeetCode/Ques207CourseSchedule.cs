using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class Ques207CourseSchedule
    {
        public static void Ques207CourseScheduleDemo()
        {
            int[][] prerequisites = new[] { new[] { 1, 0 } };
            int numCourses = 2;
            Console.WriteLine(CanFinish(numCourses, prerequisites));
        }
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (numCourses == 0) return true;
            HashSet<int> path = new HashSet<int>();
            HashSet<int> visited = new HashSet<int>();

            Dictionary<int, List<int>> courseDic = new Dictionary<int, List<int>>();
            foreach (var item in prerequisites)
            {
                if (courseDic.ContainsKey(item[1]))
                {
                    courseDic[item[1]].Add(item[0]);
                }
                else
                {
                    courseDic.Add(item[1], new List<int>() { item[0] });
                }
            }

            for (int currCourse = 0; currCourse < numCourses; currCourse++)
            {
                if (!visited.Contains(currCourse) && HasCycle(currCourse, courseDic, visited, path))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool HasCycle(int currCourse, Dictionary<int, List<int>> courseDic, HashSet<int> visited, HashSet<int> path)
        {
            if (path.Contains(currCourse))
                return true;
            if (visited.Contains(currCourse))
                return false;

            visited.Add(currCourse);
            path.Add(currCourse);

            if (courseDic.ContainsKey(currCourse))
            {
                foreach (var neighbour in courseDic[currCourse])
                {
                    if (HasCycle(neighbour, courseDic, visited, path))
                    {
                        return true;
                    }
                }
            }

            path.Remove(currCourse);
            return false;
        }
    }
}
