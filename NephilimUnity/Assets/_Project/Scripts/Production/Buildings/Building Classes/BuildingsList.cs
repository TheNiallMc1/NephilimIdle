using System.Collections.Generic;
using UnlimitedBombs.Nephilim.Buildings;

namespace UnlimitedBombs.Nephilim.ResourceGain
{
    public class WheatField : Building
    {
        public WheatField()
        {
            buildingName = "Wheat Field";

            yieldTime = 1f;
            
            resourceCost = new List<Resource>
            {
                new Wheat( 10f )
            };
            
            resourceYield = new List<Resource>
            {
                new Wheat( 1f )
            };
        }
    }
    
    public class Mine : Building
    {
        public Mine()
        {
            buildingName = "Mine";
            
            yieldTime = 10f;
            
            // COST
            resourceCost = new List<Resource>()
            {
                new Wood( 10f )
            };

            // PRODUCTION
            resourceYield = new List<Resource>
            {
                new Stone( 1f )
            };
        }
    }
}