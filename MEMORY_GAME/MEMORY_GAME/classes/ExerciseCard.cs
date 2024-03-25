using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace MEMORY_GAME.classes
{
    internal class ExerciseCard:Card
    {

        public string Question { get; set; }
        public int Answer { get; set; }
         
        public ExerciseCard(string question,int answer,bool isfirst) : base(isfirst)
        {
            Question = question;
            Answer = answer;
        }
        public override void PrintValue()
        {
            if (IsFirst)
            {
                Console.Write(Question);
            }
            else
            {
                Console.Write(Answer);
            }
        }
        public override bool Equals(object c)
        {
            return ((ExerciseCard)(c)).Answer == this.Answer;
        }
    }
}
