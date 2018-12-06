using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tileset", menuName = "Tilesets/Tileset")]
public class TileSet : ScriptableObject {

    [Tooltip("Name of the file inside the Tilesets folder")]
    public string tileSetName;

    [Tooltip("Size of each tile in pixels")]
    [Range(1, 1024)]
    public int tileSize = 16;

    [Tooltip("Number of pixels between each tile")]
    public int tilePadding = 1;
}
