using System;
using System.Collections.Generic;
using System.Text;

namespace MEMORY_GAME
{
     abstract class Player
    {
        public string Name { get; }
        private int score;
        public Card [] arr { get; set;}
        public int Current { get; set; }
        public Player(int size,string name="מחשב")
        {
            score = 0;
            Name = name;
            arr = new Card[size];
            Current = 0;
        }
        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                if(value>=0)
                {
                    score = value;
                }
                else
                {
                    throw new Exception("you can not reduce the score ");
                }
            }
        }
        public void PrintCards()
        {
            Console.WriteLine("your taken card are: \n");
            foreach (var item in arr)
            {
                item.CardStatus = CardStatus.FaceUp;
                item.Print();
                item.CardStatus = CardStatus.Taken;
            }
        }

        public void AddPair(Card c1, Card c2)
        {
            arr[Current++] = c1;
            arr[Current++] = c2;
            Score++;
        }


        public abstract int OpenCard(int numOfCards,int othercard=-1);
    
     
    }
}
