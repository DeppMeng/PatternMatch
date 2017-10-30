using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatch
{
    static public class Match
    {
        static public bool Match_1(string pattern, string value)
        {
            bool flag = true;
            int count = 0;
            if (pattern == "")
                return true;
            for (int i = 0; i < value.Length; i++)
            {
                count = 0;
                flag = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (j == 0)
                    {
                        if (pattern[j] == '*')
                            return Match_1(pattern.Substring(j + 1, pattern.Length - j - 1), value.Substring(i + j, value.Length - i - j));
                        if (pattern[j] == '+')
                            return Match_1(pattern.Substring(j + 1, pattern.Length - j - 1), value.Substring(i + j + 1, value.Length - i - j - 1));
                        if (pattern[j] == '\\')
                        {
                            count++;
                            continue;
                        }
                        if (pattern[j] != value[i + j] && pattern[j] != '?')
                            break;
                    }
                    else
                    {

                        if (i + j - count == value.Length && ((pattern[j] != '*') || (pattern[j] == '*' && pattern[j - 1] == '\\')))
                            return false;
                        if (pattern[j] == '\\' && ((pattern[j - 1] != '\\') || (pattern[j - 1] == '\\' && flag == false)))
                        {
                            count++;
                            continue;
                        }
                        if (pattern[j - 1] != '\\' || (pattern[j - 1] == '\\' && flag == false))
                        {
                            if (j >= 1 && pattern[j - 1] == '\\' && flag == false)
                                flag = true;
                            if (pattern[j] == '*')
                                return Match_1(pattern.Substring(j + 1, pattern.Length - j - 1), value.Substring(i + j - count, value.Length - i - j + count));
                            if (pattern[j] == '+')
                                return Match_1(pattern.Substring(j + 1, pattern.Length - j - 1), value.Substring(i + j + 1 - count, value.Length - i - j - 1 + count));
                            if (pattern[j] != value[i + j - count] && pattern[j] != '?')
                                break;
                        }
                        else
                        {
                            flag = false;
                            if (pattern[j] != value[i + j - count])
                                break;
                        }
                    }
                    if (j == pattern.Length - 1)
                        return true;
                }
            }
            return false;
        }
    }
}
