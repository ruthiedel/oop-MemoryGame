using System;
using System.Collections.Generic;
using System.Text;

namespace MEMORY_GAME
{
    class SymbolCard : Card
    {
        public char Tav { get; set; }
        public ConsoleColor Color { get; set; }
        public SymbolCard(char tav, ConsoleColor c, bool isfirst):base(isfirst)
        {
            Tav = tav;
            Color = c;
        }
        public override bool Equals(object c)
        {
            return ((SymbolCard)(c))?.Tav == Tav;
        }
        public override void PrintValue()
        {
            Console.ForegroundColor = Color;
            Console.Write(Tav);
            Console.ForegroundColor = ConsoleColor.White;

        }

    }
}
