using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManger : MonoBehaviour
{
    [SerializeField] UiManger UiManger;
    [SerializeField] Health health;

    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        health.OnPlayerDeath += FrezeTheGme;
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void FrezeTheGme()
    {
        StartCoroutine(DelayForzenGame());
    }

   IEnumerator DelayForzenGame()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
    }

    public void StartTheGame()
    {
        Time.timeScale = 1;
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(0);
    }
}
