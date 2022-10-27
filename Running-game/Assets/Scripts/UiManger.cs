using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiManger : MonoBehaviour
{
    [SerializeField]Text Distance;
    [SerializeField] Text Score;
    [SerializeField] Text FinalScore;
    [SerializeField] Slider Health;
    [SerializeField]GameObject scoreAnim;
    [SerializeField] Health health;
    [SerializeField] GameObject CanvesStart;
    [SerializeField] GameObject CanvesGame;
    [SerializeField] GameObject CanvesEnd;
    float distance;
    int distanceToScore = 1;
    int score = 0;

    

    // Start is called before the first frame update
    void Start()
    {

        health.OnHealthDecrease += UpdateHeathBar;
        health.OnPlayerDeath += GameEnd;

    }

    // Update is called once per frame
    void Update()
    {
        CalculatePlayerDistance();
     
    }


   private void CalculatePlayerDistance()
    {
        distance += Time.deltaTime * 10;
        Distance.text = ((int)distance).ToString();

       
        if ((int) distance == distanceToScore)
        {
            return;

        }
        else
        {
            distanceToScore = (int)distance;
            StartCoroutine(CalculateScore());
        }
       
    }

    IEnumerator CalculateScore()
    {
        if (distanceToScore > 0 && distanceToScore % 100 == 0)
        {
            score += 1000;
           
            if (scoreAnim.activeInHierarchy) scoreAnim.SetActive(false);

            scoreAnim.SetActive(true);
            yield return new WaitForSeconds(.5f);
            Score.text = score.ToString();
        }
            
    }

   public void UpdateHeathBar()
    {
        Health.value = health.GetHealth(); 
    }


    public void GameStart()
    {
        CanvesStart.SetActive(false);
        CanvesGame.SetActive(true);

       // OnGameStart();
    }


    public void GameEnd()
    {

        CanvesGame.SetActive(false);
        CanvesEnd.SetActive(true);
        DisplayFinalScore();

    }


    void DisplayFinalScore()
    {
        FinalScore.text = score.ToString();
    }
}
