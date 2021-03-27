using System.Collections.Generic;
using UnityEngine;

namespace UnlimitedBombs.Nephilim.ResourceGain.UI
{
    public class ResourceDisplay : MonoBehaviour
    {
        public GameObject displayFieldPrefab;

        private readonly Dictionary<Resource, ResourceDisplayField> resourceDict = new Dictionary<Resource, ResourceDisplayField>();

        public void NewResourceField( Resource resource )
        {
            if ( resourceDict.ContainsKey( resource ) ) return;
            
            GameObject newField = Instantiate( displayFieldPrefab, this.transform );
            ResourceDisplayField fieldScript = newField.GetComponent<ResourceDisplayField>();
            
            resourceDict.Add( resource, fieldScript );
            
            fieldScript.Setup( resource );
        }

        public void UpdateResourceField( Resource resource )
        {
            if ( !resourceDict.ContainsKey( resource ) ) return;
            
            resourceDict[resource].UpdateField();
        }
    }
}