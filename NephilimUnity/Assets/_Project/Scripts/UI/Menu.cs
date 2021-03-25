using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnlimitedBombs.Nephilim.UI
{
    public class Menu : MonoBehaviour
    {
        [Header( "Menu Info" )]
        public string menuName;
        public int menuId;
        
        [Header( "UI Elements" )]
        public TextMeshProUGUI menuTitleDisplay;
        
        [HideInInspector] public MenuButton button;

        private bool initialised;

        public void OnValidate()
        {
            menuTitleDisplay.text = menuName;
            
            if ( button != null )
            {
                button.buttonTitle.text = menuName;
            }

            GameObject go;
            
            ( go = gameObject ).name = string.Format( menuName );
            menuName = go.name;
            menuTitleDisplay.text = menuName;
        }
        
        public void Activate()
        {
            this.gameObject.SetActive( true );
            
            button.ButtonSetEnabled( false );
            button.image.sprite = MenuManager.Instance.currentMenuButtonSprite;
        }
        
        public void Deactivate()
        {
            this.gameObject.SetActive( false );

            button.ButtonSetEnabled( true );
            button.image.sprite = MenuManager.Instance.inactiveMenuButtonSprite;
        }
    }
}
