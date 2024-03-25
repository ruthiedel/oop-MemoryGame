using System;
using System.Collections.Generic;
using System.Text;

namespace MEMORY_GAME
{
    class LetterCard:Card
    {
        public char Letter { get; set; }

        public LetterCard(char l,bool isfirst):base(isfirst)
        {
            Letter = l;
        }
        public override bool Equals(object c)
        {
            return this.Letter == char.ToUpper(((LetterCard)(c)).Letter) || this.Letter == char.ToLower(((LetterCard)(c)).Letter);
        }
        public override void PrintValue()
        {
            Console.Write(Letter);
        }
        
    }
}
