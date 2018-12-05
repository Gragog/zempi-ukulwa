using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [Range(-25f, 25f)]
    public float speed = 10f;

    KeyCode moveRight  = KeyCode.D;
    KeyCode moveLeft   = KeyCode.A;

	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3();

        if (Input.GetKey(moveRight))
        {
            movement.x += speed;
        }

        if (Input.GetKey(moveLeft))
        {
            movement.x -= speed;
        }

        transform.Translate(movement * Time.deltaTime, Space.World);
    }
}
