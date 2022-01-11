using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenuSystem
    {
        private Menu m_MainMenu;

        public void ShowMainMenu()
        {
            m_MainMenu.Show();
        }

        public MainMenuSystem(Menu i_MainMenu)
        {
            m_MainMenu = i_MainMenu;
        }

        public MainMenuSystem()
        {
            m_MainMenu = null;
        }

        private void countCapitalsMenuItem_Chosen()
        {
            Console.WriteLine("Please enter a string. ");
            string inputStr = Console.ReadLine();
            int countCapitals = 0;

            foreach (char letter in inputStr)
            {
                if (isCapitalLetter(letter))
                {
                    countCapitals++;
                }
            }

            Console.WriteLine(string.Format(
                "There are {0} capital letters in the string",
                countCapitals));

            Console.WriteLine("Press any key to go back. ");
            Console.ReadKey();
        }

        private bool isCapitalLetter(char i_Char)
        {
            return i_Char >= 65 && i_Char <= 90;
        }

        private void showVersionMenuItem_Chosen()
        {
            Console.WriteLine("Version: 20.2.4.30620");
            Console.WriteLine("Press any key to go back. ");
            Console.ReadKey();
        }

        private void showTimeMenuItem_Chosen()
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine("Press any key to go back. ");
            Console.ReadKey();
        }

        private void showDateMenuItem_Chosen()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine("Press any key to go back. ");
            Console.ReadKey();
        }

        public void SetMenuAndShow()
        {
            Menu versionAndDigitsInnerMenu = setVersionAndDigitsMenu();
            MenuItem versionAndDigitsMenuItem = new MenuItem(
                string.Format("Version and Digits"),
                versionAndDigitsInnerMenu);
            versionAndDigitsMenuItem.Chosen += new MenuItem.MenuItemActionHandler(versionAndDigitsMenuItem.InnerMenu.Show);

            Menu showDateTimeInnerMenu = setShowDateTimeMenu();
            MenuItem showDateTimeMenuItem = new MenuItem(
                string.Format("Show Date/Time"),
                showDateTimeInnerMenu);
            showDateTimeMenuItem.Chosen += new MenuItem.MenuItemActionHandler(showDateTimeMenuItem.InnerMenu.Show);

            List<MenuItem> mainMenuList = new List<MenuItem>();
            mainMenuList.Add(versionAndDigitsMenuItem);
            mainMenuList.Add(showDateTimeMenuItem);

            Menu mainMenu = new Menu(mainMenuList, string.Format("Main Menu"));

            mainMenu.Show();
        }

        private Menu setVersionAndDigitsMenu()
        {
            MenuItem countCapitalsMenuItem = new MenuItem(
                string.Format("Count Capitals"),
                null);

            countCapitalsMenuItem.Chosen += new MenuItem.MenuItemActionHandler(countCapitalsMenuItem_Chosen);

            MenuItem showVersionMenuItem = new MenuItem(
                string.Format("Show Version"),
                null);

            showVersionMenuItem.Chosen += new MenuItem.MenuItemActionHandler(showVersionMenuItem_Chosen);

            List<MenuItem> versionAndDigitsInnerMenuList = new List<MenuItem>();

            versionAndDigitsInnerMenuList.Add(countCapitalsMenuItem);
            versionAndDigitsInnerMenuList.Add(showVersionMenuItem);

            return new Menu(
                 versionAndDigitsInnerMenuList,
                 string.Format("Version and Digits"));
        }

        private Menu setShowDateTimeMenu()
        {
            MenuItem showTimeMenuItem = new MenuItem(
                string.Format("Show Time"),
                null);

            showTimeMenuItem.Chosen += new MenuItem.MenuItemActionHandler(showTimeMenuItem_Chosen);

            MenuItem showDateMenuItem = new MenuItem(
                string.Format("Show Date"),
                null);

            showDateMenuItem.Chosen += new MenuItem.MenuItemActionHandler(showDateMenuItem_Chosen);

            List<MenuItem> showDateTimeInnerMenuList = new List<MenuItem>();

            showDateTimeInnerMenuList.Add(showTimeMenuItem);
            showDateTimeInnerMenuList.Add(showDateMenuItem);

            return new Menu(
                showDateTimeInnerMenuList,
                string.Format("Show Date/Time"));
        }
    }
}
