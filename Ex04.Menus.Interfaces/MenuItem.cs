using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_Text;
        private Menu m_InnerMenu;
        private eMenuActions m_MenuAction;

        private List<IMenuChoiceListener> m_MenuNotifierList;

        public void AddToMenuNotifierList(IMenuChoiceListener i_NewListener)
        {
            m_MenuNotifierList.Add(i_NewListener);
        }

        public void RemoveFromMenuNotifierList(IMenuChoiceListener i_Listener)
        {
            m_MenuNotifierList.Remove(i_Listener);
        }

        public eMenuActions MenuAction
        {
            get
            {
                return m_MenuAction;
            }
        }

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

        public MenuItem(string i_Text, Menu i_InnerMenu, eMenuActions i_MenuAction)
        {
            Text = i_Text;
            m_InnerMenu = i_InnerMenu; // ref
            m_MenuAction = i_MenuAction;
            m_MenuNotifierList = new List<IMenuChoiceListener>();
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

        public void DoWhenChosen()
        {
            System.Console.Clear();
            OnChosen();
        }

        protected virtual void OnChosen()
        {
            if (m_MenuNotifierList != null)
            {
                foreach (IMenuChoiceListener listener in m_MenuNotifierList)
                {
                    listener.DoWhenMenuItemChosen(this);
                }
            }
        }
    }
}
