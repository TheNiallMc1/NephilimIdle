using System;
using UnityEngine;

namespace UnlimitedBombs.Nephilim.UI
{
    public class MenuManager : MonoBehaviour
    {
        #region Singleton

        private static MenuManager _instance;

        public static MenuManager Instance => _instance;
    
        private void Awake()
        {
            if ( _instance != null && _instance != this )
            {
                Destroy(this.gameObject);
            }
        
            else
            {
                _instance = this;
            }
        }
    
        #endregion

        [Header( "UI" )]
        public Sprite currentMenuButtonSprite;
        public Sprite inactiveMenuButtonSprite;

        [Header("Menu")]
        private Menu currentMenu;

        public Menu settlementMenu;
        public Menu worldMenu;
        public Menu missionsMenu;
        public Menu nephilimMenu;

        public void Start()
        {
            OpenMenu( settlementMenu );
        }

        public void OpenMenu(Menu menu)
        {
            if ( menu == currentMenu ) return;

            if ( currentMenu != null )
            {
                currentMenu.Deactivate();
            }
            
            menu.Activate();
            
            currentMenu = menu;
        }
    }
}
