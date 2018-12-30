using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUI : MonoBehaviour {

    public Transform power;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void OnMouseEnter()
    {
        Debug.Log("hi");

        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition).ToVector2();

        power.position = newPosition;
    }
}
