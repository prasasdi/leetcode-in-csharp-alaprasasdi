namespace CSLibraryExtension.Solutions
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class AddTwoNumbersSolution
    {

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            /**
             * urutan dalam array menunjukan
             * yang paling belakang adalah posisi dalam bilangan
             * 
             * kalau size = 3 berarti ratusan, puluhan, satuan
             * ex. arr = [3,2,1] => 123 atau arr = [0,0,5,1] => 1500
             * 
             * dan ini bukan soal array, mlainkan linked-list. Jadi kita ga punya info ttg Length
             */

            //buat node baru, head
            ListNode head = l1;

            //debug remove later
            int i = 0;
            while(l1 != null)
            {
                i++;
                l1.val = l1.val + l2.val; //l1.val as ressult operation bilangan, paksain if l2 == null ? 0 : l2.val
                Console.WriteLine("loop ke " + i);

                if (l1.val > 9)
                {
                    Console.WriteLine("res original " + l1.val);

                    l1.val %= 10;
                    Console.WriteLine("res after %10 " + l1.val);

                    if (l1.next == null)
                    {
                        Console.WriteLine("create new l1.next");
                        l1.next = new ListNode()
                        {
                            val = l1.val,
                            next = null
                        };
                    }

                    l1.next.val++;
                    Console.WriteLine("next res " + l1.next.val);

                }
                l1 = l1.next;
                l2 = l2.next == null ? new ListNode() : l2.next;
            }
            return head;
        }
    }
}
