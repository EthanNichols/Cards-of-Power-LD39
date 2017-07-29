using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCityGrid : MonoBehaviour {

    public GameObject ground;
    public int gridSize;

    private float tileSize;

	// Use this for initialization
	void Start () {
        tileSize = ground.GetComponent<RectTransform>().rect.width;
        var citySize = GetComponent<RectTransform>().rect;

        CreateGrid();

        transform.localPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateGrid()
    {
        for (int x=0; x<gridSize; x++)
        {
            for (int y=0; y<gridSize; y++)
            {
                GameObject newTile = Instantiate(ground, Vector3.zero, Quaternion.identity);

                newTile.transform.SetParent(transform);
                float scale = newTile.GetComponent<RectTransform>().localScale.x;
                newTile.transform.localPosition = new Vector2(((gridSize / 2f - .5f) - x), ((gridSize / 2f - .5f) - y)) * (tileSize * scale);

                newTile.name = x + ", " + y;
            }
        }
    }
}
