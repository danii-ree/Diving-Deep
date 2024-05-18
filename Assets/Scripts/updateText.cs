using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateText : MonoBehaviour
{
    private Text coinText;
    public int coinAmount = 0;
    void Start()
    {
        coinText = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = $"{coinAmount} Coins";
    }
}
