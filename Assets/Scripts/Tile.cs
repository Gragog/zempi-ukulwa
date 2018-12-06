using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    LayerMask layerMask;

    public void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Tile");
        layerMask = LayerMask.GetMask("Tile");
    }

    public Tiles.Position UpdateSprite(Tiles tiles)
    {
        Tiles.Position position = GetSpriteToUse();

        GetComponent<SpriteRenderer>().sprite = tiles.GetTile(position);

        return position;
    }

    Tiles.Position GetSpriteToUse()
    {
        int sum = 0;

        sum += Physics2D.OverlapCircle(transform.position + Vector3.up, .2f, layerMask) != null ? 1 : 0;
        sum += Physics2D.OverlapCircle(transform.position + Vector3.down, .2f, layerMask) != null ? 2 : 0;
        sum += Physics2D.OverlapCircle(transform.position + Vector3.left, .2f, layerMask) != null ? 4 : 0;
        sum += Physics2D.OverlapCircle(transform.position + Vector3.right, .2f, layerMask) != null ? 8 : 0;

        switch(sum)
        {
            case 0:
                return Tiles.Position.Single;
            case 1:
                return Tiles.Position.Thin_Vertical_Bottom;
            case 2:
                return Tiles.Position.Thin_Vertical_Top;
            case 3:
                return Tiles.Position.Thin_Vertical_Center;
            case 4:
                return Tiles.Position.Thin_Horizontal_Right;
            case 5:
                return Tiles.Position.Block_BottomRight;
            case 6:
                return Tiles.Position.Block_TopRight;
            case 7:
                return Tiles.Position.Block_Right;
            case 8:
                return Tiles.Position.Thin_Horizontal_Left;
            case 9:
                return Tiles.Position.Block_BottomLeft;
            case 10:
                return Tiles.Position.Block_TopLeft;
            case 11:
                return Tiles.Position.Block_Left;
            case 12:
                return Tiles.Position.Thin_Horizontal_Center;
            case 13:
                return Tiles.Position.Block_Bottom;
            case 14:
                return Tiles.Position.Block_Top;
            case 15:
                return Tiles.Position.Block_Center;
        }

        return Tiles.Position.Fallback;
    }
}
