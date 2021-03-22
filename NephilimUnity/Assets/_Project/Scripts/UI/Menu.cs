using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

namespace UnlimitedBombs.Nephilim.UI
{
    public class Menu : MonoBehaviour
    {
        private GameObject thisObject;
        [HideInInspector] public Button button;
        
        public void Start()
        {
            thisObject = this.gameObject;
        }
        
        public void Activate()
        {
            this.gameObject.SetActive( true );
            
            button.enabled = false;
            button.image.sprite = MenuManager.Instance.currentMenuButtonSprite;
        }
        
        public void Deactivate()
        {
            this.gameObject.SetActive( false );

            button.enabled = true;
            button.image.sprite = MenuManager.Instance.inactiveMenuButtonSprite;
        }
    }
}
