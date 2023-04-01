using System;

namespace CalcModel
{
    public static class Calc
    {
        public static int Sum(string str1, string str2)
        {
            int count = 0;
            int i = 0;

            if (str1 == null || str2 == null)
            {
                return count;
            }

            while ((i = str1.IndexOf(str2, i)) != -1)
            {
                i += str2.Length;
                count++;
            }

            return count;
        }
    }
}
