using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnlimitedBombs.Nephilim.Production;

namespace UnlimitedBombs.Nephilim.UI
{
    public class RemoveResourceTestButton : MonoBehaviour
    {
        private Button button;

        public void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener( OnClick );
        }

        private void OnClick()
        {
            Resource[] resourcesToRemove = new Resource[]
            {
                new Wheat( 10f ),
                new Wood( 5f ), 
            };
            ResourceManager.Instance.RemoveResources( resourcesToRemove );
        }
    }
}