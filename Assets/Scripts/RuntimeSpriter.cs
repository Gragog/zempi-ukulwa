using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RuntimeSpriter : MonoBehaviour {

    public TileSet tileSet;
    public Vector2 size;

    //public int times;
    //public float time;
    //public float avgPerSecond;

    Tiles tiles;
    List<Tile> tileObjects = new List<Tile>();

    void Start() {
        LoadNewSprite();

        oldSize.x = (int)size.x;
        oldSize.y = (int)size.y;
        GeneratePlatform();

        //InvokeRepeating("GeneratePlatform", 3, 1);
    }

    void LoadNewSprite()
    {
        string filePath = Application.streamingAssetsPath + "/Tilesets/" + tileSet.tileSetName + ".png";

        int tileSize = tileSet.tileSize;
        int paddedTileSize = tileSize + tileSet.tilePadding;

        Texture2D spriteTexture = LoadTexture(filePath);
        int xTiles = (spriteTexture.width + 1) / paddedTileSize;
        int yTiles = (spriteTexture.height + 1) / paddedTileSize;
        Sprite[] tileSprites = new Sprite[xTiles * yTiles];

        for (int y = yTiles - 1, i = 0; y >= 0; y--)
        {
            for (int x = 0; x < xTiles; x++, i++)
            {
                tileSprites[i] = Sprite.Create(
                    spriteTexture,
                    new Rect(
                        (tileSet.tilePadding * x) + (x * tileSize),
                        (tileSet.tilePadding * y) + (y * tileSize),
                        tileSize,
                        tileSize
                    ),
                    new Vector2(.5f, .5f),
                    tileSize
                );
            }
        }

        tiles = new Tiles(tileSprites);
    }

    Texture2D LoadTexture(string filePath)
    {
        byte[] fileData;
        Texture2D texture;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2);
            if (texture.LoadImage(fileData)) {
                texture.wrapMode = TextureWrapMode.Clamp;
                texture.filterMode = FilterMode.Point;
                return texture;
            }
        }

        return null;
    }

    // generation
    [Header("Generation")]
    [Range(0, 100)]
    public int generationChance = 60;
    public bool repeatRandomize = false;
    public enum Method
    {
        CompletelyRandom,
        FillFromBottom,
        FillFromTop,
    }
    public Method randomMethod;
    public Tiles.Position fillTile;

    private void GeneratePlatform()
    {
        foreach (Transform old in transform)
        {
            Destroy(old.gameObject);
            tileObjects.Clear();
        }

        int sizeY = (int)size.y;
        int sizeX = (int)size.x;

        switch(randomMethod)
        {
            case Method.CompletelyRandom:
                for (int y = 0; y < sizeY; y++)
                {
                    for (int x = 0; x < sizeX; x++)
                    {
                        if (Random.Range(0, 100) < generationChance)
                        {
                            DrawSingleTile(new Vector3(sizeX * .5f - x - .5f, sizeY * .5f - y - .5f, 0));
                        }
                    }
                }
                break;

            case Method.FillFromTop:
                for (int x = 0; x < sizeX; x++)
                {
                    int height = Random.Range(1, (int)size.y);

                    for (int y = 0; y <= height; y++)
                    {
                        DrawSingleTile(new Vector3(sizeX * .5f - x - .5f, sizeY * .5f - y - .5f, 0));
                    }
                }
                break;

            case Method.FillFromBottom:
                for (int x = 0; x < sizeX; x++)
                {
                    int height = Random.Range(0, sizeY);

                    for (int y = 0; y <= height; y++)
                    {
                        DrawSingleTile(new Vector3(sizeX * .5f - x - .5f, y + .5f - sizeY * .5f, 0));
                    }
                }
                break;
        }

        RefreshAllTiles();
    }

    private void DrawSingleTile(Vector3 position)
    {
        GameObject tile = new GameObject(fillTile + " (" + (int)position.x + "|" + (int)(position.y) + ")");
        tile.transform.parent = transform;
        tile.transform.localPosition = position;
        tile.transform.localScale *= 1.01f;

        float colliderScale = 1f / 1.01f;

        BoxCollider2D collider = tile.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(colliderScale, colliderScale);

        SpriteRenderer renderer = tile.AddComponent<SpriteRenderer>();
        renderer.sprite = tiles.GetTile(fillTile);

        Tile tileComponent = tile.AddComponent<Tile>();
        tileComponent.Start();

        tileObjects.Add(tileComponent);
    }

    private void RefreshAllTiles()
    {
        foreach (Tile tile in tileObjects)
        {
            tile.UpdateSprite(tiles);
        }

        //times++;
        //time += Time.deltaTime;
        //avgPerSecond = times / time;
    }

    Vector2 oldSize;
    void Update()
    {
        if (
            Input.GetKeyDown(KeyCode.G)
            || (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.LeftShift))
            || repeatRandomize
            || (oldSize.x != (int)size.x || oldSize.y != (int)size.y)
            )
        {
            oldSize.x = (int)size.x;
            oldSize.y = (int)size.y;
            GeneratePlatform();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RefreshAllTiles();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireCube(transform.position, new Vector2((int)size.x, (int)size.y));

        //Gizmos.color = Color.green;
        //Gizmos.DrawSphere(tileObjects[0].transform.position + Vector3.up, .2f);
    }
}
