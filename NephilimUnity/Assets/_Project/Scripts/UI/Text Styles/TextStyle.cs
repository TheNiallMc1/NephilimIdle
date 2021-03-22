using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnlimitedBombs.Nephilim.UI.TextStyles
{
    
    [CreateAssetMenu(menuName = "UI Style / Text Style")]
    public class TextStyle : ScriptableObject
    {
        [Header("Style")]
        public TMP_FontAsset font;
        public Color colour;
        public float size;
        
        public delegate void RefreshAllText();
        public RefreshAllText refreshDelegate;

        public void OnValidate()
        {
            refreshDelegate?.Invoke();
        }
    }
}