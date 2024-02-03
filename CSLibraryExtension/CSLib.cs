using System.Runtime.CompilerServices;

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

            char[] chars = s.ToCharArray();
            int result = 0, index = chars.Length - 1, current = 0, nextValue;
            
            // sampai Length - 1
            while (index > 0)
            {
                current = RomawiMap[chars[index]];
                nextValue = RomawiMap[chars[index - 1]];

                if (current > nextValue) //misal X > I (o) atau V > I (o) atau M(1000) > C(100)
                {
                    result = result + (current - nextValue); //misal X(10) - I(1) => temp = IX(9) atau V(5) - I(1) => temp = IV(4)
                    Console.WriteLine($"{current} - {nextValue} = {result}");
                    index--;
                }
                else
                {
                    result = result + current;
                }

                index--;
            }
            Console.WriteLine(index);
            if (index != -1)
                result = result + RomawiMap[chars[0]];

            Console.WriteLine(result);
            return result;
        }
    }
}
