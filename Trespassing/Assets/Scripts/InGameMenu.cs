using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class InGameMenu : MonoBehaviour {

    // Use this for initialization
    public GameObject CrashBtns;
    public GameObject NextLvlBtns;
    public Text TimeTxt;
    public Text CoinsTxt;
    public Text ScoreTxt;

    public GameObject MenuPanel;
    public Timer TimerScript;
    public Movement MovementScript;

    int Score;
    bool ShowText;
    public Text[] textArray;
    float FadeSpeed;
    int i;
	void Start () {
        Score = 1000;

        FadeSpeed = 0.0f;
       
      

        i = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (ShowText)
        {

            float TransValue = Mathf.PingPong(FadeSpeed, 1);
            // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
            textArray[i].color = new Color(textArray[i].color.r, textArray[i].color.g, textArray[i].color.b, TransValue);

            if (FadeSpeed >= 1.0)
            {
                i++;
                FadeSpeed = 0.0f;
            }
            else
            {
                FadeSpeed = FadeSpeed + 0.04f;

            }
            if(i == 3){
                ShowText = false;
            }
        }
		
	}
    void CalculateScore(bool PassedLevel)
    {
        GameObject MaxCoins = GameObject.Find("Coins");
        int coins = MovementScript.NrOfCoins;

        TimeTxt.text = "Time: " + TimerScript.rounded.ToString();
        CoinsTxt.text = "Coins: " + coins.ToString();
        if (PassedLevel)
        {
            //Om alla coins blir upplockade
            if (coins == MaxCoins.transform.childCount)
            {
                Score = (int)(1000 + (coins * 100) - 5 * TimerScript.rounded);
            }
            else
            {
                Score = (int)(1000 + (coins * 50) - 5 * TimerScript.rounded);
            }
        }
        else
        {
            if (coins == MaxCoins.transform.childCount)
            {
                Score = (int)( + (coins * 100));
            }
            else
            {
                Score = (int)((coins * 50));
            }
        }
        ScoreTxt.text = "Score: " + Score.ToString();
        int SceneInt = SceneManager.GetActiveScene().buildIndex;

        //Save Score
        string ScoreLevel = "ScoreLevel" + SceneInt.ToString();
        if ( PlayerPrefs.GetInt(ScoreLevel) < Score)
        {   
            float time = TimerScript.rounded;
            string TimeLevel = "TimeLevel" + SceneInt.ToString();
            string CoinLevel = "CoinLevel" + SceneInt.ToString();

           
            PlayerPrefs.SetInt(CoinLevel, coins);
            PlayerPrefs.SetFloat(TimeLevel,time);
            PlayerPrefs.SetInt(ScoreLevel,Score);

        }
       


      



    }
    public void ShowCrashMenu(){
        this.gameObject.SetActive(true);


        StartCoroutine(PanelDelay());
        CrashBtns.gameObject.SetActive(true);

        CalculateScore(false);



        

    }
    public void ShowNextLvlMenu()
    {
        int SceneCount = SceneManager.GetActiveScene().buildIndex + 1;
        if(PlayerPrefs.GetInt("LevelCount") < SceneCount){
            PlayerPrefs.SetInt("LevelCount", SceneCount);
        }
        this.gameObject.SetActive(true);
        StartCoroutine(PanelDelay());
        NextLvlBtns.gameObject.SetActive(true);
        CalculateScore(true);


    }
    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }
    public void GoToNextlvl()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else{
            //Show End credits
        }


    }
    public void GoToMenu()
    {

        SceneManager.LoadScene("StartScen");



    }

    public IEnumerator TextFade(float t,Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        yield break;
    }
    public IEnumerator PanelDelay()
    {
        yield return new WaitForSeconds(0.6f);
        MenuPanel.gameObject.SetActive(true);
        ShowText = true;

        yield break;
    }
}
