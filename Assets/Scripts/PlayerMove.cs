using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [Range(-25f, 25f)]
    public float speed = 10f;

    [Range(0f, 50f)]
    public float jumpPower = 30f;

    public LayerMask ground;

    public GameObject shot;
    public Transform shotPoint;

    KeyCode moveRight = KeyCode.D;
    KeyCode moveLeft  = KeyCode.A;
    KeyCode jump      = KeyCode.W;
    KeyCode fire      = KeyCode.Space;

    Vector2 shotOrigin;
    GameObject firedShot;

    // Update is called once per frame
    void FixedUpdate () {
        #region Movement

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

        if (Input.GetKeyDown(jump) && Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.4f), .08f, ground) != null)
        {
            ragdoll.AddForce(Vector2.up * jumpPower * 20, ForceMode2D.Force);
        }

        transform.Translate(movement * Time.deltaTime, Space.World);
        #endregion

        if (Input.GetKey(fire) && !firedShot)
        {
            shotOrigin = new Vector2(
                transform.localPosition.x + shotPoint.localPosition.x,
                transform.localPosition.y + shotPoint.localPosition.y
            );

            firedShot = Instantiate(shot, shotOrigin, Quaternion.identity, transform.parent);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector2(-4, 5);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(.8f, .95f, .1f);
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y - 0.4f), .08f);

        Gizmos.color = new Color(.9f, .2f, 0f);
        Gizmos.DrawSphere(new Vector2(
                transform.localPosition.x + shotPoint.localPosition.x,
                transform.localPosition.y + shotPoint.localPosition.y
            ), .1f);
    }
}
