using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnlimitedBombs.Nephilim.UI
{
    public class MenuButton : MonoBehaviour
    {
        public Menu menuToOpen;
        public TextMeshProUGUI buttonTitle;
        public Image image;
        
        private Button button;

        private bool initialised;
        
        public void Start()
        {
            button = this.GetComponent<Button>();
            
            menuToOpen.button = this;

            button.onClick.AddListener( OnClick );

            initialised = true;
        }

        public void OnValidate()
        {
            if ( !initialised ) return;
            
            button = this.GetComponent<Button>();

            menuToOpen.button = this;
        }

        private void OnClick()
        {
            MenuManager.Instance.OpenMenu( menuToOpen );
        }

        public void ButtonSetEnabled(bool active)
        {
            button.enabled = active;
        }
    }
}