using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MEMORY_GAME.classes
{

     class Board
    {
        public Card [] Cards { get; set; }


        public Board(int size,CardType ctype)
        {
            Cards = new Card[size];
            Mix(ctype, size);
        }
        
        //הכנת מערך עזר של כרטיסי תרגילים
        public void MakeExerciseCards()
        {
            for (int i = 0; i <Cards.Length; i += 2)
            {
                Cards[i] = new ExerciseCard($"{i}+1", i + 1, true);
                Cards[i + 1] = new ExerciseCard($"{i}+1", i + 1, false);
            }
        }
        //הכנת מערך עזר של כרטיסי תווים
        public void MakeSymbolCards()
        {
            Random rnd = new Random();
            for (int i = 0; i < Cards.Length; i += 2)
            {
                ConsoleColor v = (ConsoleColor)(rnd.Next(0, 16));
                Cards[i] = new SymbolCard((char)(i + 34), v, true);
                Cards[i + 1] = new SymbolCard((char)(i + 34), v, false);
            }
        }
        //הכנת מערך עזר של כרטיסי אותיות
        public void MakeLetterCards()
        {
           
            for (int i = 0; i <Cards.Length; i += 2)
            {
                Cards[i] = new LetterCard((char)(i + 65), true);
                Cards[i + 1] = new LetterCard((char)(i + 65), false);
            }
           
        }
        //ערבוב
        public void Mix(CardType ctype, int size)
        {
           
            if (ctype == CardType.Exercise)
            {
                MakeExerciseCards();
            }
            else
            {
                if (ctype == CardType.Symbol)
                {
                    MakeSymbolCards();
                }
                else
                {
                    MakeLetterCards();
                }
            }
          
            Random rnd = new Random();
            Cards = Cards.OrderBy(x => rnd.Next()).ToArray();
        }
        //האם נשארו כרטיסים
        public bool HasLeftCard()
        {
            for (int i = 0; i < Cards.Length; i++)
            {
                if (Cards[i].CardStatus!=CardStatus.Taken)
                {
                    return true;
                }
            }
            return false;
        }
        //האם מיקום כרטיס להרמה חוקי
       public bool IsLegalIndex(int index)
        {
            return index > 0 && index <=Cards.Length;
        }

        //הדפסת לןח
        public void PrintBoard()
        {
            int count = 0;
            for(int i=0;i<Cards.Length;i++)
            {
                count++;
                Cards[i].Print();
                if(count==6)
                {
                    count = 0;
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n");
        }
    }
}
