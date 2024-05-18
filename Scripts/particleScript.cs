using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleScript : MonoBehaviour
{
    public bool isEnemyDead = false;
    void Start()
    {
        if (isEnemyDead == true)
        {
            StartCoroutine(destroyEnemyParticle(5));
        }
    }
    IEnumerator destroyEnemyParticle(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
