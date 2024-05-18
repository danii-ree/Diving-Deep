using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelComplete : MonoBehaviour
{
    public GameObject LevelCompleteScreen;
    private GameObject PlayerMan;
    bool isLevelComplete = false;

    void Start()
    {
        PlayerMan = GameObject.Find("Player");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && isLevelComplete)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif     
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var levelCompleteTitle = LevelCompleteScreen.transform.GetChild(0);
            var playerMovement = PlayerMan.GetComponent<PlayerMovement>();
            isLevelComplete = true;

            playerMovement.enabled = false;

            levelCompleteTitle.gameObject.SetActive(true);

            StartCoroutine(pressRSpawn(2));
        }    
    }
    IEnumerator pressRSpawn(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        var restartText = LevelCompleteScreen.transform.GetChild(1);
        restartText.gameObject.SetActive(true);
    }
}
