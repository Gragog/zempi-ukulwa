using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstProjectile : AbstractProjectile {
    
    bool peakWasReached = false;

    protected override void Init()
    {
    }

    protected override void OnHitDamagable(IDamagable damagable)
    {
        DealBasicDamage(damagable);
    }

    protected override void OnHitGround()
    {
        Destroy(gameObject);
    }

    protected override void OnHitProjectile()
    {
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
}
