using UnityEngine;

namespace UnlimitedBombs.Nephilim.UI
{
    public class Menu : MonoBehaviour
    {
        public GameObject thisObject;
        
        public void Start()
        {
            thisObject = this.gameObject;
        }
        
        public void Activate()
        {
            thisObject.SetActive( true );
        }
        
        public void Deactivate()
        {
            thisObject.SetActive( false );
        }
    }
}
