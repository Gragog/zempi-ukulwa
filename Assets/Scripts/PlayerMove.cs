using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [Range(-25f, 25f)]
    public float speed = 10f;

    [Range(0f, 50f)]
    public float jumpPower = 30f;

    public LayerMask ground;

    KeyCode moveRight  = KeyCode.D;
    KeyCode moveLeft   = KeyCode.A;
    KeyCode jump       = KeyCode.Space;

	// Update is called once per frame
	void FixedUpdate () {
        Vector3 movement = new Vector3();
        Rigidbody2D ragdoll = GetComponent<Rigidbody2D>();

        if (Input.GetKey(moveRight))
        {
            movement.x += speed;
        }

        if (Input.GetKey(moveLeft))
        {
            movement.x -= speed;
        }

        if (Input.GetKeyDown(jump) && Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.4f), .05f, ground) != null)
        {
            ragdoll.AddForce(Vector2.up * jumpPower * 20, ForceMode2D.Force);
        }

        transform.Translate(movement * Time.deltaTime, Space.World);




        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector2(-4, 5);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.color = new Color(.8f, .95f, .1f);
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y - 0.4f), .05f);
    }
}
