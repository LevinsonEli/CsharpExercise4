using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class Menu
    {
        private readonly List<MenuItem> r_ItemsList;
        private string m_Title;
        private int m_MenuLevel;

        public List<MenuItem> ItemsList
        {
            get
            {
                return r_ItemsList;
            }
        }

        public int MenuLevel
        {
            get
            {
                return m_MenuLevel;
            }
            set
            {
                m_MenuLevel = value;
            }
        }

        public Menu(List<MenuItem> i_MenuItemsList, string i_Title)
        {
            r_ItemsList = new List<MenuItem>();
            m_Title = i_Title;
            MenuLevel = 1;

            if (i_MenuItemsList != null)
            {
                for (int i = 0; i < i_MenuItemsList.Count; i++)
                {
                    r_ItemsList.Add(i_MenuItemsList[i]);
                    r_ItemsList[i].InnerMenuLevelUp();
                }
            }
        }

        public void Show()
        {
            int menuChoice;
            bool gotdCorrectInput;
            string inputErrorMsg = string.Format(
                    "Incorrect input. Only numbers from {0} to {1} available.{2}",
                    0,
                    r_ItemsList.Count,
                    Environment.NewLine);

            System.Console.Clear();
            printMenu();
            gotdCorrectInput = gotMenuChoiceSuccessfully(out menuChoice);

            while (!gotdCorrectInput || menuChoice != 0)
            {
                if (gotdCorrectInput && menuChoice != 0)
                {
                    r_ItemsList[menuChoice - 1].DoWhenChosen();
                }

                System.Console.Clear();
                printMenu();
                Console.Write(gotdCorrectInput ? string.Empty : inputErrorMsg);
                gotdCorrectInput = gotMenuChoiceSuccessfully(out menuChoice);
            }
        }

        private void printMenu()
        {
            Console.WriteLine(string.Format("{0}. Level {1}", m_Title, MenuLevel));
            string backOrExitMsg = (MenuLevel == 1) ? "Exit" : "Back";

            Console.WriteLine(string.Format("0 {0}", backOrExitMsg));

            for (int i = 0; i < r_ItemsList.Count; i++)
            {
                Console.WriteLine(string.Format("{0} {1}", i + 1, r_ItemsList[i].Text));
            }
        }

        private bool gotMenuChoiceSuccessfully(out int o_MenuChoice)
        {
            Console.WriteLine("Please select an option.");

            return int.TryParse(Console.ReadLine(), out o_MenuChoice) &&
                doesOptionExistInTheMenu(o_MenuChoice);
        }

        private bool doesOptionExistInTheMenu(int i_MenuChoice)
        {
            return i_MenuChoice >= 0 && i_MenuChoice <= r_ItemsList.Count;
        }
    }
}
