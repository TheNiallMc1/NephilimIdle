using System;
using UnityEngine;
using TMPro;

namespace UnlimitedBombs.Nephilim.UI.TextStyles
{
    [ExecuteAlways]
    public class TextStyleTracker : MonoBehaviour
    {
        public TextStyle textStyle;
        public TextMeshProUGUI textComponent;

        private bool subscribedToRefresh;
        
        public void Start()
        {
            UpdateTextStyle();
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

        public void OnValidate()
        {
            UpdateTextStyle();
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
    }
}
