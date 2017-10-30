using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatch
{
    //a method to do pattern match. If matched, returns true, else returns false
    //'*' represents any string(include empty string)
    //'+' represents any string except ampty string
    //'?' represents any character
    //'\*', '\+', '\?', '\\' represent '*', '+', '?' and '\'
    static public class Match
    {
        static public bool Match_1(string pattern, string value)
        {
            //the state of the '\', is it the first one or the second one
            bool flag = true;
            //the number of '\', which is equal to the offset between pattern and value
            int count = 0;
            //if the pattern is null
            if (pattern == "")
                return true;
            for (int i = 0; i < value.Length; i++)
            {
                //reset '\' number
                count = 0;
                //reset '\' state
                flag = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (j == 0)
                    {
                        //if we meet '*', the problem is equivalent to either the rest of value contains the rest of pattern
                        if (pattern[j] == '*')
                            return Match_1(pattern.Substring(j + 1, pattern.Length - j - 1), value.Substring(i + j, value.Length - i - j));
                        //similar to '*'
                        if (pattern[j] == '+')
                            return Match_1(pattern.Substring(j + 1, pattern.Length - j - 1), value.Substring(i + j + 1, value.Length - i - j - 1));
                        //'ignore' this charater and go on
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
                        //reached the end of value string
                        if (i + j - count == value.Length && ((pattern[j] != '*') || (pattern[j] == '*' && pattern[j - 1] == '\\')))
                            return false;
                        //if the '\' is 'usable'(not the second '\' represent the character '\')
                        if (pattern[j] == '\\' && ((pattern[j - 1] != '\\') || (pattern[j - 1] == '\\' && flag == false)))
                        {
                            count++;
                            continue;
                        }
                        //similar to j == 0 situation
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
                    //reached the end of pattern, matched
                    if (j == pattern.Length - 1)
                        return true;
                }
            }
            return false;
        }
    }
}
