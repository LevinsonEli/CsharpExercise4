using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenuSystem : IMenuChoiceListener
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

        public void DoWhenMenuItemChosen(MenuItem i_MenuItem)
        {
            if (i_MenuItem.MenuAction != eMenuActions.NoAction)
            {
                switch (i_MenuItem.MenuAction)
                {
                    case eMenuActions.CountCapitals:
                        CountCapitals();
                        break;
                    case eMenuActions.ShowVersion:
                        ShowVersion();
                        break;
                    case eMenuActions.ShowTime:
                        ShowTime();
                        break;
                    case eMenuActions.ShowDate:
                        ShowDate();
                        break;
                    default:
                        throw new Exception(string.Format("No such a mmethod to invoke in menu."));
                }
            }
            else
            {
                i_MenuItem.InnerMenu.Show();
            }
        }

        public void CountCapitals()
        {
            Console.WriteLine("Please enter a string. ");
            string inputStr = Console.ReadLine();
            int countCapitals = 0;

            foreach (char c in inputStr)
            {
                if (isCapital(c))
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

        private bool isCapital(char i_Char)
        {
            return i_Char >= 65 && i_Char <= 90;
        }

        public void ShowVersion()
        {
            Console.WriteLine("Version: 20.2.4.30620");
            Console.WriteLine("Press any key to go back. ");
            Console.ReadKey();
        }

        public void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine("Press any key to go back. ");
            Console.ReadKey();
        }

        public void ShowDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine("Press any key to go back. ");
            Console.ReadKey();
        }

        public void SetMenuAndShow()
        {
            Menu versionAndDigitsInnerMenu = setVersionAndDigitsMenu();
            Menu showDateTimeInnerMenu = setShowDateTimeMenu();
            MenuItem versionAndDigitsMenuItem = new MenuItem(
                string.Format("Version and Digits"),
                versionAndDigitsInnerMenu,
                eMenuActions.NoAction);

            versionAndDigitsMenuItem.AddToMenuNotifierList(this);

            MenuItem showDateTimeMenuItem = new MenuItem(
                string.Format("Show Date/Time"),
                showDateTimeInnerMenu,
                eMenuActions.NoAction);

            showDateTimeMenuItem.AddToMenuNotifierList(this);

            List<MenuItem> mainMenuList = new List<MenuItem>();

            mainMenuList.Add(versionAndDigitsMenuItem);
            mainMenuList.Add(showDateTimeMenuItem);
            m_MainMenu = new Menu(mainMenuList, string.Format("Main Menu"));
            m_MainMenu.Show();
        }

        private Menu setVersionAndDigitsMenu()
        {
            MenuItem countCapitalsMenuItem = new MenuItem(
                string.Format("Count Capitals"),
                null,
                eMenuActions.CountCapitals);

            countCapitalsMenuItem.AddToMenuNotifierList(this);

            MenuItem showVersionMenuItem = new MenuItem(
                string.Format("Show Version"),
                null,
                eMenuActions.ShowVersion);

            showVersionMenuItem.AddToMenuNotifierList(this);

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
                null,
                eMenuActions.ShowTime);

            showTimeMenuItem.AddToMenuNotifierList(this);

            MenuItem showDateMenuItem = new MenuItem(
                string.Format("Show Date"),
                null,
                eMenuActions.ShowDate);

            showDateMenuItem.AddToMenuNotifierList(this);

            List<MenuItem> showDateTimeInnerMenuList = new List<MenuItem>();

            showDateTimeInnerMenuList.Add(showTimeMenuItem);
            showDateTimeInnerMenuList.Add(showDateMenuItem);

            return new Menu(
                showDateTimeInnerMenuList,
                string.Format("Show Date/Time"));
        }
    }
}
