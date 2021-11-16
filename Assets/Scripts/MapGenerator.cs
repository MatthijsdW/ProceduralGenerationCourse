using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public TileGenerator tilePrefab;
    public int numX = 2, numZ = 2;

    private void Start()
    {
        GenerateTiles();
    }

    private void GenerateTiles()
    {
        float tileSize = tilePrefab.GetComponent<MeshGenerator>().xSize;

        for (int x = 0; x < numX; x++)
            for (int z = 0; z < numZ; z++)
            {
                GameObject tileObj = Instantiate(tilePrefab.gameObject, transform);
                tileObj.transform.position = new Vector3((x - (numX / 2.0f)) * tileSize, 0, (z - (numZ / 2.0f)) * tileSize);

                float offsetRate = (tilePrefab.noiseSampleSize - 1) / tilePrefab.scale;
                tileObj.GetComponent<TileGenerator>().offset = new Vector2(x * offsetRate, z * offsetRate);
            }
    }
}
