using System;


namespace ColliseumClash
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            int points=0;
            string name;
            // creating objects
            RollDie die = new RollDie(6);

            Console.WriteLine("With time machine you were trasnported back to Romanian times " +
                                "\nUnluckely you are prisoner in Colliseum." +
                                "\nToday you will fight till you die");

            Console.WriteLine("Please enter your name");
            
            name = Console.ReadLine();
            
            Character fighter1 = new Character();


            /*Character fighter2 = new Character();
            fighter2 = fighter2.AddNewCharacter(Character.RandName(), die); */

            


            // fight
            do
            {
                fighter1 = fighter1.AddNewCharacter(name, die);
                Character fighter2 = new Character();
                fighter2 = fighter2.AddNewCharacter(Character.RandName(), die);
                Arena arena = new Arena(fighter1, fighter2, die);
                if (points == 0) arena.Greeting();
                arena.Fight();
                
                points++;
                Console.WriteLine("If you want to stop fighting pres x and enter\nIf you want to try fighting other openent press any key and enter");
            } while (Console.ReadLine()!="x");



            Console.WriteLine("\nYour score {0}", points);

            Console.ReadKey();
        }
    }

}



    




                    