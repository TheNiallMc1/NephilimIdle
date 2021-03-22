using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnlimitedBombs.Nephilim.UI
{
    public class OpenMenuButton : MonoBehaviour
    {
        public Menu menuToOpen;
        private Button button;
        
        public void Start()
        {
            button = this.GetComponent<Button>();
            
            menuToOpen.button = button;

            button.onClick.AddListener( OnClick );
        }

        private void OnClick()
        {
            MenuManager.Instance.OpenMenu( menuToOpen );
        }
    }
}