using System;
using System.Collections.Generic;
using System.Text;

namespace ColliseumClash
{
    class Character
    {

        private static Random rnd = new Random(DateTime.Now.Second);
        public string name;
        private int health;
        private int maxHealth;
        private int damage;
        private int defence;
        //private int damageModifier;
        private RollDie die;
        private string message;
        
        public Character()
        {

        }


        public Character(string name, int health, int maxHealth, int damage, int defence, /*int damageModifier,*/ RollDie die)
            {
                this.name = name;
                this.health = health;
                this.maxHealth = maxHealth;
                this.damage = damage;
                this.defence = defence;
                //this.damageModifier = damageModifier;
                this.die = die;
        }

        public Character AddNewCharacter(string title, RollDie die)
        {
            Character character = new Character();
            character.name = title;
            character.health = rnd.Next(85, 100);
            character.maxHealth = rnd.Next(95, 100);
            character.damage = rnd.Next(15, 25);
            character.defence = rnd.Next(5, 8);
            character.die = die;


            return character;
        }
        public Character AddNpcCharacter()
        {
            return AddNewCharacter(RandName(), die);
        }


        public static string RandName() //generates NPC name from two lists.
        {
            string[] name1part = { "Zeus", "Hera", "Poseidon", "Demeter", "Ares", "Athena", "Apollo", "Hephaestus", "Hermes", "Hypnos" };
            string[] name2part = { "sons", "berg", "alin", "qvist", "sen", "man", "lund", "dahl", "hagen"};
            
            string enemyname = name1part[rnd.Next(0, name1part.Length - 1)] + name2part[rnd.Next(0, name2part.Length - 1)];
            return enemyname;
        }

        public override string ToString()
        {
            return name;
        }

        public bool Alive() //check if char is allive.
        {
            return (health > 0);
        }
        public string Health() //health bar which shows left health
        {
            string hpbar = "[";
            int totalbar = 20;
            double hp = Math.Round(((double)health / maxHealth) * totalbar);
            if ((hp == 0) && (Alive()))
                hp = 1;
            for (int i = 0; i < hp; i++)
                hpbar += "X";
            hpbar = hpbar.PadRight(totalbar + 1);
            hpbar += "]";
            return hpbar +  "<<< " + health +" >>>";
        }
        public void Attack(Character enemy) //character attack 
        {
            int hit = damage + die.Roll();
            SetMessage(String.Format("{0} attacks with a hit worth {1} hp", name, hit));
            enemy.Defend(hit);
        }

        public void Defend(int hit) //character defence 
        {
            int damage = hit - (defence + die.Roll());
            if (damage > 0)
            {
                health -= damage;
                message = String.Format("{0} defends against the attack but still losing {1} hp", name, damage);
                if (health <= 0)
                {
                    health = 0;
                    message += " and died";
                }
            }
            else
                message = String.Format("{0} blocked the hit", name);
            SetMessage(message);
        }
        private void SetMessage(string message)
        {
            this.message = message;
        }
            


        public string GetLastMessage()
        {
            return message;
        }
        /*public string GetLogMessage()
        {
            return log ;
        }*/

    }
}
