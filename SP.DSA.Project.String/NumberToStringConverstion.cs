using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.String
{
    public class NumberToStringConverstion
    {
        private Dictionary<int, string> map = new Dictionary<int, string>() {
            {0, "Zero"},
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},

            {10, "Ten"},
            {11, "Eleven"},
            {12, "Tweleve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Ninteen"},

            {20, "Twenty"},
            {30, "Thirty"},
            {40, "Fourty"},
            {50, "Fifty"},
            {60, "Sixty"},
            {70, "Seventy"},
            {80, "Eighty"},
            {90, "Ninty"},
        };

        public void NumberToStringDemo()
        {
            int number = 1234567891;
            Console.WriteLine(string.Format("{0} to string :{1}", number, GetStringForNumber(number)));
            number = 100;
            Console.WriteLine(string.Format("{0} to string :{1}", number, GetStringForNumber(number)));
            number = 48;
            Console.WriteLine(string.Format("{0} to string :{1}", number, GetStringForNumber(number)));
            number = 11;
            Console.WriteLine(string.Format("{0} to string :{1}", number, GetStringForNumber(number)));
            number = 19;
            Console.WriteLine(string.Format("{0} to string :{1}", number, GetStringForNumber(number)));
            number = 10;
            Console.WriteLine(string.Format("{0} to string :{1}", number, GetStringForNumber(number)));
            number = 77;
            Console.WriteLine(string.Format("{0} to string :{1}", number, GetStringForNumber(number)));
            number = 99;
            Console.WriteLine(string.Format("{0} to string :{1}", number, GetStringForNumber(number)));
        }

        public string GetStringForNumber(int number)
        {
            StringBuilder sb = new StringBuilder();
            int[] redix = { 1000000000, 1000000, 1000, 100 };
            string[] dexWords = { "Billion", "Million", "Thousand", "Hundred" };
            for (int i = 0; i < redix.Length; i++)
            {
                int count = number / redix[i];
                if (count == 0) continue;
                sb.Append(ThreeDigit(count) + " ");
                sb.Append(dexWords[i] + " ");
                number = number % redix[i];
            }
            if (number != 0)
                sb.Append(TwoDigit(number));
            return sb.ToString();
        }

        private string ThreeDigit(int number)
        {
            int hundred = number / 100;
            int rest = number - hundred * 100;
            string result = " ";
            if (hundred != 0 && rest != 0)
                result = map[hundred] + " Hundred " + TwoDigit(rest);
            else if (hundred == 0 && rest != 0)
                result = TwoDigit(rest);
            else if (hundred != 0 && rest == 0)
                result = map[hundred] + " Hundred ";
            return result;
        }

        private string TwoDigit(int number)
        {
            if (number == 0)
                return "";
            else if (number < 10)
                return map[number];
            else if (number < 20)
                return map[number];
            else
            {
                int mod = number % 10;
                int rest = number - mod;
                if (mod != 0)
                    return map[rest] + " " + map[mod];
                else
                    return map[rest];
            }
        }

        public string GetStringForNumberSolution1(int number)
        {
            if (number == 0)
                return map[0];
            string result = "";

            int billion = number / 1000000000;
            int million = (number - billion * 1000000000) / 1000000;
            int thousand = (number - billion * 1000000000 - million * 1000000) / 1000;
            int rest = number - billion * 1000000000 - million * 1000000 - thousand * 1000;

            if (billion != 0)
            {
                if (string.IsNullOrEmpty(result))
                    result += " ";
                result += ThreeDigit(billion) + " Billion ";
            }
            if (million != 0)
            {
                if (string.IsNullOrEmpty(result))
                    result += " ";
                result += ThreeDigit(million) + " Million ";
            }
            if (thousand != 0)
            {
                if (string.IsNullOrEmpty(result))
                    result += " ";
                result += ThreeDigit(thousand) + " Thousand ";
            }
            if (rest != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += ThreeDigit(rest);
            }
            return result;
        }
    }
}
