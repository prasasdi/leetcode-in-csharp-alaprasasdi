using System.Runtime.CompilerServices;
using System.Text;

namespace CSLibraryExtension
{
    public class CSLib
    {
        /// <summary>
        /// Print those bad bois up to your favourite terminal
        /// </summary>
        /// <param name="o">Your bad bois array of integers</param>
        private static void PrintArray(object[] o)
        {
            Console.Write("[");
            for (int i = 0; i < o.Length - 1; i++)
            {
                Console.Write($"{o[i]}, ");
            }
            Console.Write($"{o[o.Length - 1]}]");
            Console.WriteLine();
        }
        public static void Rotate(int[] nums, int k)
        {
            /***
             * Kuncinya adalah
             * 
             * Taruh nilai pada posisi setelah digeser k kali
             * 
             * Contoh dibawah pertama kali adalah 1 atau nums[0]
             * Kita cari dimana nilai 1 atau nums[0] harusnya berada setelah dirotasi berapa k kali
             * 
             * Ternyata ada di index 3 nums[3], dapet dari (current + k) % length
             * 
             * Nah nilai sebelumnya dari index 3 nums[3] adalah 4. Dan dimana harusnya nilai 4 setelah dirotasi ke K kali?
             * Nah itulah dilooping lagi
             */
            int moves = 0;
            int sweep = 0;

            while (moves < nums.Length)
            {
                /**
                 * curr sebagai pointer dalam loop do
                 * dan prev adalah nilai yang mau kita geser
                 */
                int curr = sweep; 
                int prev = nums[sweep];

                do
                {
                    /**
                     * Cari nextIndex lalu taruh nums[nextIndex] ke variabel temp
                     */
                    int nextIndex = (curr + k) % nums.Length;
                    int temp = nums[nextIndex];

                    /**
                     * tempatkan prev di tempat setelah digeser k kali.
                     * Contoh nilai pertama nums[0] setelah di geser k kali jadi nums[3]
                     */
                    nums[nextIndex] = prev;

                    /**
                     * kemana nums[3] sekarang? nanti dicari dilooping selanjutnya
                     * sementara kita jadiin nilai nums[3] dalam temp ke variabel prev
                     */
                    prev = temp;

                    /**
                     * jadiin nilai nextIndex sebagai posisi sekarang (current position)
                     */
                    curr = nextIndex;

                    /**
                     * inkremen pointer looping
                     */
                    moves++;
                } while (sweep != curr && moves < nums.Length);

                /**
                 * Kalau dalam looping do-while diatas belum berhasil atau dalam satu momen kebetulan sweep == current
                 * pointer sweep diinkremen. 
                 */
                sweep++;
            }
        }

        public static int RomanToInt(string s)
        {
            //buat dulu HashMap
            Dictionary<char, int> RomawiMap = new Dictionary<char, int>();
            RomawiMap.Add('I', 1);
            RomawiMap.Add('V', 5);
            RomawiMap.Add('X', 10);
            RomawiMap.Add('L', 50);
            RomawiMap.Add('C', 100);
            RomawiMap.Add('D', 500);
            RomawiMap.Add('M', 1000);

            /**
             * Mulai dari belakang karena jatuhnya lebih mudah 
             */
            int result = 0, index = s.Length - 1, current = 0, nextValue;
            
            // sampai Length - 1
            while (index > 0)
            {
                current = RomawiMap[s[index]];
                nextValue = RomawiMap[s[index - 1]];

                if (current > nextValue)
                {
                    /*
                     * Setelah melakukan operasi pengurangan pada nilai IV, IX dan sejenisnya
                     * kita lewatin index setelah current. Nanti juga digeser lagi
                     */
                    result = result + (current - nextValue); //misal X(10) - I(1) => temp = IX(9) atau V(5) - I(1) => temp = IV(4)
                    index--;
                }
                else
                {
                    result = result + current;
                }

                index--;
            }

            /*
             * Index = -1 mengindikasi bahwa ada operasi romawi yang lebih kecil dilakukan diloop terakhir. Maka lewatin aja
             * Misal CMLII
             */
            if (index != -1)
                result = result + RomawiMap[s[0]];

            return result;
        }

        public static string IntToRoman(int num)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Dictionary<int, char> RomawiMap = new Dictionary<int, char>();

            RomawiMap.Add(1, 'I');
            RomawiMap.Add(5, 'V');
            RomawiMap.Add(10, 'X');
            RomawiMap.Add(50, 'L');
            RomawiMap.Add(100, 'C');
            RomawiMap.Add(500, 'D');
            RomawiMap.Add(1000, 'M');

            //int length = num.ToString().Length;

            while(num != 0)
            {
                if (1000 <= num) //range 1000 and beyond
                {
                    num -= 1000;
                    stringBuilder.Append("M");
                }
                else
                if (900 <= num && num < 1000) //range 900 sampai 999
                {
                    num -= 900;
                    stringBuilder.Append("CM");
                }
                else
                if (500 <= num && num < 900) //range 500 sampai 899
                {
                    num -= 500;
                    stringBuilder.Append("D");
                }
                else
                if (400 <= num && num < 500) //range 400 sampai 499
                {
                    num -= 400;
                    stringBuilder.Append("CD");
                }
                else
                if (100 <= num && num < 400) //range 100 sampai 399
                {
                    num -= 100;
                    stringBuilder.Append("C");
                }
                else
                if (90 <= num && num < 100) //range 90 sampai 99
                {
                    num -= 90;
                    stringBuilder.Append("XC");
                }
                else
                if (50 <= num && num < 90) //range 50 sampai 89
                {
                    num -= 50;
                    stringBuilder.Append("L");
                }
                else
                if (40 <= num && num < 50) //range 40 sampai 49
                {
                    num -= 40;
                    stringBuilder.Append("XL");
                }
                else
                if (10 <= num && num < 40) //range 10 sampai 39
                {
                    num -= 10;
                    stringBuilder.Append("X");
                }
                else
                if (9 == num)
                {
                    num -= 9;
                    stringBuilder.Append("IX");
                }
                else
                if (5 <= num && num < 9) //range 5 sampai 8
                {
                    num -= 5;
                    stringBuilder.Append("V");
                }
                else
                if (4 == num)
                {
                    num -= 4;
                    stringBuilder.Append("IV");
                }
                else
                if (1 <= num && num < 4) //range 0 sampai 3
                {
                    num -= 1;
                    stringBuilder.Append("I");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
