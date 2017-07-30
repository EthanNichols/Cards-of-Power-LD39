using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCityGrid : MonoBehaviour {

    //The default tile
    //The size of the grid
    public GameObject ground;
    public int gridSize;

    //The size of the tiles
    private float tileSize;

	// Use this for initialization
	void Start () {

        //Set the size of the tiles
        tileSize = ground.GetComponent<RectTransform>().rect.width;

        //Create the grid
        CreateGrid();

        //Move the city to the center of the player's side of the screen
        transform.localPosition = Vector3.zero;

        GetComponent<Buildings>().GetTiles();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateGrid()
    {
        //X position of the tile
        //Y position of the tile
        for (int x=0; x<gridSize; x++)
        {
            for (int y=0; y<gridSize; y++)
            {

                //Create a new tile
                GameObject newTile = Instantiate(ground, Vector3.zero, Quaternion.identity);

                //Set the parent of the tile for cleanliness
                newTile.transform.SetParent(transform);

                //Calculate the scale of the tile
                //Calculate the position of the tile in the grid
                newTile.GetComponent<RectTransform>().localScale = new Vector3(5, 5, 5);
                float scale = newTile.GetComponent<RectTransform>().localScale.x;
                newTile.transform.localPosition = new Vector2(((gridSize / 2f - .5f) - x), ((gridSize / 2f - .5f) - y)) * (tileSize * scale);

                //Set the name of the tile to its grid position
                newTile.name = x + ", " + y;
            }
        }
    }
}
