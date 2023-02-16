using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallDefendBox : MonoBehaviour
{

    public float healthOfBox;
    public float curHealth, MaxHealth;

    public float minRandHealth, maxRandHealth;
    public Image imgHealth;
    public ParticleSystem psDestruction;

    // Start is called before the first frame update
    void Start()
    {
        healthOfBox = Random.Range(minRandHealth, maxRandHealth);
        MaxHealth = healthOfBox;
        curHealth = MaxHealth;

        imgHealth.fillAmount = curHealth / MaxHealth;
    }

    public void SetDamageBox(float dmg)
    {
        curHealth -= dmg;
        imgHealth.fillAmount = curHealth / MaxHealth;

        if (curHealth <= 0)
        {
            //Destroy
            ParticleSystem psD = Instantiate(psDestruction, transform.position, Quaternion.identity);
            Destroy(psD, 6f);
            Destroy(this.gameObject);
        }
    }


}
