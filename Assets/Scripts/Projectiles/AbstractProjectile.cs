using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class AbstractProjectile : MonoBehaviour {

    public int damageAmount = 15;

    protected Rigidbody2D ragdoll;
    protected GameObject owner;

    protected void Awake()
    {
        ragdoll = GetComponent<Rigidbody2D>();

        Destroy(gameObject, 30f);
        // GetComponent<CircleCollider2D>().isTrigger = true;
    }

    protected void Start()
    {
        Init();
    }

    abstract protected void Init();

    public void ApplyForce(Vector2 target, float power)
    {
        ragdoll.AddForce(target.normalized * power * 0.3f, ForceMode2D.Impulse);
    }

    public void SetOwner(GameObject newOwner)
    {
        this.owner = newOwner;
    }

    abstract protected void OnHitProjectile();
    abstract protected void OnHitGround();
    abstract protected void OnHitDamagable(IDamagable damagable);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool hitIsProjectile = collision.gameObject.tag == gameObject.tag;
        if (hitIsProjectile)
        {
            Debug.Log("Hitting another projectile");

            OnHitProjectile();
            return;
        }

        bool hitIsGround = collision.gameObject.layer == LayerMask.NameToLayer("Ground");
        if (hitIsGround)
        {
            Debug.Log("Hitting the ground");
            OnHitGround();
            return;
        }

        if (!hitIsProjectile && !hitIsGround)
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                Debug.Log("Hitting a damagable");
                OnHitDamagable(damagable);
            }
        }
    }

    protected void DealBasicDamage(IDamagable damagable)
    {
        damagable.DealDamage(damageAmount);
        Destroy(gameObject);
    }
}
