using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Delegates.MainMenuSystem menuTestDelegates = new Delegates.MainMenuSystem();
            menuTestDelegates.SetMenuAndShow();

            Interfaces.MainMenuSystem menuTestInterfaces = new Interfaces.MainMenuSystem();
            menuTestInterfaces.SetMenuAndShow();

            Console.WriteLine("Press any key to end program. ");
            Console.ReadKey();
        }
    }
}
