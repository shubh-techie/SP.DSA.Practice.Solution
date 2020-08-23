using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class RandomizedCollection
    {
        Dictionary<int, HashSet<int>> _dic;
        List<int> _list;
        private Random _rand = default(Random);

        public RandomizedCollection()
        {
            _dic = new Dictionary<int, HashSet<int>>();
            _list = new List<int>();
            _rand = new Random();
        }
        public bool Insert(int val)
        {
            if (!_dic.ContainsKey(val))
            {
                _dic.Add(val, new HashSet<int>());
            }
            _list.Add(val);
            int currIndex = _list.Count - 1;
            _dic[val].Add(currIndex);
            return _dic[val].Count == 1;
        }
        public bool Remove(int val)
        {
            if (!_dic.ContainsKey(val) || _dic.Count == 0) return false;

            int removeIndex = _dic[val].Last();
            _dic[val].Remove(removeIndex);

            int lastElement = _list[_list.Count - 1];
            _list[removeIndex] = lastElement;
            _dic[lastElement].Add(removeIndex);

            _dic[lastElement].Remove(_list.Count - 1);
            _list.Remove(_list.Count - 1);
            return true;
        }

        public int GetRandom()
        {
            return _list[_rand.Next(_list.Count)];
        }
    }
    public class RandomizedSet
    {
        Dictionary<int, int> rMap;
        List<int> rList;
        public RandomizedSet()
        {
            rMap = new Dictionary<int, int>();
            rList = new List<int>();
        }
        public bool Insert(int val)
        {
            if (rMap.ContainsKey(val)) return false;
            rMap.Add(val, rList.Count);
            rList.Add(rList.Count);
            return true;
        }

        public bool Remove(int val)
        {
            if (!rMap.ContainsKey(val)) return false;
            int itemIndex = rMap[val]; // get the item index
            int lastElement = rList[rList.Count - 1]; // get the last index

            rList[itemIndex] = lastElement; // move last element to item index
            rMap[lastElement] = itemIndex; //upadate the last element index

            rList.RemoveAt(rList.Count - 1); //remove the 
            rMap.Remove(val); // remove from the dictionary
            return true;
        }

        public int GetRandom()
        {
            return rList[new Random().Next(rList.Count)];
        }
    }
    public class Ques380InsertDeleteGetRandom
    {

    }
}
