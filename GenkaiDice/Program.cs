using System;

namespace GenkaiDice
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Genkai Dice\n");

            while (true)
            {
                int playerPoint = 0;
                int comPoint = 0;
                bool p_busted = false;
                bool c_busted = false;
                bool p_declared = false;
                bool c_declared = false;

                while (true)
                {
                    int pDice = 0;
                    int cDice = 0;

                    //Player
                    Console.WriteLine("Your point: {0}", playerPoint);
                    Console.WriteLine("1: Continue, 2: Stop");
                    var c = Console.ReadLine();
                    if (c == "1")
                    {
                        pDice = ThrowDice();
                        Console.WriteLine("\nYour dice: {0}", pDice);

                        if (p_declared == false)
                        {
                            if (pDice != 6 && p_busted == false) playerPoint++;
                            else
                            {
                                playerPoint = 0;
                                p_busted = true;
                            }
                        }
                    }
                    else if (c == "2")
                    {
                        Console.WriteLine("\nYou declared Stop");
                        p_declared = true;
                    }

                    //Computer
                    var isComContinue = IsComputerContinue();
                    if (isComContinue)
                    {
                        cDice = ThrowDice();
                        if (c_declared == false)
                        {
                            if (cDice != 6 && c_busted == false) comPoint++;
                            else
                            {
                                comPoint = 0;
                                c_busted = true;
                            }
                        }
                    }
                    else
                    {
                        c_declared = true;
                    }

                    if (p_declared == true && c_declared == true)
                    {
                        Console.WriteLine("Both players declared Stop!");
                        break;
                    }
                    if (p_busted == true && c_busted == true)
                    {
                        Console.WriteLine("Both players busted!");
                        break;
                    }

                }

                Console.WriteLine("\n---Result---");
                
                if (c_declared) Console.WriteLine("\nComputer has declared Stop");
                else Console.WriteLine("\nComputer hasn't declared Stop");

                Console.WriteLine("\nPlayer: {0}pts, Computer: {1}pts", playerPoint, comPoint);

                if (playerPoint > comPoint) Console.WriteLine("You Win!");
                else Console.WriteLine("You Lose...");

                Console.WriteLine("\nPlay again?");
                Console.WriteLine("1: Yes, 2: No");
                var d = Console.ReadLine();
                Console.WriteLine("\n---New game---");

                if (d == "2") break;
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }     

        static int ThrowDice()
        {
            return random.Next(6) + 1;
        }
        static bool IsComputerContinue()
        {
            var num = random.Next(8);
            if (num == 0) return false;
            return true;
        }
    }
}
