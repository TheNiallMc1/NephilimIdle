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

        public Menu currentMenu;
        
        public void OpenMenu(Menu menu)
        {
            currentMenu.Deactivate();
            
            menu.Activate();
            
            currentMenu = menu;
        }
    }
}
