

namespace Example01.ConsoleApp
{
    internal class Program
    {
        #region Thread Kullanımı
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Starting...");

        //    Thread tekSayilar = new Thread(new ThreadStart(TekSayilar));
        //    Thread ciftSayilar = new Thread(new ThreadStart(CiftSayilar));

        //    //CiftSayilar();
        //    //TekSayilar();

        //    ciftSayilar.Start();
        //    tekSayilar.Start();

        //    Console.WriteLine("Finising...");

        //    Console.ReadLine();
        //}

        //private static void CiftSayilar()
        //{
        //    for (int i = 0; i <= 10; i=i+2)
        //    {
        //        Console.WriteLine(i);
        //        Thread.Sleep(1000);
        //    }
        //}

        //private static void TekSayilar()
        //{
        //    for (int i = 1; i < 10; i = i + 2)
        //    {
        //        Console.WriteLine(i);
        //        Thread.Sleep(1000);
        //    }

        //} 
        #endregion


        static void Main(string[] args)
        {
            //FirstThread();
            FirstThreadAsync();


            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Main thread çalışıyor...");
            }
        }

        private static void FirstThread()
        {
            while (true)
            {
                Thread.Sleep(1500);
                Console.WriteLine("İlk thread çalışıyor...");
            }
        }

        private async static void FirstThreadAsync()
        {
            void InnerThread()
            {
                while (true)
                {
                    Thread.Sleep(1500);
                    Console.WriteLine("İlk thread çalışıyor...");
                }
            }
        
            Task gorev = new Task(() => InnerThread());

            gorev.Start();

            await gorev;
        }

    }
}
