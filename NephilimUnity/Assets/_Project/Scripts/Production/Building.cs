using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnlimitedBombs.Nephilim.Production
{
    public abstract class Building : IBuilding
    {
        public string buildingName;
        
        [Header( "Base Values" )]
        public List<Resource> resourceYield; // The resources this building produces
        
        public float baseYieldTime; // BASE time it takes for this building to yield

        public List<Resource> resourceCost; // List of resources, and their amounts, needed to construct this building

        [Header( "Current Values" )]
        public float yieldTime; // Time it takes for this building to yield

        [Header( "Production" )]
        private Coroutine productionCoroutine;
        public float productionTimeRemaining;

        public void Create()
        {
            yieldTime = baseYieldTime;
            
            BuildingManager.Instance.placedBuildings.Add( this );
        }

        public void Destroy()
        {
            BuildingManager.Instance.placedBuildings.Remove( this );
        }

        public void BeginProduction()
        {
            //productionCoroutine = StartCoroutine( ProductionCoroutine() );
        }

        public void FinishProduction()
        {
            //StopCoroutine( productionCoroutine );
            productionCoroutine = null;
            
            Yield();
        }

        public void Yield()
        {
            ResourceManager.Instance.GainResources( resourceYield );
        }

        public IEnumerator ProductionCoroutine()
        {
            productionTimeRemaining = yieldTime;
            
            yield return new WaitForSecondsRealtime(0.1f);
            
            productionTimeRemaining -= 0.1f;

            if ( productionTimeRemaining <= 0f )
            {
                FinishProduction();
            }
        }
    }
}