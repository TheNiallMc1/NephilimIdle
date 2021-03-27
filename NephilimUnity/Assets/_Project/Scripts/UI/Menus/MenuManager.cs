using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace UnlimitedBombs.Nephilim.UI.Menus
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

        [Header("Menus")]
        private Menu currentMenu;

        public Menu initialMenu;

        public void Start()
        {
            OpenMenu( initialMenu );
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
