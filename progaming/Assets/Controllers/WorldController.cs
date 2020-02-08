﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public Sprite moonSprite;

    World world;

    // Start is called before the first frame update
    void Start()
    {
        // Creat a world with Empty tiles
        world = new World();

        // Create a GameObject for each of our tiles, so they show visually
        for (int x = 0; x < world.Width; x++)
        {
            for (int y = 0; y < world.Height; y++)
            {
                Tile tile_data = world.GetTileAt(x, y);

                GameObject tile_go = new GameObject();
                tile_go.name = "Tile_" + x + "_" + y;
                tile_go.transform.position = new Vector3(tile_data.X, tile_data.Y, 0);
                tile_go.transform.SetParent(this.transform, true);

                // Add a sprite renderer, but don't bother setting a sprite
                // because all the titles are empty right now
                tile_go.AddComponent<SpriteRenderer>();

                tile_data.RegisterTileTypeChangedCallback( (tile) => { OnTileTypeChanged(tile, tile_go); } );
            }
        }

        world.RandomizeTiles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTileTypeChanged(Tile tile_data, GameObject tile_go)
    {
        switch (tile_data.Type)
        {
            case Tile.TileType.Moon:
                tile_go.GetComponent<SpriteRenderer>().sprite = moonSprite;
                break;
            case Tile.TileType.Empty:
                tile_go.GetComponent<SpriteRenderer>().sprite = null;
                break;
            default:
                Debug.LogError("OnTileTypeChanged - Unrecognized tile type");
                break;
        }
    }
}
