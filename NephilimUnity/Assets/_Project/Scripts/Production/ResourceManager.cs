using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace UnlimitedBombs.Nephilim.Production
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
                }
                
                else
                {
                    resourceEntry.First().resourceAmount += r.resourceAmount;
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

                float resourceAmount = resourceEntry.First().resourceAmount;
                
                float newAmount = Mathf.Max(0, resourceAmount - r.resourceAmount );

                resourceEntry.First().resourceAmount = newAmount;
            }
        }

        public bool CanAfford( IEnumerable<Resource> resources )
        {
            bool[] resourceState = new bool[resources.Count()]; 
            // Making an bool array to track the index of the resources, used to display which resources the player is low on
            
            int iterator = 0;
            
            foreach ( Resource r in resources )
            {
                iterator++;
                
                // Find a matching resource in the resource list
                IEnumerable<Resource> resourceEntry = 
                    allResources.Where( x => x.resourceName == r.resourceName );
                
                // The player doesnt have enough of a given resource
                if ( !resourceEntry.Any() )
                {
                    resourceState[iterator] = false;
                    continue;
                }
                
                float resourceAmount = resourceEntry.First().resourceAmount;

                if ( resourceAmount < r.resourceAmount )
                {
                    resourceState[iterator] = false;
                    continue;
                }
                
                // The player has enough of a resource
                if ( resourceAmount >= r.resourceAmount )
                {
                    resourceState[iterator] = true;
                    continue;
                }
            }

            // Checks if all values in the array are true
            return resourceState.All( x => x );
        }
    }
}