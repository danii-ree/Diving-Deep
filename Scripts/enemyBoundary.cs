using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBoundary : MonoBehaviour
{
    public EnemyScript enemy;
    void Start()
    {
        enemy.enabled = false;        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.enabled = !enemy.enabled;
        }
    }
}
