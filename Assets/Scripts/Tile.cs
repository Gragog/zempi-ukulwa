using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    LayerMask layerMask;

    public enum Grid
    {
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,
    }

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

        sum += Physics2D.OverlapCircle(transform.position + Vector3.up, .2f, layerMask) != null ? (int)Grid.Up : 0;
        sum += Physics2D.OverlapCircle(transform.position + Vector3.down, .2f, layerMask) != null ? (int)Grid.Down : 0;
        sum += Physics2D.OverlapCircle(transform.position + Vector3.left, .2f, layerMask) != null ? (int)Grid.Left : 0;
        sum += Physics2D.OverlapCircle(transform.position + Vector3.right, .2f, layerMask) != null ? (int)Grid.Right : 0;

        switch(sum)
        {
            case 0:
                return Tiles.Position.Single;
            case (int)Grid.Up:
                return Tiles.Position.Thin_Vertical_Bottom;
            case (int)Grid.Down:
                return Tiles.Position.Thin_Vertical_Top;
            case (int)Grid.Up + (int)Grid.Down:
                return Tiles.Position.Thin_Vertical_Center;
            case (int)Grid.Left:
                return Tiles.Position.Thin_Horizontal_Right;
            case (int)Grid.Up + (int)Grid.Left:
                return Tiles.Position.Block_BottomRight;
            case (int)Grid.Down + (int)Grid.Left:
                return Tiles.Position.Block_TopRight;
            case (int)Grid.Up + (int)Grid.Left + (int)Grid.Down:
                return Tiles.Position.Block_Right;
            case (int)Grid.Right:
                return Tiles.Position.Thin_Horizontal_Left;
            case (int)Grid.Up + (int)Grid.Right:
                return Tiles.Position.Block_BottomLeft;
            case (int)Grid.Down + (int)Grid.Right:
                return Tiles.Position.Block_TopLeft;
            case (int)Grid.Up + (int)Grid.Right + (int)Grid.Down:
                return Tiles.Position.Block_Left;
            case (int)Grid.Left + (int)Grid.Right:
                return Tiles.Position.Thin_Horizontal_Center;
            case (int)Grid.Left + (int)Grid.Up + (int)Grid.Right:
                return Tiles.Position.Block_Bottom;
            case (int)Grid.Left + (int)Grid.Down + (int)Grid.Right:
                return Tiles.Position.Block_Top;
            case (int)Grid.Up + (int)Grid.Down + (int)Grid.Left + (int)Grid.Right:
                return Tiles.Position.Block_Center;
        }

        return Tiles.Position.Fallback;
    }
}
