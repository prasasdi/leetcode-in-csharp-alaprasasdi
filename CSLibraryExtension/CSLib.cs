using System.Runtime.CompilerServices;

namespace CSLibraryExtension
{
    public class CSLib
    {
        private static void PrintArray(int[] o)
        {
            Console.Write("[");
            for (int i = 0; i < o.Length - 1; i++)
            {
                Console.Write($"{o[i]}, ");
            }
            Console.Write($"{o[o.Length - 1]}]");
        }
        public static void Rotate(int[] nums, int k)
        {
            /***
             * Kalau k lebih dari length maka sederhanakan k
             * dengan cara k modulo dari length array
             * 
             * jika k = 0 sama aja dengan tidak merotasi sama sekali
             */
            k = k % nums.Length;
            if (k == 0) return;

            /***
             * Idenya adalah
             * Reverse dulu nums, urutannya masih ga bener dan tujuan dari rotate sudah terpenuhi
             * Tinggal perbaiki sisanya
             */
            Array.Reverse(nums);
            
            int kiri = k, kanan = nums.Length - 1, temp;
            for (int i = k; i < kanan; i++) 
            {
                /***
                 * ilustrasi flow
                 * 
                 * nums = [1,2,3,4,5,6,7,8]
                 * k = 3
                 * 
                 * dan kiri = k, juga kanan = nums.Length - 1
                 * berarti pointer kiri mengarah ke =>
                 * [1,2,3,4,5,6,7,8]
                 *        ^kiri
                 * dan pointer kanan mengarah ke =>
                 * [1,2,3,4,5,6,7,8]
                 *                ^kanan
                 * 
                 * temp = nums[kiri] => temp = nums[3] => temp = 4
                 * nums[kiri] = nums[kanan] => nums[3] = 8
                 * nums sementara jadi 
                 * [1,2,3,8,5,6,7,8]
                 *        ^ nilai sebelumnya 4, sudah ditaruh di variabel temp
                 *        
                 * nums[kanan] = temp => nums[kanan] = 4 karena nilai temp adalah nums[kiri] sebelumnya
                 * nums sementara jadi
                 * [1,2,3,8,5,6,7,4]
                 *                ^ nilai sebelumnya 8, diganti dengan nilai nums[kiri] yang udah ditaruh di variabel temp
                 * note: kira-kira begitu, karena diatas nums[] udah kita reverse(). Idenya adalah reverse balik in-plaace
                 * 
                 * terakhir geser pointer, kiri dan kanan geser satu nilai
                 */
                temp = nums[kiri];
                nums[kiri] = nums[kanan];
                nums[kanan] = temp;
                kiri++; kanan--;
            }

            kiri = 0; kanan = k - 1;
            for (int i = 0; i < kanan; i++)
            {
                /***
                 * ilustrasi flow
                 * 
                 * nums = [1,2,3,4,5,6,7,8]
                 * k = 3
                 * 
                 * dan kiri = k, juga kanan = nums.Length - 1
                 * berarti pointer kiri mengarah ke =>
                 * [1,2,3,4,5,6,7,8]
                 *        ^kiri
                 * dan pointer kanan mengarah ke =>
                 * [1,2,3,4,5,6,7,8]
                 *                ^kanan
                 * 
                 * temp = nums[kiri] => temp = nums[3] => temp = 4
                 * nums[kiri] = nums[kanan] => nums[3] = 8
                 * nums sementara jadi 
                 * [1,2,3,8,5,6,7,8]
                 *        ^ nilai sebelumnya 4, sudah ditaruh di variabel temp
                 *        
                 * nums[kanan] = temp => nums[kanan] = 4 karena nilai temp adalah nums[kiri] sebelumnya
                 * nums sementara jadi
                 * [1,2,3,8,5,6,7,4]
                 *                ^ nilai sebelumnya 8, diganti dengan nilai nums[kiri] yang udah ditaruh di variabel temp
                 * note: kira-kira begitu, karena diatas nums[] udah kita reverse(). Idenya adalah reverse balik in-plaace
                 * 
                 * terakhir geser pointer, kiri dan kanan geser satu nilai
                 */
                temp = nums[kiri];
                nums[kiri] = nums[kanan];
                nums[kanan] = temp;
                kiri++; kanan--;
            }

            PrintArray(nums);
        }
    }
}
