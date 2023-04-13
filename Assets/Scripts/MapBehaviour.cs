using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapBehaviour : MonoBehaviour
{

    public Tilemap tilemap;
    public Tilemap tilemapHover;

    public GameObject tilePalette;

    private TileBase[] blockTiles;

    private const int blockCount = 5;

    private int selectedBlock = 0;
    // Start is called before the first frame update
    void Start()
    {

        //tilemap.ClearAllTiles();
        Debug.Log(tilePalette);

        Tilemap tilePaletteMap = tilePalette.GetComponentInChildren<Tilemap>();
        Debug.Log(tilePaletteMap);

        blockTiles = new TileBase[blockCount];

        for (int i = 0; i < blockCount; i++)
            blockTiles[i] = tilePaletteMap.GetTile(new Vector3Int(-1 + i, 0, 0));
        TileBase tile2 = tilePaletteMap.GetTile(new Vector3Int(1, 0, 0));

        /*
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                tilemap.SetTile(new Vector3Int(i, j, 0), tile2);
        /**/
    }

    private void Update()
    {
        tilemapHover.ClearAllTiles();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 localPos = transform.InverseTransformPoint(worldPos);

        Vector3Int tileLocation = Vector3Int.FloorToInt(localPos);
        tileLocation.z = 0;
        Debug.Log(string.Format("local [X: {0} Y: {1}]", tileLocation.x, tileLocation.y));

        selectedBlock += (int)Input.mouseScrollDelta.y;
        selectedBlock = (selectedBlock + blockCount) % blockCount;

        for (int i = 0; i < blockCount; i++)
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                selectedBlock = i;

        if (Input.GetMouseButton(0))
        {
            if (tilemap.GetTile(tileLocation) == null)
                tilemap.SetTile(tileLocation, blockTiles[selectedBlock]);
        }
        else
        {
            tilemapHover.SetTile(tileLocation, blockTiles[selectedBlock]);
        }

        if (Input.GetMouseButton(1))
        {
            if (blockTiles.Contains(tilemap.GetTile(tileLocation)))
                tilemap.SetTile(tileLocation, null);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = transform.position + Vector3.left * 0.03f;
    }

    private void OnMouseDown()
    {

    }
}
