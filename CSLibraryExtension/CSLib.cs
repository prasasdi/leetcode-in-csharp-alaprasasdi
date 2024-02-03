using System.Runtime.CompilerServices;

namespace CSLibraryExtension
{
    public class CSLib
    {
        /// <summary>
        /// Print those bad bois up to your favourite terminal
        /// </summary>
        /// <param name="o">Your bad bois array of integers</param>
        private static void PrintArray(int[] o)
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
            /**
             * Buat pointer
             */
            int moves = 0;
            int sweep = 0;

            while (moves < nums.Length)
            {
                /**
                 * Ilustrasi
                 * sweep = 0
                 * current = sweep => current = 0
                 * 
                 * prev = temp = nums[sweep] => temp = nums[0]
                 */
                int curr = sweep; // kayak i dalam for
                int prev = nums[sweep]; // karena var temp udah ada di dalam loop. jadi dibuat dua temp, dan ini salah satunya. Disebutlah prev

                do
                {
                    /**
                     * nextIndex = (current + k) % nums.Length
                     * sebutlah
                     * 
                     * nums = [1,2,3,4,5,6,7,8]
                     * 
                     * current = 0, k = 3, dan length = 8
                     * ada modulo sebagai penyederhana kalau lebih dari Length
                     * jadi hasilnya
                     * nextIndex = 3 walaupun 3 mod 8 = 3
                     * 
                     * [1,2,3,4,5,6,7,8]
                     *        ^nextIndex
                     *        
                     * [1,2,3,4,5,6,7,8]
                     *  ^sweep = i
                     */
                    int nextIndex = (curr + k) % nums.Length;

                    /**
                     * temp = nums[nextIndex] => temp = nums[3]
                     * sementara temp ini sebagai temp dari kanan
                     * 
                     * temp = 4
                     */
                    int temp = nums[nextIndex];

                    /**
                     * masih tau kan nextIndex saat i = 0 berapa? nextIndex = 3
                     * Nah disini ditiban sama nilai prev yang diatas tadi => prev = nums[0] => prev = 1
                     * 
                     * [1,2,3,1,5,6,7,8]
                     *  ^prev ^nI
                     */
                    nums[nextIndex] = prev;

                    /**
                     * Inget ya, prev dan temp ini adalah "sama" dalam tanda kutip
                     * yang asli beroperasi adalah prev sedangkan temp sebagai "pointer"ish
                     * 
                     * prev = 4 karena tadi temp = 4
                     */
                    prev = temp;

                    /**
                     * pointer current = nextIndex
                     * current = 3
                     * nanti nextIndex dikasih nilai baru lagi diatas
                     */
                    curr = nextIndex;

                    moves++;
                    Console.WriteLine("do");
                    PrintArray(nums);
                } while (sweep != curr && moves < nums.Length); //sama kayak while (sweep != curr && moves < nums.Length)
                /**
                 * Diputaran pertama yuk liat dapet berapa
                 * sweep = 0 nanti diinkremen kalau do while diatas selesai. but when?
                 * curr = 3
                 * moves = 1 karna udah diinkremen
                 * nums.Length = 8 ya iyalah
                 */

                sweep++;
                Console.WriteLine("out do");
                PrintArray(nums);

            }
        }
    }
}
