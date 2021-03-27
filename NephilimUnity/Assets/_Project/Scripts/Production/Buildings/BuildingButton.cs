using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnlimitedBombs.Nephilim.ResourceGain;

namespace UnlimitedBombs.Nephilim.Buildings
{
    public class BuildingButton : MonoBehaviour
    {
        private Button button;

        public TextMeshProUGUI nameDisplay;
        public TextMeshProUGUI countDisplay;
        
        [HideInInspector] public Building building;
        
        public void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener( OnClick );
        }

        public void Setup( Building _building, int buildingCount )
        {
            building = _building;

            nameDisplay.text = building.buildingName;
            countDisplay.text = buildingCount.ToString();
        }

        private void CheckIfPurchasable()
        {
            ResourceManager.Instance.CanAfford( building.resourceCost );
        }

        private void OnClick()
        {
            BuildingManager.Instance.PurchaseBuilding( building );
        }
    }
}
