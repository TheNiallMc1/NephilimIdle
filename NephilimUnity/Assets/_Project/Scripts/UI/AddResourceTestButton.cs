using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnlimitedBombs.Nephilim.Production;

namespace UnlimitedBombs.Nephilim.UI
{
    public class AddResourceTestButton : MonoBehaviour
    {
        private Button button;

        public void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener( OnClick );
        }

        private void OnClick()
        {
            Resource[] resourcesToGain = new Resource[]
            {
                new Wheat( 10f ),
                new Wood( 5f ), 
            };
            ResourceManager.Instance.GainResources( resourcesToGain );
        }
    }
}