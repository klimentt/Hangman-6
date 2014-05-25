using System;

namespace Proekt_KPK
{
    class besenka
    {
		// hahaha, izpih edno kilo rakiya vcera i poznavam veche vsichki dumi4ki ot pyrvi puyt, muahahahahahahaaaaaaaa

		//test plmb123 

        //test plmb123 .gitignore in project folder

        //test Dr4g0


        static string RandomizeAWord(string[] arr)
        {
            Random rand = new Random();

            int r = rand.Next(0, arr.Length);

            return arr[r];
        }   
        static void Main(string[] args)
        {
            string[] words = 
            {
                "computer", "programmer" , "software" , "debugger" , "compiler" , "developer" , "algorithm",
                "array" , "method" , "variable"
            };

            int numberOfRevealed = 0;
            int health = 5;
            string word = RandomizeAWord(words);
            string dashWord = new String('-', word.Length);
            while (numberOfRevealed < word.Length && health > 0)
            {
                string input = " ";
                bool correctInput = true;
                Console.WriteLine("The word to be guessed is:{0}", dashWord);
                int letter = 0;



                while ((letter < 'a' || letter > 'z') && (letter < 'A' || letter > 'Z'))
                {
                    if (correctInput)
                    {
                        Console.WriteLine("You've entered incorrect input!");
                    }
                      
                    Console.Write("Input a letter:");
                    input = Console.ReadLine();
                    letter = input[0];
                    if ((letter >= 'A' && letter <= 'Z') && letter != 0)
                    {
                        letter += 32;
                    }
                    correctInput = true;
                }
                  
                correctInput = false;
                bool isMatch = false;

                char[] tempArr = dashWord.ToCharArray();
                for (int i = 0; i < word.Length; i++)
                {
                    if (letter == word[i])
                    {
                        tempArr[i] = word[i];
                        isMatch = true;
                          
                        numberOfRevealed++;
                    }
                }



                dashWord = new string(tempArr);

                if (isMatch)
                { Console.WriteLine("Good job! You revealed {0} of letters and your remaining errors is:{1}", numberOfRevealed, health);
                }
                else
                {
                    health--;
                    Console.WriteLine("Sorry there are no unrevealed letters \"{0}\"). Your health is now {1}", (char)letter, health);
                }
            }

            if (health == 0)
            {
                Console.WriteLine("You lost the game. Try again.");
            }
            else
            {
                Console.WriteLine("You guessed the word \"{0}\" and you won. Congratulations!" , word);
            }
        }
    }
}
