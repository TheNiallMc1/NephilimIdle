using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnlimitedBombs.Nephilim.Buildings.Placement
{
    [CreateAssetMenu(menuName = "New Terrain Tile", fileName = "New Terrain Tile")]
    public class TerrainTile : ScriptableObject
    {
        public Tile tile;
        
        public string terrainName;
        [TextArea]public string terrainDescription;
        
        [HideInInspector] public Vector3Int cellPosition;
        [HideInInspector] public Vector3 worldPosition;
        public Building currentBuilding;
    }
}