using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class PaddleTileCreator : MonoBehaviour
{
    public GameObject tilePrefab;
    
    void Awake()
    {
        ResetPaddleTiles();
    }

    [ContextMenu("Reset the Paddle Tiles")]
    void ResetPaddleTiles()
    {
        // Destroy old tiles
        GameObject[] oldTiles = GameObject.FindGameObjectsWithTag("PaddleTile");
        if(oldTiles != null) 
        {
            foreach(GameObject tile in oldTiles)
            {
                if(tile.transform.parent == gameObject.transform)
                {
                    DestroyImmediate(tile);
                }
            }
            oldTiles = null;
        }

        // Instantiate new tiles
        GameObject[,] tiles = new GameObject[3,3];
        float tileDistanceX = tilePrefab.transform.localScale.x;
        float tileDistanceY = tilePrefab.transform.localScale.y;
        for(int i=-1;i<2;i++)
        {
            for(int j=-1;j<2;j++)
            {
                Vector3 tilePosition = new Vector3(tileDistanceX*i,tileDistanceY*j,0);
                GameObject tile = (GameObject) PrefabUtility.InstantiatePrefab(tilePrefab, transform);
                tile.transform.localPosition = tilePosition;
                Debug.Log(tile.transform.localScale);
                //tile.transform.localScale = tile.transform.localScale;
                Debug.Log(tile.transform.localScale);
                tile.name = "Tile"+i+j;
                tile.GetComponent<PaddleTileCollisionHandler>().tilePosition = new Vector2(i,j);

                tiles[i+1,j+1] = tile;
            }
        }

        Debug.Log("The Paddle Tiles were Reset.");
    }


}
