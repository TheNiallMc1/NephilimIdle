using System.Collections;

namespace UnlimitedBombs.Nephilim.Production
{
    public interface IBuilding
    {
        void Create();

        void Destroy();

        void BeginProduction();
        
        void FinishProduction();
        
        IEnumerator ProductionCoroutine();

        void Yield();
    }
}