using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CombatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //adjusts the size of the window height to 45 from normal 25
            Console.WindowHeight = 45;
            //calls the function that plays intro to the game
            GameIntro();
            //calls the function to play the game 
            PlayGame();
            Console.ReadKey();


        }


        /// <summary>
        /// Plays the game function
        /// </summary>
        public static void PlayGame()
        {
            //set the gamer and the computer points
            int playerPoints = 100;
            int computerPoints = 200;
            //Plays the game while the computer and the gamer are greater than 0
            while (playerPoints > 0 && computerPoints > 0)
            {
                Console.Clear();
                //calls all these functions to keep the game screen updating
                GameInstructions();
                gameStats(playerPoints, computerPoints);
                KittyMoods(1);
                Messages();
                gameOptions();

                bool validate = false;
                string input = "";
                //validtes the user entry
                while (!validate)
                {
                    //ask for the choice
                    Console.Write("Your choice: ");
                    input = Console.ReadLine();
                    //if the input is good to go
                    if (ValidateChoice(input))
                    {
                        //changes the flag to true 
                        validate = true;
                    }
                }

                //converts the choice to an int 
                int optionChosen = int.Parse(input);
                int pointsDeducted;
                //switches the choice
                switch (optionChosen)
                {
                    //if the option is 1 then it calls the fuction attack
                    //depending what the function returns then it substract the point from the gamer points
                    case 1: computerPoints = computerPoints - (pointsDeducted = Attack(70, 20, 35));
                        //if the player points are less than 0 then it sets the gamer points to zero
                        if (computerPoints < 0) { computerPoints = 0; }
                        //calls all these functions to keep the game screen updating
                        GameInstructions();
                        gameStats(playerPoints, computerPoints);
                        KittyMoods(1);
                        SubMoodsTetx(0, pointsDeducted);
                        gameOptions();
                        Delay(2000);


                        break;
                    //if the option is 2 then it calls the function Magic Attack
                    //depending what the function returns then it substract the point from the gamer points
                    case 2: 
                        computerPoints = computerPoints - (pointsDeducted = MagicAttack());
                        //if the player points are less than 0 then it sets the gamer points to zero
                        if (computerPoints < 0) { computerPoints = 0; }
                        //calls all these functions to keep the game screen updating
                        GameInstructions();
                        gameStats(playerPoints, computerPoints);
                        KittyMoods(1);
                        SubMoodsTetx(0, pointsDeducted);
                        gameOptions();
                        Delay(2000);
                        
                        break;
                    //if the option is 3 then it calls the function heal power
                    //depending what the function returns then it substract the point from the gamer points
                    case 3:
                        computerPoints = computerPoints - (pointsDeducted = HealPower());
                        //if the player points are less than 0 then it sets the gamer points to zero
                        if (computerPoints < 0) { computerPoints = 0; }
                        //calls all these functions to keep the game screen updating
                        GameInstructions();
                        gameStats(playerPoints, computerPoints);
                        KittyMoods(1);
                        SubMoodsTetx(0, pointsDeducted);
                        gameOptions();
                        Delay(2000);

                        break;
                }


                //for the computer turn it calls the function attack
                //depending what the function returns then it substract the point from the computer
                playerPoints = playerPoints - (pointsDeducted = Attack(80, 5, 15));
                //if the player points are less than 0 then it sets the computer points to zero
                if (playerPoints < 0) { playerPoints = 0; }
                gameStats(playerPoints, computerPoints);
                //calls all these functions to keep the game screen updating
                GameInstructions();
                gameStats(playerPoints, computerPoints);
                KittyMoods(1);
                SubMoodsTetx(1, pointsDeducted);
                gameOptions();
                Delay(2000);



            }
            //if the player points are greater than 0 then the gamer wins
            if (playerPoints > 0)
            {

                //calls all these functions to keep the game screen updating
                GameInstructions();
                gameStats(playerPoints, computerPoints);
                KittyMoods(3);
                Messages();
                gameOptions();
            }
            else
            {
                //if the player points are less than 0 then the computer wins
                //calls all these functions to keep the game screen updating
                GameInstructions();
                gameStats(playerPoints, computerPoints);
                KittyMoods(2);
                Messages();
                gameOptions();
            }

        }

        /// <summary>
        /// Keeps track of the game
        /// </summary>
        /// <param name="gamerScore"></param>
        /// <param name="compScore"></param>
        public static void gameStats(int gamerScore, int compScore)
        {

            //Writes the game stats
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                        G A M E    S C O R E");
            Console.ResetColor();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("              GAMER POINTS: " + gamerScore + "    |     CAT SCORE: " + compScore);
            Console.ResetColor();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

        }

        public static void gameOptions()
        {

            //Writes the game stats
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                        G A M E    O P T I O N S");
            Console.ResetColor();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|1.- FEED THE KITTY  | 2.- PET THE KITTY  | 3.- GIVE CAT NIP TO THE KITTY |");
            Console.ResetColor();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

        }


        public static bool ValidateChoice(string input)
        {

            int result;
            //tries to convert the input to int and put it into result
            if (int.TryParse(input, out result))
            {
                //if result is less than 4 then the user chose an option greater than 3
                if (result < 4)
                {
                    //returns true if the choice is between 1,2,3
                    return true;
                }
                else
                {
                    //if not then writes a message
                    Console.WriteLine("The number has to be between 1 and 3");
                    return false;
                }
            }
            else
            {
                //if fails to conver the string to integer then writes a message
                Console.WriteLine("Only numbers");
                return false;
            }

        }


        /// <summary>
        /// Function attact that calculates the attack points taking the paremters of porcentage of attack
        /// the points to substract for low damage to high damage
        /// </summary>
        /// <param name="percentage"></param>
        /// <param name="lowDamage"></param>
        /// <param name="highDamage"></param>
        /// <returns></returns>
        public static int Attack(int percentage, int lowDamage, int highDamage)
        {
            //creates a random number to calculate the percentage of attack
            Random rndAttack = new Random();
            //creates a random number to calculate the damage points
            Random rndPoints = new Random();
            //if the number generated is less than the percentage set
            if (rndAttack.Next(1, 101) <= percentage)
            {
                //then it calculates the damage points generated from low to high
                return rndPoints.Next(lowDamage, highDamage + 1);
            }
            else
            {
                //if the percentage is higer to the percentage set then no points are calculated
                return 0;
            }

        }

        /// <summary>
        /// Magic attack fuction
        /// </summary>
        /// <returns></returns>
        public static int MagicAttack()
        {
            //Creates a random number to calculate the damage points
            Random rndPoints = new Random();
            //return the points between 10 and 16
            return rndPoints.Next(10, 16);
        }

        /// <summary>
        /// Heal function
        /// </summary>
        /// <returns></returns>
        public static int HealPower()
        {
            //creates a random number to calculate the points
            Random rndPoints = new Random();
            //returns the number between 10 and 20
            return rndPoints.Next(10, 20);
        }


        /// <summary>
        /// displays the game instructions
        /// </summary>
        public static void GameInstructions()
        {
            Console.Clear();
            //Title of the game
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"         ___           _ _     _      _     _   _                        
        /   \___  _ __( ) |_  | | ___| |_  | |_| |__   ___               
       / /\ / _ \| '_ \/| __| | |/ _ \ __| | __| '_ \ / _ \              
      / /_// (_) | | | || |_  | |  __/ |_  | |_| | | |  __/              
     /___,' \___/|_| |_| \__| |_|\___|\__|  \__|_| |_|\___|              
        ___      _                        _       _                      
       / __\__ _| |_   ___  ___ _ __ __ _| |_ ___| |__   /\_/\___  _   _ 
      / /  / _` | __| / __|/ __| '__/ _` | __/ __| '_ \  \_ _/ _ \| | | |
     / /__| (_| | |_  \__ \ (__| | | (_| | || (__| | | |  / \ (_) | |_| |
     \____/\__,_|\__| |___/\___|_|  \__,_|\__\___|_| |_|  \_/\___/ \__,_|");
            Console.WriteLine("");
            Console.ResetColor();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.ForegroundColor = ConsoleColor.Cyan;
            //game instructions area
            Console.WriteLine("   You have a very cute kitty, her name is Laleisha she likes to play ");
            Console.WriteLine("              with her toys and sometimes she likes to get pet");
            Console.WriteLine("      if she is not in the mood to play or be pet she'll scratch you");
            Console.WriteLine("          Your goal is to keep the cat entertained for you to win");
            Console.ResetColor();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }

        /// <summary>
        /// Functions that displays messages to help the user to make a good choice
        /// </summary>
        public static void Messages()
        {//creates a list with all the messages
            List<string> messageList = new List<string>();
            messageList.Add("       Try to bring her attention without being scratched!");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            //dislays the message with a random message 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("    " + messageList[0]);
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }


        /// <summary>
        /// function to control the delay of the screen
        /// </summary>
        /// <param name="secs"></param>
        public static void Delay(int secs)
        {
            System.Threading.Thread.Sleep(secs);
        }


        /// <summary>
        /// function used to show the points deducted for each choice and the 
        /// submoods of the cat
        /// </summary>
        /// <param name="player"></param>
        /// <param name="points"></param>
        public static void SubMoodsTetx(int player, int points)
        {
            Console.WriteLine("");
            //if points equals to 0 and player is the gamer
            Console.ForegroundColor = ConsoleColor.Red;
            if (points == 0 && player == 0)
            {
                Console.WriteLine("                           She's not intersted ");

            }
            //if points greater tahn 0 and less than 15 and player is the gamer
            if (points > 0 && points < 15 && player == 0)
            {
                Console.WriteLine("                           She didnt like it!!!!");
            }
            //if points greater tahn 15 and less than 55 and player is the gamer
            if (points > 15 && points < 55 && player == 0)
            {
                Console.WriteLine("                            She HATED it!!!!");
            }
            Console.ResetColor();
            //if the player is gamer

            Console.ForegroundColor = ConsoleColor.Cyan;
            if (player == 0)

            {     Console.WriteLine("                             The cat gets: " + points); }
            else { Console.WriteLine("                          You get " + points + " scratches"); }
            Console.WriteLine("");
            Console.ResetColor();
        }

        /// <summary>
        /// kitty moods
        /// </summary>
        /// <param name="mood"></param>
        public static void KittyMoods(int mood)
        {
            switch (mood)
            {
                case 1:
                    //initial mood
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@"      ,-~-,       ,-~~~~-,    /\  /\
(\   / ,-, \    ,'        ', /  ~~  \
 \'-' /   \ \  /     _      #  <0 0> \
  '--'     \ \/    .' '.    # =  Y  =/    Meow Meow!
            \     / \   \   `#-..!.-'         
             \   \   \   `\ \\
              )  />  /     \ \\
             / /`/ /`__     \ \\__
            (____)))_)))     \__)))");
                    Console.WriteLine();
                    Console.ResetColor();
                    break;

                case 2:
                    //mood when the gamer loses
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"                                _.---.
                      |\---/|  / ) co|
          ------------;     |-/ /|ffe|---
                      )     (' / `---'
          ===========(       ,'==========
          ||   _     |      |
          || o/ )    |      | o           YOU LOST!!!!!!!!!
          || ( (    /       ;    SHE'S GOING TO SPILL COFFEE IN YOUR           
          ||  \ `._/       /                LAPTOP
          ||   `._        /|
          ||      |\    _/||
        __||_____.' )  |__||____________
         ________\  |  |_________________
                  \ \  `-.
                   `-`---'  ");
                    Console.WriteLine("");
                    Console.ResetColor();
                    break;
                case 3:
                    //mood when the user wins
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("");
                    Console.WriteLine(@"               /\____/\    __
             .'  """"  `,-'  `--.__
        __,- :   -  -  ;    ::     `-. -.__
     ,-sssss `._  `' _,'      ,'~~~::`.sssss-.
    |ssssss ,' ,_`--'_    __,' ::  `  `.ssssss|  YOU WIN!!!!!!!!
   |sssssss `-._____~ `,,'_______,---_;; ssssss| TAKE PICS OF HER  
    |ssssssssss     `--'~{__   ____   ,'ssssss|  BEING CUTE AND UPLOAD 
     `-ssssssssssssssssss ~~~~~~~~~~~~ ssss.-'  THEM TO REDDIT FOR UPVOTES
          `---.sssssssssssssssssssss.---'");
                    Console.WriteLine("");
                    Console.ResetColor();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Animates the ascii art
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void ConsoleDraw(IEnumerable<string> lines, int x, int y)
        {

            //since this is a code i got online i cant explain it 
            //it animastes the first screen 
            if (x > Console.WindowWidth) return;
            if (y > Console.WindowHeight) return;

            var trimLeft = x < 0 ? -x : 0;
            int index = y;

            x = x < 0 ? 0 : x;
            y = y < 0 ? 0 : y;

            var linesToPrint =
                from line in lines
                let currentIndex = index++
                where currentIndex > 0 && currentIndex < Console.WindowHeight
                select new
                {
                    Text = new String(line.Skip(trimLeft).Take(Math.Min(Console.WindowWidth - x, line.Length - trimLeft)).ToArray()),
                    X = x,
                    Y = y++
                };

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var line in linesToPrint)
            {
                Console.SetCursorPosition(line.X, line.Y);
                Console.Write(line.Text);
            }
            Console.ResetColor();


        }

        /// <summary>
        /// intro to the game
        /// </summary>
        public static void GameIntro()
        {
            Console.CursorVisible = false;
       
            //graphics that are displays at the begining of the game
            var arr = new[]
        {
@"             *     ,MMM8&&&.            *",
@"                  MMMM88&&&&&    .       ",
@"                 MMMM88&&&&&&&           ",
@"     *           MMM88&&&&&&&&           ",
@"                 MMM88&&&&&&&&           ",
@"                 'MMM88&&&&&&'           ",
@"                   'MMM8&&&'      *      ",
@"          |\___/|",
@"         =) ^Y^ (=            .              '",
@"          \  ^  /",
@"           )=*=(       *",
@"          /     \",
@"          |     |",
@"         /| | | |\",
@"         \| | |_|/\",
@"  jgs_/\_//_// ___/\_/\_/\_/\_/\_/\_/\_/\_/\_",
@"  |  |  |  | \_) |  |  |  |  |  |  |  |  |  |",
@"  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |",
@"  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |",
@"  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |",
@"  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  ",
@" ", 
@"    ____             _  __     __     __     __  __            ______      __ ",
@"   / __ \____  ____ ( )/ /_   / ___  / /_   / /_/ /_  ___     / ________ _/ /_",
@"  / / / / __ \/ __ \|// __/  / / _ \/ __/  / __/ __ \/ _ \   / /   / __ `/ __/",
@" / /_/ / /_/ / / / / / /_   / /  __/ /_   / /_/ / / /  __/  / /___/ /_/ / /_  ",
@"/_____/\____/_/ /_/  \__/  /_/\_______/   \__/_/ /_/\___/   \____/\__,_/\__/ ", 
@"            ___________________ _/ /______/ /_     __  ______  __  __    ",     
@"           / ___/ ___/ ___/ __ `/ __/ ___/ __ \   / / / / __ \/ / / /    ",     
@"          (__  / /__/ /  / /_/ / /_/ /__/ / / /  / /_/ / /_/ / /_/ /     ",     
@"         /____/\___/_/   \__,_/\__/\___/_/ /_/   \__, /\____/\__,_/     ",      
@"                                                /____/  "   ,     };

            //defines the size of the array "Graphics"
            var maxLength = arr.Aggregate(0, (max, line) => Math.Max(max, line.Length));
            var x = Console.BufferWidth / 2 - maxLength / 2;
            for (int y = -arr.Length; y < Console.WindowHeight + arr.Length; y++)
            {
                //draws the message moving down
                ConsoleDraw(arr, x, y);
                Thread.Sleep(100);
            }
        }
    }
}
