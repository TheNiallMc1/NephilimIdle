using System;
using System.Collections;
using UnityEngine;
using UnlimitedBombs.Nephilim.ResourceGain;

namespace UnlimitedBombs.Nephilim.Buildings
{
    public class BuildingObject : MonoBehaviour
    {
        private Building building;

        private Coroutine productionCoroutine;

        private float productionTimeRemaining;

        public void Setup( Building _building )
        {
            building = _building;
        
            print( building.buildingName );
            
            BeginProduction();
        }

        private void BeginProduction()
        {
            productionTimeRemaining = building.yieldTime;

            productionCoroutine = StartCoroutine( ProductionCoroutine() );
        }

        private void FinishProduction()
        {
            StopCoroutine( productionCoroutine );
            productionCoroutine = null;
            
            ResourceManager.Instance.GainResources( building.resourceYield );
            
            BeginProduction();
        }

        private IEnumerator ProductionCoroutine()
        {
            while ( productionTimeRemaining > 0 )
            {
                yield return new WaitForSecondsRealtime(0.1f);
                productionTimeRemaining -= 0.1f;
            }
            
            FinishProduction();
        }
    }
}