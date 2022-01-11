using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private string m_Text;
        private Menu m_InnerMenu;

        public delegate void MenuItemActionHandler();

        public Menu InnerMenu
        {
            get
            {
                return m_InnerMenu;
            }
        }

        public string Text
        {
            get
            {
                return m_Text;
            }

            set
            {
                m_Text = value;
            }
        }

        public MenuItem(string i_Text, Menu i_InnerMenu)
        {
            Text = i_Text;
            m_InnerMenu = i_InnerMenu; // ref
        }

        public void InnerMenuLevelUp()
        {
            if (InnerMenu != null)
            {
                InnerMenu.MenuLevel++;
                foreach (MenuItem item in InnerMenu.ItemsList)
                {
                    item.InnerMenuLevelUp();
                }
            }
        }

        public event MenuItemActionHandler Chosen;

        public void DoWhenChosen()
        {
            System.Console.Clear();
            OnChosen();
        }

        protected virtual void OnChosen()
        {
            if (Chosen != null)
            {
                Chosen.Invoke();
            }
        }
    }
}
