using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Range(1f, 100f)]
    public int power = 20;

    GameObject owner;
    Rigidbody2D ragdoll;

	// Use this for initialization
	void Awake () {
        ragdoll = GetComponent<Rigidbody2D>();

        Destroy(gameObject, 30f);
	}

    public void ApplyForce(Vector2 target, float power)
    {
        ragdoll.AddForce(target.normalized * power * 0.3f, ForceMode2D.Impulse);
    }

    public void SetOwner(GameObject newOwner)
    {
        this.owner = newOwner;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector2(-4, 5);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            Awake();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        
    }
}
