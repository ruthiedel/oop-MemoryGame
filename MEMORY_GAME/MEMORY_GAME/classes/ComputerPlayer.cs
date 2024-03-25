using System;
using System.Collections.Generic;
using System.Text;

namespace MEMORY_GAME.classes
{
    class ComputerPlayer:Player
    {
    
        public ComputerPlayer(int size):base(size)
        {

        }
        public override int OpenCard(int numOfCards,int othercard=-1)
        { 
            Console.WriteLine(Name + " this your turn");
            Random rnd = new Random();
            int x= rnd.Next(1, numOfCards+1);
            if(x>numOfCards||x<1 || x == othercard)
            {
                return OpenCard(numOfCards,othercard);
            }
            return x - 1;
        }
     
        public override string ToString()
        {
            return Name;
        }
    }
}
