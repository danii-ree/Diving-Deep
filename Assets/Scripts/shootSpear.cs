using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSpear : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(destroySpear(2));
    }
    IEnumerator destroySpear(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
