using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyHealthController), typeof(CircleCollider2D))]
public class BotEnemyBehavior : MonoBehaviour {

    MyHealthController healthController;

    void Start()
    {
        healthController = GetComponent<MyHealthController>();
    }
}
