using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnlimitedBombs.Nephilim.Buildings.Placement
{
    public class BuildingGrid : MonoBehaviour
    {
        [Header( "Grid" )]
        public Tilemap tilemap;

        [Range(1, 5)] public int gridSize = 5;

        public TerrainTile[] placedTiles;

        [Header( "Terrain" )]
        public TerrainTile[] terrainTiles;

        public void Start()
        {
            int arraySize = ( gridSize * gridSize );
            placedTiles = new TerrainTile[arraySize];

            GenerateTerrain();
        }

        private void GenerateTerrain()
        {
            int currentCellIndex = -1;

            for ( int x = 0; x > -gridSize; x-- )
            {
                for ( int y = 0; y > -gridSize; y-- )
                {
                    currentCellIndex++;
                    
                    Vector3Int tilePosition = new Vector3Int( x, y, 0 );
                    
                    TerrainTile terrainTile = GetRandomTerrainTile();
                    placedTiles[currentCellIndex] = terrainTile;
                    
                    Tile tile = terrainTile.tile;
                    
                    terrainTile.cellPosition = tilePosition;

                    tilemap.SetTile( tilePosition, tile );
                }
            }
        }

        private TerrainTile GetRandomTerrainTile()
        {
            int randomIndex = Random.Range( 0, terrainTiles.Length );

            TerrainTile terrainTile = Instantiate( terrainTiles[randomIndex] );
            return terrainTile;
        }

        // PLACEMENT MODE \\

        // Raycast to render texture from mouse
        // Convert texture space to world space of the object
        // From cellPositions[], find the Vector that is closest to the current mouse position in world space. Store as closestCell
        // Render semi-transparent sprite of the current building at that cell position

        // ON CLICK \\

        // Check if the closest cell already has a building. If it does, don't allow placement
        // Check if the closest cell is water. If it is, don't allow placement

        // Use SetTile to create the appropriate tile at closestCell ( use WorldToCell )
        // Create a BuildingObject script / MonoBehaviour which stores information on that building ( production coroutine, upgrade level, etc. )

        // CELL INFORMATION \\

        // Cell class which stores: world position, building on cell (if any), type of cell (mountains, forest, etc.)
    }
}