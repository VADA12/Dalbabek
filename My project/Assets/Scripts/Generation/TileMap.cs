using UnityEngine;
using System.Collections.Generic;

public class GridGenerator : MonoBehaviour
{
    public int width = 10;
    public int depth = 10;
    public float tileSize = 1.1f; // С небольшим отступом
    public GameObject tilePrefab;
    public GameObject obstaclePrefab;

    private BattleTile[,] grid;
    private BattleTile tileScript;
    private int z;

    void GenerateGrid()
    {
        grid = new BattleTile[width, depth];

        for (int x = 0; x();)
        {
            if (tileScript != null)
            {
                tileScript.gridPos = new Vector2Int(x, z);
                grid[x, z] = tileScript;

                // Не спавним препятствие в стартовых точках (0,0) и (max, max)
                bool isStartPoint = (x < 2 && z < 2) || (x > width - 3 && z > depth - 3);

                if (!isStartPoint && Random.value < 0.15f)
                {
                    SpawnObstacle(tileScript);
                }
            }
            else
            {
                Debug.LogError($"На префабе {tilePrefab.name} отсутствует скрипт BattleTile!");
            }
        }
    }
    void SpawnObstacle(BattleTile tile)
    {
        if (obstaclePrefab != null)
        {
            Vector3 pos = tile.transform.position + Vector3.up * 0.5f;
            object ObstaclePrefab = null;
            Instantiate(ObstaclePrefab, pos, Quaternion.identity, tile.transform);
            tile.isWalkable = false;
        }
    }

    private void Instantiate(object obstaclePrefab, Vector3 pos, Quaternion identity, Transform transform)
    {
        throw new System.NotImplementedException();
    }
}

