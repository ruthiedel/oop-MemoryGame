using System;
using System.Collections.Generic;
using System.Text;

namespace MEMORY_GAME.classes
{
    class UserPlayer:Player
    {
        public UserPlayer(string name,int size):base(size,name)
        {
            
        }

        public override int OpenCard(int numOfCards, int othercard = -1)
        {
            Console.WriteLine(Name+" this your turn");
            Console.WriteLine("enter index of card from 1 to " + numOfCards);
            int x = int.Parse(Console.ReadLine());
            if(x>numOfCards||x<1 || x == othercard)
            {
                Console.WriteLine("an invalid card index");
                return OpenCard(numOfCards,othercard);
            }
            return x -1;

        }
      
        public override string ToString()
        {
            return Name;
        }
    }
}
