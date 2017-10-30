using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternMatch;

namespace PatternMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "hel\\\\*o";
            string value = "hel\\o";
            Console.WriteLine(Match.Match_1(pattern, value));
            //Console.WriteLine('\\');
            Console.Read();

        }
        
        //static bool Match_1(string pattern, string value)
        //{
        //    int count = 0;
        //    if (pattern == "")
        //        return true;
        //    for (int i = 0; i < value.Length; i++)
        //    {
        //        for (int j = 0; j < pattern.Length; j++)
        //        {
        //            if (i + j - count == value.Length && (pattern[j] != '*') && (pattern[j] == '*' && pattern[j-1] ==  '\\'))
        //                return false;
        //            if (pattern[j] == '\\')
        //            {
        //                count++;
        //                continue;
        //            }
        //            if (j == 0 || j >= 1 && pattern[j - 1] != '\\')
        //            {
        //                if (pattern[j] == '*')
        //                    return Match_1(pattern.Substring(j + 1, pattern.Length - j - 1), value.Substring(i + j - count, value.Length - i - j + count));
        //                if (pattern[j] == '+')
        //                    return Match_1(pattern.Substring(j + 1, pattern.Length - j - 1), value.Substring(i + j + 1 - count, value.Length - i - j - 1 + count));
        //                if (pattern[j] != value[i + j - count] && pattern[j] != '?')
        //                    break;
        //            }
        //            else
        //            {
        //                if (pattern[j] != value[i + j - count])
        //                    break;
        //            }
        //            if (j == pattern.Length - 1)
        //                return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
