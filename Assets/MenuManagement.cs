using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    
     public void START()
    {
        SceneManager.LoadScene(1);
        
    }
    public void QUIT()
    {
        Application.Quit();
    }
}
