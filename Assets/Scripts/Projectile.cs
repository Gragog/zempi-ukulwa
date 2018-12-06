using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Range(1f, 100f)]
    public int power = 20;

	// Use this for initialization
	void Start () {
        Rigidbody2D ragdoll = GetComponent<Rigidbody2D>();

        Vector2 direction = new Vector2(1f, 1f);

        ragdoll.AddForce(direction.normalized * power * 0.3f, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector2(-4, 5);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            Start();
        }
    }
}
