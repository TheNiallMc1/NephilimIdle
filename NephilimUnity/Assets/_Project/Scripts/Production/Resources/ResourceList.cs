namespace UnlimitedBombs.Nephilim.ResourceGain
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

    public class Iron : Resource
    {
        public Iron( float amount )
        {
            resourceName = this.GetType().Name;
            resourceAmount = amount;
        }
    }
}