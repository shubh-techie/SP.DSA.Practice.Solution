using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SP.DSA.Project.LeetCode
{
    public class TreeNode
    {
        public int Val;
        public TreeNode Left, Right;
        public TreeNode(int val)
        {
            this.Val = val;
            Left = Right = null;
        }
    }
    internal class Cordinate
    {
        public int x, y;
        public Cordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class AmazonOnlinePractice
    {
        public static void AmazonOnlinePracticeDemo()
        {
            string output = "This is testing.........9879879809808968767&^&*^&*^*^*&...........Hello World this is testing...";
            Console.WriteLine(output);
            output = Regex.Replace(output, @"[^a-zA-Z]+", " ");
            Console.WriteLine(output);
            Console.WriteLine(output);

            //Amazon | OA 2019 | Max Of Min Altitudes
            //MaxOfMinAltitudes();

            //Amazon | OA 2019 | Substrings with exactly K distinct chars
            //ExactlyKdistinctChars();

            //Spiral Matrix II Fil Given a positive integer n, generate a square matrix filled with elements from 1 to n2 in spiral order
            //GenerateMatrixDemo();

            //favoritegenre
            //favoritegenreDemo();

            //Optimal utilization.
            //OptimalUtilization();

            //Distance Between Nodes in BST
            //BSTNodesDistance();

            //Amazon | OA 2020 | Top K Frequently Mentioned Keywords
            //KFrequentlyMentionedKeywords();

            //Amazon Fresh Promotion
            //AmazonFreshPromotion();

            //Rotten Oranges 
            RottenOranges();

            //Zombie in Matrix
            //ZombieInMatrix();

            //TreasureIslandII();
            //TreasureIslandDemo();

            //763 Partition Level
            // Amazon | OA 2019 | Two Sum - Unique Pairs
            TwoSumUniquePairs();
            TwoSumBest();
        }

        public static int GetMaxScore(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            int m = grid.Length, n = grid[0].Length, maxScore = int.MaxValue;
            int[,] maxMin = new int[m, n];
            maxMin[0, 0] = maxScore;

            for (int i = 1; i < m; i++) maxMin[i, 0] = Math.Min(grid[i][0], maxMin[i - 1, 0]);

            for (int j = 1; j < n; j++) maxMin[0, j] = Math.Min(grid[0][j], maxMin[0, j - 1]);

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    int upper = Math.Min(grid[i][j], maxMin[i - 1, j]);
                    int left = Math.Min(grid[i][j], maxMin[i, j - 1]);
                    maxMin[i, j] = Math.Max(upper, left);
                }
            }

            return Math.Max(maxMin[m - 1, n - 2], maxMin[m - 2, n - 1]);
        }

        public static void MaxOfMinAltitudestest(int[][] grid, int expected)
        {
            Console.WriteLine(GetMaxScore((grid)) == expected);
        }

        public static void MaxOfMinAltitudes()
        {
            int[][] grid1 = new[] { new[] { 5, 1 }, new[] { 4, 5 } };
            int[][] grid2 = new[] { new[] { 5, 7 }, new[] { 3, 4 }, new[] { 9, 8 } };
            int[][] grid3 = new[] { new[] { 5, 7, 6, 8 }, new[] { 3, 4, 2, 1 }, new[] { 9, 8, 4, 6 } };

            MaxOfMinAltitudestest(grid1, 4);
            MaxOfMinAltitudestest(grid2, 4);
            MaxOfMinAltitudestest(grid3, 4);
        }
        private static void ExactlyKdistinctChars()
        {
            string str = "pqpqs";
            Console.WriteLine("Count :" + exact_k_chars(str, 2));

            str = "aabab";
            Console.WriteLine("Count :" + exact_k_chars(str, 3));
        }

        private static int exact_k_chars(string str, int k)
        {
            return most_k_chars(str, k) - most_k_chars(str, k - 1);
        }

        private static int most_k_chars(string str, int k)
        {
            if (str.Length < k) return 0;

            List<string> strColl = new List<string>();
            Dictionary<char, int> frequencyCount = new Dictionary<char, int>();
            int result = 0;

            int start = 0;
            for (int end = 0; end < str.Length; end++)
            {
                if (frequencyCount.ContainsKey(str[end]))
                    frequencyCount[str[end]]++;
                else
                    frequencyCount[str[end]] = 1;

                while (frequencyCount.Count > k)
                {
                    frequencyCount[str[start]]--;

                    if (frequencyCount[str[start]] == 0)
                    {
                        frequencyCount.Remove(str[start]);
                    }
                    start++;
                }
                result += end - start + 1;
            }
            Console.WriteLine(string.Join(" ", strColl));
            return result;
        }

        private static int GetExactlyKdistinctChars(string str, int k)
        {
            if (str.Length < k) return 0;

            List<string> strColl = new List<string>();
            HashSet<char> frequencyCount;
            int result = 0;

            for (int i = 0; i < str.Length; i++)
            {
                int end = i;
                String substr = "";
                frequencyCount = new HashSet<char>();
                while (end < str.Length)
                {
                    substr += str[end];
                    frequencyCount.Add(str[end]);

                    if (frequencyCount.Count > k)
                    {
                        break;
                    }

                    if (substr.Length > 1 && frequencyCount.Count == k)
                    {
                        result++;
                        strColl.Add(substr);
                    }
                    end++;
                }
            }
            Console.WriteLine(string.Join(" ", strColl));

            return result;
        }

        private static void GenerateMatrixDemo()
        {
            int n = 5;
            int[][] result = GenerateMatrix(n);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }

        private static int[][] GenerateMatrix(int n)
        {
            int[][] resultMatrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                resultMatrix[i] = new int[n];
            }
            int left = 0, top = 0;
            int right = n - 1, down = n - 1;
            int count = 1;
            while (left <= right)
            {
                for (int j = left; j <= right; j++)
                {
                    resultMatrix[top][j] = count++;
                }
                top++;
                for (int i = top; i <= down; i++)
                {
                    resultMatrix[i][right] = count++;
                }
                right--;
                for (int j = right; j >= left; j--)
                {
                    resultMatrix[down][j] = count++;
                }
                down--;
                for (int i = down; i >= top; i--)
                {
                    resultMatrix[i][left] = count++;
                }
                left++;
            }
            return resultMatrix;
        }

        private static void favoritegenreDemo()
        {
            Dictionary<string, List<string>> userSongsMaps = new Dictionary<string, List<string>>();
            userSongsMaps.Add("David", new List<string>() { "song1", "song2", "song3", "song4", "song8" });
            userSongsMaps.Add("Emma", new List<string>() { "song5", "song6", "song7" });

            Dictionary<string, List<string>> songGenresMaps = new Dictionary<string, List<string>>();
            songGenresMaps.Add("Rock", new List<string>() { "song1", "song3" });
            songGenresMaps.Add("Dubstep", new List<string>() { "song7" });
            songGenresMaps.Add("Techno", new List<string>() { "song2", "song4" });
            songGenresMaps.Add("Pop", new List<string>() { "song5", "song6" });
            songGenresMaps.Add("Jazz", new List<string>() { "song8", "song9" });
            Dictionary<String, List<String>> favs = GetFavoritegenre(userSongsMaps, songGenresMaps);

            foreach (var item in favs)
            {
                Console.WriteLine(string.Join(" ", item.Key) + "    " + string.Join(" ", item.Value));
            }



            userSongsMaps = new Dictionary<string, List<string>>();
            userSongsMaps.Add("David", new List<string>() { "song1", "song2" });
            userSongsMaps.Add("Emma", new List<string>() { "song3", "song4" });

            songGenresMaps = new Dictionary<string, List<string>>();
            favs = GetFavoritegenre(userSongsMaps, songGenresMaps);

            foreach (var item in favs)
            {
                Console.WriteLine(string.Join(" ", item.Key) + "    " + string.Join(" ", item.Value));
            }


        }

        public static Dictionary<String, List<String>> GetFavoritegenre(Dictionary<String, List<String>> userMap, Dictionary<String, List<String>> genreMap)
        {
            //Time: O((S + G) + U * (S + G)) => O((U + 1) * (S + G)) => O(U * (S + G))
            //Space: O(S + G + U * G) => O(S + U * G)
            //Where S = total number of songs, G = total number of genres, U = total number of users
            Dictionary<String, List<String>> favsResult = new Dictionary<string, List<string>>();
            Dictionary<String, String> songstogenre = new Dictionary<String, String>();

            if (userMap == null || userMap.Count == 0) return favsResult;

            /*Populating Users with empty Favourite Genres*/
            foreach (var item in userMap.Keys)
            {
                favsResult[item] = new List<string>();
            }
            if (genreMap == null || genreMap.Count == 0) return favsResult;


            //Populating the Song and Genre in Map for Easy Access
            foreach (var genre in genreMap.Keys)
            {
                List<string> songs = genreMap[genre];
                foreach (string song in songs)
                {
                    songstogenre[song] = genre;
                }
            }


            /*For Every user get the songs listened and get the genres and No Of Times Listened*/
            Dictionary<String, int> genreFrequency;
            int maxFrequency = 0;
            foreach (var user in userMap.Keys)
            {
                genreFrequency = new Dictionary<string, int>();
                maxFrequency = 0;

                /*populate genreToFrequency map that is Genre to Number of times heard*/
                List<string> userSongs = userMap[user];
                foreach (var song in userSongs)
                {
                    if (songstogenre.Count > 0)
                    {
                        string genre = songstogenre[song];
                        if (!string.IsNullOrEmpty(genre))
                        {
                            if (genreFrequency.ContainsKey(genre))
                                genreFrequency[genre]++;
                            else
                                genreFrequency[genre] = 1;

                            maxFrequency = Math.Max(genreFrequency[genre], maxFrequency);
                            if (maxFrequency < genreFrequency[genre])
                            {
                                favsResult[user].Clear();
                                favsResult[user].Add(genre);
                            }

                            if (maxFrequency == genreFrequency[genre])
                            {
                                favsResult[user].Add(genre);
                            }
                        }
                    }
                }

                ///*Add all genres that are equal to Favourite Genre Count*/
                //foreach (var genreKey in genreFrequency.Keys)
                //{
                //    if (genreFrequency[genreKey] == maxFrequency)
                //    {
                //        favsResult[user].Add(genreKey);
                //    }
                //}
            }

            return favsResult;
        }

        private static void OptimalUtilization()
        {
            List<List<int>> a = new List<List<int>>() { new List<int>() { 1, 2 }, new List<int>() { 2, 4 }, new List<int>() { 3, 6 } };
            List<List<int>> b = new List<List<int>>() { new List<int>() { 1, 2 } };
            int target = 7;
            List<List<int>> optimalSolution = GetOptimalSolution(a, b, target);
            PrintOptialSolution(optimalSolution);


            a = new List<List<int>>() { new List<int>() { 1, 3 }, new List<int>() { 4, 10 }, new List<int>() { 3, 7 }, new List<int>() { 2, 5 } };
            b = new List<List<int>>() { new List<int>() { 4, 5 }, new List<int>() { 2, 3 }, new List<int>() { 3, 4 }, new List<int>() { 1, 2 }, };
            target = 10;
            optimalSolution = GetOptimalSolution(a, b, target);
            PrintOptialSolution(optimalSolution);

            a = new List<List<int>>() { new List<int>() { 1, 8 }, new List<int>() { 2, 7 }, new List<int>() { 3, 14 } };
            b = new List<List<int>>() { new List<int>() { 1, 5 }, new List<int>() { 2, 10 }, new List<int>() { 3, 14 } };
            target = 20;
            optimalSolution = GetOptimalSolution(a, b, target);
            PrintOptialSolution(optimalSolution);

            a = new List<List<int>>() { new List<int>() { 1, 8 }, new List<int>() { 2, 15 }, new List<int>() { 3, 9 } };
            b = new List<List<int>>() { new List<int>() { 1, 8 }, new List<int>() { 2, 11 }, new List<int>() { 3, 12 } };
            target = 20;
            optimalSolution = GetOptimalSolution(a, b, target);
            PrintOptialSolution(optimalSolution);

            a = new List<List<int>>() { new List<int>() { 1, 5 }, new List<int>() { 2, 5 } };
            b = new List<List<int>>() { new List<int>() { 1, 5 }, new List<int>() { 2, 5 } };
            target = 10;
            optimalSolution = GetOptimalSolution(a, b, target);
            PrintOptialSolution(optimalSolution);
        }

        private static List<List<int>> GetOptimalSolution(List<List<int>> a, List<List<int>> b, int target)
        {
            // Sorting O(MlongM + nLongN)
            // O(M+N)
            // O(kLogK) where K is the longes Input Array.
            List<List<int>> result = new List<List<int>>();
            if (a == null || a.Count == 0) return result;
            if (b == null || a.Count == 0) return result;
            //PrintOptialSolution(a);
            //PrintOptialSolution(b);

            a.Sort((x, y) => x[1] - y[1]);
            b.Sort((x, y) => x[1] - y[1]);
            //PrintOptialSolution(a);
            //PrintOptialSolution(b);

            int aSize = a.Count, bSize = b.Count, uMax = int.MinValue;
            int i = 0, j = bSize - 1;

            while (i < aSize && j >= 0)
            {
                int sum = a[i][1] + b[j][1];
                if (sum > target)
                    j--;
                else
                {
                    if (sum >= uMax)
                    {
                        if (sum > uMax)
                        {
                            // got the new result.
                            uMax = sum;
                            result.Clear();
                        }
                        result.Add(new List<int>() { a[i][0], b[j][0] });
                        int index = j - 1;
                        while (index >= 0 && b[index][1] == b[index + 1][1])
                        {
                            result.Add(new List<int>() { a[i][0], b[index--][0] });
                        }
                    }
                    i++;
                }
            }
            return result;
        }

        private static void PrintOptialSolution(List<List<int>> optimalSolution)
        {
            Console.WriteLine();
            foreach (var item in optimalSolution)
            {
                Console.Write(string.Join(" ", item) + "    ");
            }
            Console.WriteLine();
        }

        private static void TwoSumBest()
        {
            int[] inputs = { 2, 7, 8, 6, 4, 10, 13 };
            int target = 9;
            List<int> result = GetBestSum(inputs, target);
        }

        private static List<int> GetBestSum(int[] inputs, int target)
        {
            int[] result = new int[2];
            if (inputs.Length == 0) return result.ToList();
            Dictionary<int, int> track = new Dictionary<int, int>();
            int size = inputs.Length;

            for (int i = 0; i < size; i++)
            {
                int oPair = target - inputs[i];
                if (track.ContainsKey(oPair))
                {
                    int cPair = inputs[i];
                    if (Math.Max(cPair, oPair) > Math.Max(result[0], result[1]))
                    {
                        result[0] = oPair;
                        result[1] = cPair;
                    }
                }
                track.Add(inputs[i], i);
            }
            return result.ToList();
        }

        private static void BSTNodesDistance()
        {

            int[] nums = { 2, 1, 3 };
            int node1 = 1;
            int node2 = 4;
            Console.WriteLine(string.Format("{0} :{1} :{2}", -1, GetBSTDistance(nums, node1, node2), "Should return -1 when either one or two given nodes are not in bst"));

            nums = new int[] { };
            node1 = 1;
            node2 = 4;
            Console.WriteLine(string.Format("{0} :{1} :{2}", -1, GetBSTDistance(nums, node1, node2),
                               "Should return -1 when given numbers are empty"));

            nums = new int[] { 2, 1, 3 };
            node1 = 1;
            node2 = 3;
            Console.WriteLine(string.Format("{0} :{1} :{2}", 2, GetBSTDistance(nums, node1, node2),
                              "Should return correct distance between nodes in bst"));

            nums = new int[] { 4, 6, 9, 11, 1, 2, 5, 7 };
            node1 = 1;
            node2 = 7;
            Console.WriteLine(string.Format("{0} :{1} :{2}", 4, GetBSTDistance(nums, node1, node2),
                             "Should return correct distance between nodes in bst"));

            nums = new int[] { 24, 6, 2, 22, 30, 25, 20, 15, 7, 8, 10, 9, 1 };
            node1 = 9;
            node2 = 25;
            Console.WriteLine(string.Format("{0} :{1} :{2}", 10, GetBSTDistance(nums, node1, node2),
                             "Should return correct distance between nodes in bst"));

            nums = new int[] { 24, 6, 2, 22, 30, 25, 20, 15, 7, 8, 10, 9, 1 };
            node1 = 1;
            node2 = 9;
            Console.WriteLine(string.Format("{0} :{1} :{2}", 9, GetBSTDistance(nums, node1, node2),
                             "Should return correct distance between nodes in bst"));


        }

        private static int GetBSTDistance(int[] nums, int node1, int node2)
        {
            TreeNode root = BuildBST(nums, node1, node2);
            if (root == null) return -1;
            TreeNode LCA = GetLCA(root, node1, node2);
            if (LCA == null) return -1;
            return GetDistance(LCA, node1) + GetDistance(LCA, node2);
        }

        private static int GetDistance(TreeNode SourceNode, int targetNodeVal)
        {
            if (SourceNode.Val == targetNodeVal) return 0;
            TreeNode node = SourceNode.Left;
            if (SourceNode.Val < targetNodeVal)
                node = SourceNode.Right;
            return 1 + GetDistance(node, targetNodeVal);
        }

        private static TreeNode GetLCA(TreeNode root, int node1, int node2)
        {
            //if (root == null) return null;
            //if (node1 > root.Val && node2 > root.Val)
            //    return GetLCA(root.Right, node1, node2);
            //else if (node1 < root.Val && node2 < root.Val)
            //    return GetLCA(root.Left, node1, node2);
            //return root;

            while (true)
            {
                if (node1 > root.Val && node2 > root.Val)
                {
                    root = root.Right;
                }
                else if (node1 < root.Val && node2 < root.Val)
                {
                    root = root.Left;
                }
                else
                    return root;
            }
        }

        private static TreeNode BuildBST(int[] nums, int node1, int node2)
        {
            TreeNode root = null;
            bool node1Found = false;
            bool node2Found = false;
            foreach (var currVal in nums)
            {
                if (currVal == node1) node1Found = true;
                if (currVal == node2) node2Found = true;
                TreeNode node = new TreeNode(currVal);
                root = InsertBinarySearchTree(root, currVal);
            }

            if (!node1Found || !node2Found) return null;
            return root;
        }

        public static TreeNode InsertBinarySearchTree(TreeNode root, int currVal)
        {
            if (root == null) return new TreeNode(currVal);
            TreeNode currNode = root;
            while (true)
            {
                if (currVal > currNode.Val)
                {
                    if (currNode.Right != null)
                        currNode = currNode.Right;
                    else
                    {
                        currNode.Right = new TreeNode(currVal);
                        break;
                    }
                }
                else
                {
                    if (currNode.Left != null)
                        currNode = currNode.Left;
                    else
                    {
                        currNode.Left = new TreeNode(currVal);
                        break;
                    }
                }
            }
            return root;
        }

        private static void KFrequentlyMentionedKeywords()
        {
            string[] keywords = { "anacell", "cetracular", "betacellular" };
            string[] reviews = { "Anacell provides the best services in the city",
                                  "betacellular has awesome services",
                                  "Best services provided by anacell, everyone should use anacell"};
            List<string> result = GetFrequentWords(2, keywords, reviews);

            Console.WriteLine();
            Console.WriteLine(string.Join(" ", result));
            Console.WriteLine();


            string[] keywords1 = { "anacell", "betacellular", "cetracular", "deltacellular", "eurocell" };
            string[] reviews1 = {  "I love anacell Best services; Best services provided by anacell",
                                      "betacellular has great services",
                                      "deltacellular provides much better services than betacellular",
                                      "cetracular is worse than anacell",
                                      "Betacellular is better than deltacellular."};
            List<string> result1 = GetFrequentWords(2, keywords1, reviews1);

            Console.WriteLine();
            Console.WriteLine(string.Join(" ", result1));
            Console.WriteLine();
        }

        private static List<string> GetFrequentWords(int k, string[] keywords, string[] reviews)
        {
            Dictionary<string, int> frequency = new Dictionary<string, int>();

            foreach (var item in keywords)
            {
                frequency.Add(item.ToLower(), 0);
            }

            foreach (var review in reviews)
            {
                foreach (var reviewWord in review.ToLower().Split(' '))
                {
                    if (frequency.ContainsKey(reviewWord))
                    {
                        frequency[reviewWord] += 1;
                    }
                }
            }

            List<string> keyCollection = new List<string>(frequency.Keys);
            Console.WriteLine("before    :" + string.Join(" ", keyCollection));
            keyCollection.Sort((a, b) => frequency[a] == frequency[a] ? b.CompareTo(a) : frequency[b] - frequency[a]);
            Console.WriteLine("after     :" + string.Join(" ", keyCollection));
            return keyCollection.GetRange(0, k);
        }

        private static void AmazonFreshPromotion()
        {
            String[][] codeList1 = new[] {
                                    new []  { "apple", "apple" },
                                    new []  { "banana", "anything", "banana" } };
            String[] shoppingCart1 = new[] { "orange", "apple", "apple", "banana", "orange", "banana" };

            String[][] codeList2 = new[] {new [] { "apple", "apple" },
                                          new [] { "banana", "anything", "banana" } };
            String[] shoppingCart2 = new[] { "banana", "orange", "banana", "apple", "apple" };

            String[][] codeList3 = { new [] { "apple", "apple" },
                                        new [] { "banana", "anything", "banana" } };
            String[] shoppingCart3 = { "apple", "banana", "apple", "banana", "orange", "banana" };

            String[][] codeList4 = new[] {
                                        new [] { "apple", "apple" },
                                        new [] { "apple", "apple", "banana" } };
            String[] shoppingCart4 = { "apple", "apple", "apple", "banana" };

            String[][] codeList5 = new[] {
                                new [] { "apple", "apple" },
                                new [] { "banana", "anything", "banana" } };
            String[] shoppingCart5 = { "orange", "apple", "apple", "banana", "orange", "banana" };

            String[][] codeList6 = new[] {
                                    new [] { "apple", "apple" },
                                    new [] { "banana", "anything", "banana" } };
            String[] shoppingCart6 = { "apple", "apple", "orange", "orange", "banana", "apple", "banana", "banana" };

            String[][] codeList7 = new[] {
                                        new[] { "anything", "apple" },
                                        new [] { "banana", "anything", "banana" } };
            String[] shoppingCart7 = { "orange", "grapes", "apple", "orange", "orange", "banana", "apple", "banana", "banana" };

            Console.WriteLine(solve(codeList1, shoppingCart1));
            Console.WriteLine(solve(codeList2, shoppingCart2));
            Console.WriteLine(solve(codeList3, shoppingCart3));
            Console.WriteLine(solve(codeList4, shoppingCart4));
            Console.WriteLine(solve(codeList5, shoppingCart5));
            Console.WriteLine(solve(codeList6, shoppingCart6));
            Console.WriteLine(solve(codeList7, shoppingCart7));
        }

        private static int solve(string[][] codeList, string[] shoppingCart)
        {
            if (codeList == null || codeList.Length == 0)
                return 1;
            if (shoppingCart == null || shoppingCart.Length == 0)
                return 0;

            int cartSize = shoppingCart.Length;
            int i = 0, j = 0;
            for (int cartIndex = 0; cartIndex < cartSize; cartIndex++)
            {
                if (codeList[i][j] == shoppingCart[cartIndex] || codeList[i][j] == "anything")
                {
                    j++;
                    if (j == codeList[i].Length)
                    {
                        i++;
                        j = 0;
                    }
                    if (i == codeList.Length)
                        return 1;
                }
                else
                {
                    j = codeList[i][0] == "anything" ? 1 : 0;
                }
            }
            return 0;
        }

        private static void RottenOranges()
        {
            int[][] grid = new[] {
                new[] { 2,1,1},
                new[] { 1,1,0},
                new[] { 0,1,1},
            };

            Console.WriteLine("mimimum hours :" + GetMinminutes(grid));
        }

        private static int GetMinminutes(int[][] grid)
        {
            int rows = grid.Length;
            if (rows == 0) return 0;

            List<int[]> dirs = new List<int[]>() { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } };
            int minutes = 0, cols = grid[0].Length, freshOrange = 0;
            Queue<Cordinate> rottenQueue = new Queue<Cordinate>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2)
                        rottenQueue.Enqueue(new Cordinate(i, j));
                    if (grid[i][j] == 1)
                        freshOrange++;
                }
            }
            Console.WriteLine("Total rottenQueue :{0}, and freshOrange :{1}", rottenQueue.Count, freshOrange);

            while (rottenQueue.Count > 0 && freshOrange > 0)
            {
                minutes++;
                int qSize = rottenQueue.Count;
                for (int i = 0; i < qSize; i++)
                {
                    Cordinate cor = rottenQueue.Dequeue();
                    int x = cor.x;
                    int y = cor.y;

                    PrintMatrix(grid);
                    foreach (var dir in dirs)
                    {
                        int xNew = x + dir[0];
                        int yNew = y + dir[1];

                        if (IsValidOrage(grid, xNew, yNew, rows, cols))
                        {
                            grid[xNew][yNew] = 2;
                            rottenQueue.Enqueue(new Cordinate(xNew, yNew));
                            freshOrange--;
                        }
                    }
                }
            }
            return freshOrange == 0 ? minutes : -1;
        }

        private static bool IsValidOrage(int[][] grid, int x, int y, int rows, int cols)
        {
            return x >= 0 && y >= 0 && x < rows && y < cols && grid[x][y] == 1;
        }

        private static void ZombieInMatrix()
        {
            int[][] grid = new[] {
                new[] { 0, 1, 1, 0, 1},
                new[] { 0, 1, 0, 1, 0},
                new[] { 0, 0, 0, 0, 1},
                new[] { 0, 1, 0, 0, 0},
            };

            Console.WriteLine("mimimum hours :" + GetMinHours(grid));
        }

        private static int GetMinHours(int[][] grid)
        {
            int rows = grid.Length;
            if (rows == 0) return 0;
            int cols = grid[0].Length;
            int hours = 0;

            List<int[]> dirs = new List<int[]> { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

            Queue<Cordinate> zomQueue = new Queue<Cordinate>();
            int humCount = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                        zomQueue.Enqueue(new Cordinate(i, j));
                    else
                        humCount++;
                }
            }

            Console.WriteLine("Total zombie :{0}, and human :{1}", zomQueue.Count, humCount);

            while (zomQueue.Count > 0 && humCount > 0)
            {
                hours++;
                int qSize = zomQueue.Count;
                for (int i = 0; i < qSize; i++)
                {
                    Cordinate cor = zomQueue.Dequeue();
                    int x = cor.x;
                    int y = cor.y;

                    PrintMatrix(grid);
                    foreach (var dir in dirs)
                    {
                        int xNew = x + dir[0];
                        int yNew = y + dir[1];

                        if (IsValidHuman(grid, xNew, yNew, rows, cols))
                        {
                            grid[xNew][yNew] = 1;
                            zomQueue.Enqueue(new Cordinate(xNew, yNew));
                            humCount--;
                        }
                    }
                }
            }

            return humCount == 0 ? hours : -1;
        }

        private static bool IsValidHuman(int[][] grid, int x, int y, int rows, int cols)
        {
            return x >= 0 && y >= 0 && x < rows && y < cols && grid[x][y] == 0;
        }

        private static void TreasureIslandII()
        {
            char[][] grid = new[] {
                new[] { 'S', 'O', 'O', 'S', 'S'},
                new[] { 'D', 'O', 'D', 'O', 'D'},
                new[] { 'O', 'O', 'O', 'O', 'X'},
                new[] { 'X', 'D', 'D', 'O', 'O'},
                new[] { 'X', 'D', 'D', 'D', 'O'},
            };

            Console.WriteLine("No of shorted Path :" + TreasureIslandIIDemo(grid));
        }

        private static int TreasureIslandIIDemo(char[][] grid)
        {
            int rows = grid.Length;
            if (rows == 0) return 0;

            int cols = grid[0].Length, steps = 0;
            bool[,] visited = new bool[rows, cols];
            int[][] dirs = new[] { new[] { 1, 0 }, new[] { 0, 1 }, new[] { -1, 0 }, new[] { 0, -1 } };

            Queue<Cordinate> queue = new Queue<Cordinate>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 'S')
                    {
                        queue.Enqueue(new Cordinate(i, j));
                        visited[i, j] = true;
                    }
                }
            }

            // No loop from all the starting points. 
            while (queue.Count > 0)
            {
                steps++;
                int qSize = queue.Count;
                for (int i = 0; i < qSize; i++)
                {
                    Cordinate cor = queue.Dequeue();
                    int x = cor.x;
                    int y = cor.y;
                    PrintMatrix(visited);

                    foreach (var dir in dirs)
                    {
                        int xNew = x + dir[0];
                        int yNew = y + dir[1];
                        if (isSafe(grid, visited, xNew, yNew, rows, cols))
                        {
                            if (grid[xNew][yNew] == 'X') return steps;
                            visited[xNew, yNew] = true;
                            queue.Enqueue(new Cordinate(xNew, yNew));
                        }
                    }
                }
            }

            return -1;
        }

        private static bool isSafe(char[][] grid, bool[,] visited, int i, int j, int rows, int cols)
        {
            return i >= 0 && j >= 0 && i < rows && j < cols && grid[i][j] != 'D' && visited[i, j] != true;
        }

        private static void TreasureIslandDemo()
        {
            char[][] grid = new char[4][] {
                new char[] { 'O', 'O', 'O', 'O' },
                new char[] { 'D', 'O', 'D', 'O'},
                new char[] { 'O', 'O', 'O', 'O' },
                new char[] { 'X', 'D', 'D', 'O' }
            };

            Console.WriteLine("No of steps :" + TreasureIslandBFS(grid));
        }

        private static int TreasureIsland(char[][] grid)
        {
            int rows = grid.Length;
            int steps = 0;
            if (rows == 0) return steps;

            int cols = grid[0].Length;
            int[][] directions = new[] { new[] { 1, 0 }, new[] { 0, 1 }, new[] { -1, 0 }, new[] { 0, -1 } };
            bool[,] visited = new bool[rows, cols];
            visited[0, 0] = true;
            TreasureIslandHelper(grid, visited, 0, 0, rows, cols, ref steps, 0, directions);
            return steps;
        }

        private static void TreasureIslandHelper(char[][] grid, bool[,] visited, int x, int y, int rows, int cols, ref int steps, int levelDistance, int[][] directions)
        {
            if (grid[x][y] == 'X')
            {
                steps = Math.Max(steps, levelDistance);
                return;
            }

            visited[x, y] = true;

            foreach (var dir in directions)
            {
                if (isValid(grid, visited, x + dir[0], y + dir[1], rows, cols))
                {
                    TreasureIslandHelper(grid, visited, x + dir[0], y + dir[1], rows, cols, ref steps, levelDistance + 1, directions);
                }
            }
        }

        private static int TreasureIslandBFS(char[][] grid)
        {
            int rows = grid.Length, steps = 0;
            if (rows == 0) return steps;

            int cols = grid[0].Length;
            Queue<Cordinate> queue = new Queue<Cordinate>();
            queue.Enqueue(new Cordinate(0, 0));
            bool[,] visited = new bool[rows, cols];
            visited[0, 0] = true;
            int[][] directions = new[] { new[] { 1, 0 }, new[] { 0, 1 }, new[] { -1, 0 }, new[] { 0, -1 } };

            //Start BFS
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    Cordinate cor = queue.Dequeue();
                    int x = cor.x;
                    int y = cor.y;
                    PrintMatrix(visited);
                    foreach (var dir in directions)
                    {
                        int newX = x + dir[0];
                        int newY = y + dir[1];
                        if (isValid(grid, visited, newX, newY, rows, cols))
                        {
                            if (grid[newX][newY] == 'X') return steps;
                            visited[newX, newY] = true;
                            queue.Enqueue(new Cordinate(newX, newY));
                        }
                    }
                }
                steps++;
            }

            return -1;
        }

        public static void PrintMatrix(int[][] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintMatrix(bool[,] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }

        private static bool isValid(char[][] grid, bool[,] visited, int newX, int newY, int rows, int cols)
        {
            return newX >= 0 && newY >= 0 && newX < rows && newY < cols && grid[newX][newY] != 'D' && visited[newX, newY] != true;
        }

        private static void TwoSumUniquePairs()
        {
            Dictionary<int[], int> inputs = new Dictionary<int[], int>();
            inputs.Add(new int[] { 1, 1, 2, 45, 46, 46 }, 47);
            inputs.Add(new int[] { 1, 1 }, 2);
            inputs.Add(new int[] { 1, 5, 1, 5 }, 6);

            foreach (var item in inputs)
            {
                Console.WriteLine();
                List<List<int>> results = GetUniquePair(item.Key, item.Value);
                if (results.Count > 0)
                {
                    Console.WriteLine("There are {0} pair.", results.Count);

                    foreach (var output in results)
                    {
                        Console.WriteLine(string.Join(" ,", output));
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("There is no such pair.");
                }
            }
        }

        private static List<List<int>> GetUniquePair(int[] arr, int target)
        {
            List<List<int>> resultSet = new List<List<int>>();
            HashSet<int> track = new HashSet<int>();
            HashSet<int> visited = new HashSet<int>();

            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                int oPair = target - arr[i];
                if (track.Contains(oPair))
                {
                    if (!visited.Contains(oPair))
                    {
                        List<int> temp = new List<int>() { oPair, arr[i] };
                        resultSet.Add(temp);
                        visited.Add(oPair);
                    }
                }
                track.Add(arr[i]);
            }

            return resultSet;
        }
    }


}
