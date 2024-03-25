using System;
using System.Collections.Generic;
using System.Text;

namespace MEMORY_GAME
{
    public enum  CardStatus {FaceDown,FaceUp,Taken };
    public enum CardType { Symbol,Letter,Exercise}
    abstract class Card
    {
       
        public CardStatus CardStatus { get; set; }
        public bool IsFirst { get; set; }


        public Card(bool isfirst)
        {
            CardStatus = CardStatus.FaceDown;
            IsFirst = isfirst;
        }


        public abstract override bool Equals(object c);
        
        public void ChangeToTaken()
        {
            CardStatus = CardStatus.Taken;
        }
            public void ChangeToFaceDown()
        {
            CardStatus = CardStatus.FaceDown;
        }

        public  bool IsMatch(Card c)
        {
            return this.Equals(c)&& c.IsFirst != this.IsFirst;
         }

        public void Flip()
        {
           if(CardStatus==CardStatus.FaceDown)
            {
                CardStatus = CardStatus.FaceUp;
            }
            else
            {
                if(CardStatus==CardStatus.FaceUp)
                {
                    CardStatus = CardStatus.FaceDown;
                }
                else
                {
                    Console.WriteLine("this card has allready taken");
                }
            }
        }
        public abstract void PrintValue();
        public  void Print()
        {
            if (CardStatus == CardStatus.FaceDown)
            {
              
                    Console.Write(" * ");
                
            }
            else
            {
                if(CardStatus==CardStatus.FaceUp)
                {
                   

                    Console.Write(" ");
                        PrintValue();
                        Console.Write(" ");
                  
                }
                else
                {
                    
                        Console.Write(" ! ");
                    
                }
            }
        }
    }
}
