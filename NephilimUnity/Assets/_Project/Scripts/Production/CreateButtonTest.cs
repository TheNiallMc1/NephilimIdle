using UnityEngine;
// ReSharper disable Unity.IncorrectMonoBehaviourInstantiation

namespace UnlimitedBombs.Nephilim.Production
{
    public class CreateButtonTest : MonoBehaviour
    {
        public void UnlockWheatFields()
        {
            BuildingManager.Instance.UnlockBuilding( new WheatField() );
        }

        public void UnlockMines()
        {
            BuildingManager.Instance.UnlockBuilding( new Mine() );
        }
    }
}
