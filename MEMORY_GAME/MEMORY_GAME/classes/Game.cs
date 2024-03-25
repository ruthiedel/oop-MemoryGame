using System;
using System.Collections.Generic;
using System.Text;

namespace MEMORY_GAME.classes
{
    class Game
    {
        public int PlayersNum { get; set; }
        public Player[] Players { get; set; }
        public Board Board { get; set; }
        public int Index { get; set; }
        public CardType Type { get; set; }

        public Game()
        {
            InitilizeType();
            Board = new Board(CardNum(), Type);
            Console.WriteLine("enter num of players");
            PlayersNum = int.Parse(Console.ReadLine());
            Players = new Player[PlayersNum];
            MakePlayersArray();
            Index = 0;
            TheGame();
            
        }
        //מהלך המשחק
        public void TheGame()
        {
            Console.Clear();
            Board.PrintBoard();
           while(Board.HasLeftCard())
            {
                Index = 0;
                for(int i=0;i<Players.Length&&Board.HasLeftCard();i++)
                {
                    Turn(i);
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Board.PrintBoard();
                    Index++;
                }
            }
           Players[ ShowTheWinner()].PrintCards();


        }
        //ניהול תור
        public void Turn(int i)
        {
            int first, second;
            first=Halfturn(i);
            Board.PrintBoard();
           second= Halfturn(i,first);
            Console.Clear();
            Board.PrintBoard();
           if(Board.Cards[first].IsMatch(Board.Cards[second]))
            {
                Board.Cards[first].ChangeToTaken();
                Board.Cards[second].ChangeToTaken();
                Players[Index].AddPair(Board.Cards[first], Board.Cards[second]);
            }
            else
            {
                Board.Cards[first].ChangeToFaceDown();
                Board.Cards[second].ChangeToFaceDown();
            }
        }
        //חצי תור-הרמת כרטיס
        public int Halfturn(int i,int othercard=-1)
        {
            int c = Players[i].OpenCard(Board.Cards.Length,othercard+1);
            Board.Cards[c].Flip();
            if (Board.Cards[c].CardStatus==CardStatus.Taken)
            {

               return Halfturn(i);
            }
            return c;
        }
        //יצירת מערך שחקנים
        public void MakePlayersArray()
        {
            string str;
            for(int i=0;i<PlayersNum;i++)
            {
                Console.WriteLine("enter player type: computer/user");
                str = Console.ReadLine();
                if(str=="computer")
                {
                    Players[i] = new ComputerPlayer(Board.Cards.Length);
                }
                else
                {
                    if(str=="user")
                    {
                        Console.WriteLine("enter your name");
                        Players[i] = new UserPlayer(Console.ReadLine(),Board.Cards.Length);
                    }
                    else
                    {
                        Console.WriteLine("an invalid player-type");
                        i--;
                    }
                }
            }

      
        }
        //אתחול סוג משחק
        public void InitilizeType()
        {
            Console.WriteLine("enter game-type \n to question-answe enter 1 \n to symbol enter 2 \n to letter enter 3");
            int x = int.Parse(Console.ReadLine());
            switch (x)
            {

                case 1:Type = CardType.Exercise;
                    break;
                case 2: Type = CardType.Symbol;
                    break;
                case 3: Type = CardType.Letter;
                    break;
                default:
                    InitilizeType();
                    break;
            }
        }
        //מחזיר את אורך המערך של הכרטיסים בלוח
        public int CardNum()
        {
            Console.WriteLine("enter num of pairs");
            int x = int.Parse(Console.ReadLine());
            if (x < 0)
            {
                Console.WriteLine("you can only choose positive num of pairs");
                CardNum();
            }
            return x * 2;
        }
        //הוספת זוג שנמצא
        public void FindPair(int index1,int index2)
        {
            Board.Cards[index1].CardStatus = CardStatus.Taken;
            Board.Cards[index2].CardStatus = CardStatus.Taken;
            Players[Index].AddPair(Board.Cards[index1], Board.Cards[index2]);
        }
        //הדפסת שם המנצח
        public int ShowTheWinner()
        {
            int max = 0, maxi = 0;
            for(int i=0;i<Players.Length;i++)
            {
                if(Players[i].Score>max)
                {
                    max = Players[i].Score;
                    maxi = i;
                }
            }
            Console.WriteLine(Players[maxi].ToString()+" is the winner!! ");
            return maxi;
        }
    }
}
