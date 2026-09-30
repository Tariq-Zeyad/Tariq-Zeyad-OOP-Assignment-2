namespace SRP__Patterns.LeetCode._1456_MaxVowelsInSubstring
{
    public class Solution
    {
        public int MaxVowels(string s, int k)
        {
            int current = 0;
            int i = 0;

            while (i < k)
            {
                if (IsVowel(s[i]))
                    current++;

                i++;
            }

            int maximum = current;

            while (i < s.Length)
            {
                if (IsVowel(s[i]))
                    current++;

                if (IsVowel(s[i - k]))
                    current--;

                if (current > maximum)
                    maximum = current;

                i++;
            }

            return maximum;
        }
        private bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i'|| c == 'o'|| c == 'u';
        }
    }
}
