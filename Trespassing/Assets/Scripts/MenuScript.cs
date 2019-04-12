using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour {

    public GameObject LevelPanel;
    public GameObject StartPanel;
    public GameObject ShowLevelPanel;
    public GameObject SettingsPanel;
    public int LevelCount;
    public Sprite GreenImage;
    public Sprite RedImage;
    public Image LevelTwoBtn;

    public Text LevelHeader;
    public Text LevelCoins;
    public Text LevelTime;
    public Text LevelScore;
    int StartLevelINT;
    void Awake()
    { //Whole awake script with PlayerPrefs.

        if (PlayerPrefs.HasKey("LevelCount") && PlayerPrefs.GetInt("LevelCount") > 0)
        {
            LevelCount = PlayerPrefs.GetInt("LevelCount");

        }
        else
        {
            PlayerPrefs.SetInt("LevelCount", 1);
            LevelCount = 1;
        }
    }
	// Use this for initialization
	void Start () {
        StartLevelINT = 1;
	}
	
	

    public void StartLevel()
    {
       
            SceneManager.LoadScene(StartLevelINT);

    }
    public void SelectLevel(int level)
    {
        StartLevelINT = level;
        if (PlayerPrefs.GetInt("LevelCount") >= level)
        {
            LevelPanel.SetActive(false);
            ShowLevelPanel.SetActive(true);
            LoadLevelData(level);
        }
        
    }
    public void Delete(){
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LevelCount", 1);
        LevelCount = 1;
        GoToMenu(SettingsPanel);
        
    }
    void LoadLevelData(int level)
    {


        LevelHeader.text = "Level " + level.ToString();


        string ScoreLevel = "ScoreLevel" + level.ToString();

        if (PlayerPrefs.HasKey(ScoreLevel))
        {
            LevelCoins.text = "Coins: " + PlayerPrefs.GetInt("CoinLevel" + level.ToString());
            LevelTime.text = "Time: " + PlayerPrefs.GetFloat("TimeLevel" + level.ToString());
            LevelScore.text = "Score: " + PlayerPrefs.GetInt("ScoreLevel" + level.ToString());



        }else{
            LevelCoins.text = "Coins: 0";
            LevelTime.text = "Time: 0";
            LevelScore.text = "Score: 0";
        }



    }

    public void GoToPanel(GameObject obj)
    {
        StartPanel.SetActive(false);
        obj.SetActive(true);

    }

    public void GoToLevelSelect(GameObject obj)
    {
        CheckLevels();
        obj.SetActive(false);
        LevelPanel.SetActive(true);

    }
    public void CheckLevels()
    {
        if(PlayerPrefs.GetInt("LevelCount") >1){
            LevelTwoBtn.sprite = GreenImage;
        }
    }
    public void GoToMenu(GameObject obj)
    {
        StartPanel.SetActive(true);
        obj.gameObject.SetActive(false);

    }
}
