namespace UnlimitedBombs.Nephilim.Production
{
    public class Wheat : Resource
    {
        public Wheat( float amount )
        {
            resourceName = this.GetType().Name;
            resourceAmount = amount;    
        }
    }
    
    public class Wood : Resource
    {
        public Wood( float amount )
        {
            resourceName = this.GetType().Name;
            resourceAmount = amount;
        }
    }
    
    public class Stone : Resource
    {
        public Stone( float amount )
        {
            resourceName = this.GetType().Name;
            resourceAmount = amount;
        }
    }
}