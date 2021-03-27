using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnlimitedBombs.Nephilim.ResourceGain.UI;

namespace UnlimitedBombs.Nephilim.ResourceGain
{
    public class ResourceManager : MonoBehaviour
    {
        #region Singleton

        private static ResourceManager _instance;

        public static ResourceManager Instance => _instance;
    
        private void Awake()
        {
            if ( _instance != null && _instance != this )
            {
                Destroy(this.gameObject);
            }
        
            else
            {
                _instance = this;
            }
        }
    
        #endregion

        public ResourceDisplay resourceDisplay;
        public List<Resource> allResources = new List<Resource>();

        public void GainResources( IEnumerable<Resource> resources )
        {
            // Search the list for a resource matching the passed in type. If none exists, add the passed in resource.
            // If one does exist, simply add to the amount
            
            foreach ( Resource r in resources )
            {                
                IEnumerable<Resource> resourceEntry = 
                    allResources.Where( x => x.resourceName == r.resourceName );

                if ( !resourceEntry.Any() )
                {
                    allResources.Add( r );
                    resourceDisplay.NewResourceField( r );
                }
                
                else
                {
                    Resource resource = resourceEntry.First();
                    resourceEntry.First().resourceAmount += r.resourceAmount;
                    resourceDisplay.UpdateResourceField( resource );
                }
            }
        }
        
        public void RemoveResources( IEnumerable<Resource> resources )
        {
            // Search the list for a resource matching the passed in type. If none exists, return.
            // If one does exist, simply remove from the amount
            
            foreach ( Resource r in resources )
            {
                IEnumerable<Resource> resourceEntry = 
                    allResources.Where( x => x.resourceName == r.resourceName );

                if ( !resourceEntry.Any() ) return;

                Resource resource = resourceEntry.First();
                
                float resourceAmount = resource.resourceAmount;
                
                float newAmount = Mathf.Max(0, resourceAmount - r.resourceAmount );

                resource.resourceAmount = newAmount;
                
                resourceDisplay.UpdateResourceField( resource );
            }
        }

        public bool CanAfford( IEnumerable<Resource> resourceCosts )
        {
            bool[] resourceState = new bool[resourceCosts.Count()]; 
            // Making an bool array to track the index of the resources, used to display which resources the player is low on
            
            int iterator = 0;
            
            foreach ( Resource r in resourceCosts )
            {
                // Find a matching resource in the resource list
                IEnumerable<Resource> resourceEntry = 
                    allResources.Where( x => x.resourceName == r.resourceName );
                
                // The player doesnt have enough of a given resource
                if ( !resourceEntry.Any() )
                {
                    resourceState[iterator] = false;
                    iterator++;
                    continue;
                }
                
                float resourceAmount = resourceEntry.First().resourceAmount;
                float requiredAmount = r.resourceAmount;
                
                if ( resourceAmount < requiredAmount )
                {
                    resourceState[iterator] = false;
                    iterator++;
                    continue;
                }
                
                // The player has enough of a resource
                if ( resourceAmount >= requiredAmount )
                {
                    resourceState[iterator] = true;
                    iterator++;
                    continue;
                }
            }

            // Checks if all values in the array are true
            return resourceState.All( x => x );
        }
    }
}