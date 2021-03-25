using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnlimitedBombs.Nephilim.Production
{
    public class BuildingManager : MonoBehaviour
    {
        #region Singleton

        private static BuildingManager _instance;

        public static BuildingManager Instance => _instance;

        private void Awake()
        {
            if ( _instance != null && _instance != this )
            {
                Destroy( this.gameObject );
            }

            else
            {
                _instance = this;
            }
        }

        #endregion
        
        public BuildingButtonList buildingButtonsList;

        // Building key, amount of the building owned \\
        public readonly Dictionary<Building, int> buildingAmounts = new Dictionary<Building, int>();
        public List<Building> placedBuildings = new List<Building>();

        #region Unlocking

        public void UnlockBuilding( Building building )
        {
            List<Building> keys = buildingAmounts.Keys.ToList();

            IEnumerable<Building> duplicates = FindBuilding( building );

            if ( !duplicates.Any() )
            {
                buildingAmounts.Add( building, 0 );
               
                buildingButtonsList.GenerateButtons();
            }
        }
        
        #endregion


        #region Purchase and Placing

        // Checks to see if the building can be afforded and deducts resources from the player - called when button pressed
        public void PurchaseBuilding( Building building )
        {
            if ( ResourceManager.Instance.CanAfford( building.resourceCost ) )
            {
                ResourceManager.Instance.RemoveResources( building.resourceCost );
                buildingButtonsList.GenerateButtons();
            }
            else
            {
                Debug.Log( "Can't afford!" );
            }
        }

        // Begins the placement of the building on the tile-map - called after Purchase
        private void EnterPlacementMode( Building building )
        {
            // Blueprint sprite on moused over tile
            // Crosshair on moused over tile
            // Click calls PlaceBuilding
        }

        // Cancels building placement
        private void CancelPlacementMode( Building building )
        {
            // Remove blueprint sprite
            // Remove crosshair to appear over tiles
            ResourceManager.Instance.GainResources( building.resourceCost );
        }

        private void PlaceBuilding( Building building )
        {
            building.Create();
            placedBuildings.Add( building );
        }

        #endregion
        
        private IEnumerable<Building> FindBuilding( Building building )
        {
            return buildingAmounts.Keys.Where( x => x.buildingName == building.buildingName );
        }
    }
}