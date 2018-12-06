using System.Collections.Generic;
using UnityEngine;

public class Tiles
{
    Dictionary<Position, Sprite> tiles = new Dictionary<Position, Sprite>();

    public enum Position
    {
        Fallback,

        // Standard Shape
        Block_TopLeft,
        Block_Top,
        Block_TopRight,
        Block_Left,
        Block_Center,
        Block_Right,
        Block_BottomLeft,
        Block_Bottom,
        Block_BottomRight,

        // Thin Horizontal
        Thin_Vertical_Top,
        Thin_Vertical_Center,
        Thin_Vertical_Bottom,
        
        // Thin Vertical
        Thin_Horizontal_Left,
        Thin_Horizontal_Center,
        Thin_Horizontal_Right,

        // Single Block
        Single
    }

    public Tiles(Sprite[] sprites)
    {
        tiles[Position.Fallback] = sprites[0];

        if (sprites.Length == 16)
        {
            AssignBasicTileSet(sprites);
            return;
        }
    }

    void AssignBasicTileSet(Sprite[] sprites)
    {
        tiles[Position.Block_TopLeft] = sprites[0];
        tiles[Position.Block_Top] = sprites[1];
        tiles[Position.Block_TopRight] = sprites[2];

        tiles[Position.Block_Left] = sprites[4];
        tiles[Position.Block_Center] = sprites[5];
        tiles[Position.Block_Right] = sprites[6];

        tiles[Position.Block_BottomLeft] = sprites[8];
        tiles[Position.Block_Bottom] = sprites[9];
        tiles[Position.Block_BottomRight] = sprites[10];

        tiles[Position.Thin_Vertical_Top] = sprites[3];
        tiles[Position.Thin_Vertical_Center] = sprites[7];
        tiles[Position.Thin_Vertical_Bottom] = sprites[11];

        tiles[Position.Thin_Horizontal_Left] = sprites[12];
        tiles[Position.Thin_Horizontal_Center] = sprites[13];
        tiles[Position.Thin_Horizontal_Right] = sprites[14];

        tiles[Position.Single] = sprites[15];
    }

    public Sprite GetTile(Position name)
    {
        Sprite tile = tiles[name];

        if (tile)
        {
            return tile;
        }

        return tiles[Position.Fallback];
    }
}
