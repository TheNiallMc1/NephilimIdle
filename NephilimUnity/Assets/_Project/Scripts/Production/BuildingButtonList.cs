using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnlimitedBombs.Nephilim.Production
{
    public class BuildingButtonList : MonoBehaviour
    {
        public GameObject buttonPrefab;
        
        public Transform leftColumn;
        
        public Transform rightColumn;

        public void GenerateButtons()
        {
            ClearButtons();
            
            Dictionary<Building, int> buildingAmounts = BuildingManager.Instance.buildingAmounts;
            List<Building> keys = buildingAmounts.Keys.ToList();
            keys.Reverse();
            
            foreach ( Building building in keys )
            {
                NewButton( building, buildingAmounts[building] );
            }
        }

        private void ClearButtons()
        {
            foreach ( Transform t in leftColumn )
            {
                Destroy(t.gameObject);
            }

            foreach ( Transform t in rightColumn )
            {
                Destroy(t.gameObject);
            }
        }

        private void NewButton( Building building, int buildingCount )
        {
            GameObject button;
            BuildingButton buttonScript;

            if ( leftColumn.childCount > rightColumn.childCount )
            {
                button = Instantiate( buttonPrefab, rightColumn );
            
                buttonScript = button.GetComponent<BuildingButton>();
                buttonScript.Setup( building, buildingCount );
            }
            
            else
            {
                button = Instantiate( buttonPrefab, leftColumn );
            
                buttonScript = button.GetComponent<BuildingButton>();
                buttonScript.Setup( building, buildingCount );
            }
            
            
        }
    }
}
