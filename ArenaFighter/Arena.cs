using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace ColliseumClash
{
    class Arena
    {
        
        private Character warrior1;
        private Character warrior2;
        private RollDie die;
        StringBuilder log = new StringBuilder();  // fight log store string
        private void SetLogMessage(string message) //collects fight messages
        {
            log.Append("\n" +message);
        }

        public Arena(Character warrior1, Character warrior2, RollDie die) //class arena 
            {
                this.warrior1 = warrior1;
                this.warrior2 = warrior2;
                this.die = die;
        }

        private void ShowMessage() //prints messages which sho wariors and their health
        {
            Console.Clear();
            Console.WriteLine("-------------- Coliseum Arena -------------- \n");
            Console.WriteLine("Warriors health: \n");
            Console.WriteLine("{0} {1}", warrior1, warrior1.Health());
            Console.WriteLine("{0} {1}", warrior2, warrior2.Health());
        }

        private void PrintMessage(string message) //prints message every 0.3 s
        {
            Console.WriteLine(message);
            SetLogMessage(message);
            Thread.Sleep(300);
        }
        public void Greeting()
        {
            Character w1 = warrior1;
            Character w2 = warrior2;
            Console.WriteLine("Welcome to the Coliseum Arena!");
            Console.WriteLine("Today {0} will battle against {1}! \n", warrior1, warrior2);
        }

        public void Fight() //fight logic
        {

            // The original order 
            Character w1 = warrior1;
            Character w2 = warrior2;

            /* swapping the warriors - randomize who start first to hit other opponent
            bool warrior2Starts = (die.Roll() <= die.GetSidesNumber() / 2);
            if (warrior2Starts)
            {
                w1 = warrior2;
                w2 = warrior1;
            }*/
            Console.WriteLine("Our guest from the future goes first! \nLet the battle begin...", w1);
            Console.WriteLine("Press any key to begin fight", w1);
            Console.ReadKey();

            // so far fighting loop
            while (warrior1.Alive() && warrior2.Alive())
            {
                warrior1.Attack(warrior2);
                ShowMessage();
                PrintMessage(warrior1.GetLastMessage()); // attack message
                PrintMessage(warrior2.GetLastMessage()); // defense message
                warrior2.Attack(warrior1);
                ShowMessage();
                PrintMessage(warrior2.GetLastMessage()); // attack message
                PrintMessage(warrior1.GetLastMessage()); // defense message
                Console.WriteLine();

            } if (warrior1.Alive() == true) 
            { Console.WriteLine("{0} is winer of this fight", w1.name); 
            }
            else {
                Console.WriteLine("{0} is winer of this fight", w2.name); 
            }


            Console.WriteLine(log); //returns fight log after fight is over.
            
        }
    }
}
