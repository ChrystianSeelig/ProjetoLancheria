using System;

namespace desafioLanches
{
    class Navigation
    {
        public static int AnswerTest(string optionOne, string optionTwo)
        {
            string userAnswer = Console.ReadLine();
            while (userAnswer != optionOne && userAnswer != optionTwo)
            {
                Console.WriteLine("Desculpe, mas essa opção não existe.");
                Console.WriteLine("Por favor, digite o número da opção que você deseja acessar.");
                userAnswer = Console.ReadLine();
            }
            int convertedUserAnswer = Convert.ToInt32(userAnswer);
            return convertedUserAnswer;
        }
        public static int AnswerTest(string optionOne, string optionTwo, string optionThree)
        {
            string userAnswer = Console.ReadLine();
            while (userAnswer != optionOne && userAnswer != optionTwo && userAnswer != optionThree)
            {
                Console.WriteLine("Desculpe, mas essa opção não existe.");
                Console.WriteLine("Por favor, digite o número da opção que você deseja acessar.");
                userAnswer = Console.ReadLine();
            }
            int convertedUserAnswer = Convert.ToInt32(userAnswer);
            return convertedUserAnswer;
        }
        public static int AnswerTest(string optionOne, string optionTwo, string optionThree, string optionFour, string optionFive)
        {
            string userAnswer = Console.ReadLine();
            while (userAnswer != optionOne && userAnswer != optionTwo && userAnswer != optionThree && userAnswer != optionFour && userAnswer != optionFive)
            {
                Console.WriteLine("Desculpe, mas essa opção não existe.");
                Console.WriteLine("Por favor, digite o número da opção que você deseja acessar.");
                userAnswer = Console.ReadLine();
            }
            int convertedUserAnswer = Convert.ToInt32(userAnswer);
            return convertedUserAnswer;
        }
    }
}
