using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public GameObject sharkCoin;
    public CollectibleScript collectible;
    public float enemySpeed = 40f;
    float offset = 5f;
    public float collectibleNum = 3;
    public int enemyHit = 3;
    public ParticleSystem enemyParticle;
    public GameObject particleObj;
    public float knockBackForce = 4000f;
    void LateUpdate()
    {
        Vector2 followPlayer = (player.transform.position - transform.position).normalized;
        transform.Translate(followPlayer * enemySpeed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spear")
        {
            enemyHit -= 1;
            var rootGameObject = transform.root.gameObject;
            if (enemyHit == 0)
            {
                // Debug.Log(enemyHit);
                Destroy(rootGameObject);
                Instantiate(enemyParticle, transform.position, Quaternion.identity);
                particleObj.GetComponent<particleScript>().isEnemyDead = true;
                for(int i = 0; i < collectibleNum; i++)
                {
                    float randX = Random.Range(transform.position.x, transform.position.x + offset);
                    float randy = Random.Range(transform.position.y, transform.position.y + offset);
                    Vector2 randPosition = new Vector2(randX, randy);
                    Instantiate(sharkCoin, randPosition, Quaternion.identity);
                }
            }
        }
        if (other.gameObject.tag == "Player")
        {
            Rigidbody2D playerRb = other.collider.GetComponent<Rigidbody2D>();
            Vector2 knockBack = (playerRb.transform.position - transform.position).normalized;

            playerRb.AddForce(knockBack * knockBackForce, ForceMode2D.Impulse);
        }
    }
    
}
