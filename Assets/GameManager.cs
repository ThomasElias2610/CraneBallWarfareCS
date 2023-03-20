using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{

    public GameObject gameLostPanel;
    public GameObject gameWinPanel;

    public TextMeshProUGUI txtTextMesh;
    public TextMeshProUGUI txtTextMesh1;
    public TextMeshProUGUI txtTextMeshTimer;

    public int maxTime, curTime;
    public int curTimeMinutes;
    public int MaxcurTimeMinutes;
    public float seeTimedelta;


    public bool GameIsOVER;
    // Start is called before the first frame update
    void Start()
    {
        GameIsOVER = false;
        curTime = 60;
        curTimeMinutes = MaxcurTimeMinutes;
    }

    // Update is called once per frame
    void Update()
    {

    
    }
    private void LateUpdate()
    {

        if (curTime <= 0 && curTimeMinutes <= 0)
        {
            WonTheGame();
            GameIsOVER = true;

        }
        else
        {
            if (GameIsOVER == false)
            {
                SetTime();

            }
        }


    }
    public void SetTime()
    {
        seeTimedelta += Time.unscaledDeltaTime;

        curTime -= (int)seeTimedelta;
        if (seeTimedelta >= 1)
        {
            seeTimedelta = 0;
        }
        if (curTime < 0)
        {
            curTime = 60;
            curTimeMinutes--;
        }
  
            txtTextMesh.text = "" + SetString(curTimeMinutes < 10) + curTimeMinutes + ": " + SetString(curTime < 10) + curTime;
            txtTextMesh1.text = "" + SetString(curTimeMinutes < 10) + curTimeMinutes + ": " + SetString(curTime < 10) + curTime;
            txtTextMeshTimer.text = "" + SetString(curTimeMinutes < 10) + curTimeMinutes + ": " + SetString(curTime < 10) + curTime;
        


    }
    public string SetString(bool flag)
    {
        if (flag)
        {
            return "0";
        }
        else
        {
            return "";
        }
    }
    public void RestartScene()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LostTheGame()
    {
        Time.timeScale = 0;
        GameIsOVER = true;
        gameLostPanel.SetActive(true);
    }
    public void WonTheGame()
    {
        Time.timeScale = 0;
        gameWinPanel.SetActive(true);
    }
}
