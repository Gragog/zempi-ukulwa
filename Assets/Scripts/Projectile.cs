using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Range(1f, 100f)]
    public int power = 20;

    GameObject owner;
    Rigidbody2D ragdoll;
    bool peakWasReached = false;

	// Use this for initialization
	void Awake () {
        ragdoll = GetComponent<Rigidbody2D>();

        Destroy(gameObject, 30f);
        // GetComponent<CircleCollider2D>().isTrigger = true;
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
	void FixedUpdate () {
        bool peak = !peakWasReached && ragdoll.velocity.y <= 0;
        
        if (peak)
        {
            peakWasReached = true;
            GetComponent<SpriteRenderer>().color = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
        }

        #region Testing
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
        #endregion
    }

    // TODO DELETE ME LATER (or not, you decide. I'm a comment, not a cop)
    private void Update()
    {
        Color[] colors = new Color[] {
            Color.red,
            Color.black,
            Color.blue,
            Color.cyan,
            Color.gray,
            Color.green,
            Color.magenta,
            Color.yellow,
        };

        if (peakWasReached)
        {
            GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length - 1)];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != gameObject.tag)
        {
            Destroy(gameObject);
        }
    }
}
