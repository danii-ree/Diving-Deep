using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    private updateText coinText;

    void Start()
    {
        coinText = GameObject.Find("coinCollected").GetComponent<updateText>();
        if (gameObject.tag == "SharkCoin")
        {
            StartCoroutine(DestroySharkCoin(10));
        }
    }
    IEnumerator DestroySharkCoin(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            coinText.coinAmount++;
            Destroy(gameObject);
        }
    }
}
