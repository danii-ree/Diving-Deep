using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputScript : MonoBehaviour
{
    public bool inputIsActive = false;

    void Update()
    {
        if (inputIsActive == true) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
}
