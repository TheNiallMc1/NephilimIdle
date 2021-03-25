using UnityEngine;
using TMPro;

namespace UnlimitedBombs.Nephilim.UI.TextStyles
{
    [ExecuteAlways]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextStyleTracker : MonoBehaviour
    {
        public TextStyle textStyle;
        public TextMeshProUGUI textComponent;

        private bool subscribedToRefresh;
        
        public void Start()
        {
            UpdateTextStyle();
            UpdateKeysInText();
        }

        public void OnValidate()
        {
            UpdateTextStyle();
            UpdateKeysInText();
        }

        public void OnEnable()
        {
            if ( textComponent == null )
            {
                textComponent = this.GetComponent<TextMeshProUGUI>();
            } 
            
            if ( textStyle == null ) return;
            
            UpdateTextStyle();
            
            textStyle.refreshDelegate += UpdateTextStyle;
            subscribedToRefresh = true;
        }
        
        public void OnDisable()
        {
            if ( textStyle == null ) return;
            
            textStyle.refreshDelegate -= UpdateTextStyle;
            subscribedToRefresh = false;
        }

        private void UpdateTextStyle()
        {
            if ( textStyle == null ) return;

            if ( !subscribedToRefresh )
            {
                textStyle.refreshDelegate += UpdateTextStyle;
                subscribedToRefresh = true;
            }
            
            textComponent.font = textStyle.font;
            textComponent.color = textStyle.colour;
            textComponent.fontSize = textStyle.size;
        }
        
        private void UpdateKeysInText()
        {
            string content = textComponent.text;
        }
    }
}
