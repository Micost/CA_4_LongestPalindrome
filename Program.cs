using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_4_LongestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "bb";
            Solution s1 = new Solution();
            Console.Write(s1.LongestPalindrome(input));
            var a= Console.ReadKey();
        }
    }
    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            int r_even = 0;
            int r_odd = 0;
            int Max_R = 1;
            int Max_Idx = 0;
            for (int i= 1; i < s.Length; i++)
            {
                r_even = LongestRadus(s, i, true);
                r_odd = LongestRadus(s, i, false);
                int even_length = 2 * r_even;
                int odd_length = 1 + 2 * r_odd;
                if ( Max_R < even_length )
                {
                    Max_R = even_length;
                    Max_Idx = i - r_even;
                }
                if ( Max_R < odd_length )
                {
                    Max_R = odd_length;
                    Max_Idx = i - r_odd;
                }
            }
            return s.Substring(Max_Idx, Max_R);
        }
        public int LongestRadus(string s, int idx, Boolean isEven)
        {
            int result = 0;
            if (isEven)
            {
                if (idx == 0 || s[idx] != s[idx - 1])
                {
                    return result;
                }
                else
                {
                    for ( int i = 1; i<= idx && i+idx <= s.Length; i++ )
                    {
                        if (s[idx - i ] != s[idx + i -1])
                        {
                            return i - 1;
                        }
                        else
                        {
                            result = i;
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i <= idx && i + idx < s.Length; i++)
                {
                    if (s[idx - i] != s[idx + i])
                    {
                        return i - 1;
                    }
                    else
                    {
                        result = i;
                    }
                }
            }
            return result; 
        }
    }
}
