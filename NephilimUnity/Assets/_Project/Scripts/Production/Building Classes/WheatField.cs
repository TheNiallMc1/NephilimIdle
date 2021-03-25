using System.Collections.Generic;

namespace UnlimitedBombs.Nephilim.Production
{
    public class WheatField : Building
    {
        public WheatField()
        {
            buildingName = "Wheat Field";
            
            baseYieldTime = 10f;

            resourceCost = new List<Resource>
            {
                new Wheat( 20f )
            };
            
            resourceYield = new List<Resource>
            {
                new Wheat( 1f )
            };
        }
    }
}