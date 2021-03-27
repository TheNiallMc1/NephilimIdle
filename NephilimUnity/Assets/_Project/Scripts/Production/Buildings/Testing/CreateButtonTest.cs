using UnityEngine;

using UnlimitedBombs.Nephilim.ResourceGain;

// ReSharper disable Unity.IncorrectMonoBehaviourInstantiation

namespace UnlimitedBombs.Nephilim.Buildings.Testing
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
