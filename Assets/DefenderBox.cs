using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderBox : MonoBehaviour
{

    public float setFill;
    public float minFill, maxFill;

    public ParticleSystem psDestruction;
    // Start is called before the first frame update
    void Start()
    {
        setFill = Random.Range(minFill, maxFill);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "WallBuilder")
        {

            
        }
    }
}
