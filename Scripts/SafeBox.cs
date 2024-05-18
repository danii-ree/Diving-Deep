using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBox : MonoBehaviour
{
    public inputScript inputScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Mandem");
        inputScript.inputIsActive = true;
    }
}
