using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediff_Test
{
    class palindrome
    {
        string _word = null;

        public palindrome(string word)
        {
            _word = word.ToLower();
        }
        public bool checkIsPalindrome()
        {
            bool ispalindrome = true;
            int j = _word.Length-1;
            for (int i = 0; i < _word.Length; i++)
            {
                if (_word[i] != _word[j])
                    return false;
                j--;
            }
            return ispalindrome;
        }
    }
}
