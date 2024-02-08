using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLibraryExtension.Solutions
{
    public class PalindromeNumberSolution
    {
        public static bool IsPalindrome(int x)
        {
            List<int> strings = new List<int>();

            // O(2)
            if (x < 0) return false;
            if (x == 0) return true;
            
            // O(n)
            while (x > 0)
            {
                int element = x % 10;
                x /= 10;
                strings.Add(element);
            }

            strings.TrimExcess();

            // O(n)
            for (int i = 0, k = strings.Count - 1; i <= k; i++, k--)
            {
                if (strings[i] != strings[k]) return false;
            }
            return true;
        }
    }
}
