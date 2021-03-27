using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnlimitedBombs.Nephilim.Buildings
{
    public class BuildingButtonList : MonoBehaviour
    {
        public GameObject buttonPrefab;
        
        public Transform leftColumn;
        public Transform rightColumn;

        public List<BuildingButton> leftButtons = new List<BuildingButton>();
        public List<BuildingButton> rightButtons = new List<BuildingButton>();

        private Dictionary<Building, int> buildingAmounts;
        private bool buttonExists;

        public void UpdateButtons()
        {
            buildingAmounts = BuildingManager.Instance.buildingAmounts;

            List<Building> buildings = buildingAmounts.Keys.ToList();
            buildings.Reverse();

            foreach ( Building b in buildings )
            {
                buttonExists = false; // Resetting the boolean used for checks
                
                UpdateButtonIfExists( b );

                if ( !buttonExists )
                {
                    NewButton( b, buildingAmounts[b] );
                }
            }
        }

        private void UpdateButtonIfExists( Building b )
        {            
            IEnumerable<BuildingButton> existingButtonLeft =
                leftButtons.Where( x => x.building.buildingName == b.buildingName );

            if ( existingButtonLeft.Any() )
            {
                existingButtonLeft.First().Setup( b, buildingAmounts[b] );
                
                buttonExists = true;
                return;
            }

            IEnumerable<BuildingButton> exitingButtonRight =
                rightButtons.Where( x => x.building.buildingName == b.buildingName );

            if ( exitingButtonRight.Any() )
            {
                exitingButtonRight.First().Setup( b, buildingAmounts[b] );
                
                buttonExists = true; 
                return;
            }

            buttonExists = false;
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
                
                rightButtons.Add( buttonScript );
            }
            
            else
            {
                button = Instantiate( buttonPrefab, leftColumn );
            
                buttonScript = button.GetComponent<BuildingButton>();
                buttonScript.Setup( building, buildingCount );
                
                leftButtons.Add( buttonScript );
            }
        }
    }
}
