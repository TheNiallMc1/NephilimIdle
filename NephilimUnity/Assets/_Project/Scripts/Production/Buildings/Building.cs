using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnlimitedBombs.Nephilim.ResourceGain;

namespace UnlimitedBombs.Nephilim.Buildings
{
    public abstract class Building : IBuilding
    {
        public string buildingName;
        
        [Header( "Base Values" )]
        public List<Resource> resourceYield; // The resources this building produces
    
        public List<Resource> resourceCost; // List of resources, and their amounts, needed to construct this building

        [Header( "Current Values" )]
        public float yieldTime; // Time it takes for this building to yield


        public void Destroy()
        {
            throw new System.NotImplementedException();
        }

        public void Yield()
        {
            ResourceManager.Instance.GainResources( resourceYield );
        }
    }
}