using TMPro;
using UnityEngine;

namespace UnlimitedBombs.Nephilim.ResourceGain.UI
{
    public class ResourceDisplayField : MonoBehaviour
    {
        public TextMeshProUGUI nameDisplay;
        public TextMeshProUGUI countDisplay;

        private Resource resource;

        public void Setup( Resource _resource )
        {
            resource = _resource;

            UpdateField();
        }

        public void UpdateField()
        {
            UpdateNameDisplay();
            UpdateCountDisplay();
        }

        private void UpdateNameDisplay()
        {
            nameDisplay.text = resource.resourceName;
        }

        private void UpdateCountDisplay()
        {
            countDisplay.text = resource.resourceAmount.ToString();
        }
    }
}