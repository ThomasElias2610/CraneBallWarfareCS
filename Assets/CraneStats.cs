using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraneStats : MonoBehaviour
{
    public float curHealth;
    public float MaxHealth;
    public Image imgHealth;

    public GameManager gameManage;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = MaxHealth;
        imgHealth.fillAmount = curHealth / MaxHealth;
    }

  
    public void damagingCrane(float dmg)
    {
        if(curHealth > 0)
        {
            StartCoroutine(downHealth(curHealth, curHealth - dmg));
            curHealth -= dmg;
            if(curHealth <= 0)
            {
                gameManage.LostTheGame();
            }
        }
    }

    IEnumerator downHealth(float recenthealth,float desHealth)
    {
        float elapsedTime = 0;
        if(desHealth < 0)
        {
            desHealth = 0;
        }
        else if(desHealth > MaxHealth)
        {
            desHealth = MaxHealth;
        }
        while(elapsedTime < 2)
         {
            imgHealth.fillAmount = Mathf.Lerp(recenthealth, desHealth, (elapsedTime / 2)) / MaxHealth;
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        // Make sure we got there
        imgHealth.fillAmount = desHealth / MaxHealth;
        yield return null;

    }

    public void HealCrane(float healthUpdate)
    {
        StartCoroutine(downHealth(curHealth, curHealth + healthUpdate));
        curHealth += healthUpdate;
        if(curHealth > MaxHealth)
        {
            curHealth = MaxHealth;
        }

    }


}
