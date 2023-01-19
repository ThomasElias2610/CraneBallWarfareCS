using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScriptNodeStable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().inertiaTensor = Vector3.one;
        GetComponent<Rigidbody>().centerOfMass = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
