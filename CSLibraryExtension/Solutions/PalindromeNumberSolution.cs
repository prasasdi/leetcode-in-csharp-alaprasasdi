using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            return x == revertedNumber || x == revertedNumber / 10;
        }
    }
}
