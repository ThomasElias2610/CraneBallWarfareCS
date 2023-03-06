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

    public int maxTime, curTime;
    public int curTimeMinutes;
    public int MaxcurTimeMinutes;
    public float seeTimedelta;
    // Start is called before the first frame update
    void Start()
    {
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
        }
        seeTimedelta += Time.deltaTime;
       
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
        txtTextMesh.text = "" + curTimeMinutes + ":" + curTime;
        txtTextMesh1.text = "" + curTimeMinutes + ":" + curTime;

    }
    public void RestartScene()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LostTheGame()
    {
        Time.timeScale = 0;
        gameLostPanel.SetActive(true);
    }
    public void WonTheGame()
    {
        Time.timeScale = 0;
        gameWinPanel.SetActive(true);
    }
}
