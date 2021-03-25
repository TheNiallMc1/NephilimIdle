using System.Collections.Generic;

namespace UnlimitedBombs.Nephilim.Production
{
    public class Mine : Building
    {
        public Mine()
        {
            buildingName = "Mine";
            
            baseYieldTime = 10f;

            // COST
            resourceCost = new List<Resource>()
            {
                new Wood( 10 )
            };

            // PRODUCTION
            resourceYield = new List<Resource>
            {
                new Stone( 1 )
            };
        }
    }
}