using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHealthBox : MonoBehaviour
{

    public ParticleSystem psDestruction;
    public float currentHealer;
    public float minHealth, MaxHealth;
    private void Start()
    {
        currentHealer = Random.Range(minHealth, MaxHealth);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "CraneHealth")
        {

            ParticleSystem ps = Instantiate(psDestruction, transform.position, Quaternion.identity);
            Destroy(ps, 3f);
            Destroy(this.gameObject);
        }
    }
}
