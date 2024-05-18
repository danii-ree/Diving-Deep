using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    private PlayerMovement playerScript;
    private GameObject stats;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        stats = GameObject.Find("coinCollected");
    }
    void Update()
    {
        gameObject.SetActive(true);
        playerScript.enabled = false;
        stats.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
            stats.SetActive(true);
            playerScript.enabled = true;
        }
    }
}
