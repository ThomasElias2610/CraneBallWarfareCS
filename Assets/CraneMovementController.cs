using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMovementController : MonoBehaviour
{
    public GameObject CraneObj;
    public GameObject Rotator;
    public float AxisLockClampMin, AxisLockClampMax;
    public float currentXPos;

    public float speedLifter = 2f;

    public float rotationSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        currentXPos = AxisLockClampMin;
        Rotator = this.gameObject;
        CraneObj.transform.localPosition = new Vector3(CraneObj.transform.localPosition.x, CraneObj.transform.localPosition.y, currentXPos);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Rotator.transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotator.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            ///sdsad//DSA
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            /*
            CraneObj.transform.localPosition += CraneObj.transform.TransformDirection(-Vector3.right * 0.05f);
            currentXPos = CraneObj.transform.localPosition.z;
            currentXPos = Mathf.Clamp(CraneObj.transform.position.z, AxisLockClampMin, AxisLockClampMax);
            CraneObj.transform.localPosition = new Vector3(CraneObj.transform.localPosition.x, CraneObj.transform.localPosition.y, currentXPos);
            */
            /*
            CraneObj.transform.localPosition += CraneObj.transform.InverseTransformDirection(-CraneObj.transform.forward * 0.25f * Time.deltaTime);
            currentXPos = CraneObj.transform.localPosition.z;
            currentXPos = Mathf.Clamp(CraneObj.transform.position.z, AxisLockClampMin, AxisLockClampMax);

            CraneObj.transform.localPosition = new Vector3(CraneObj.transform.localPosition.x, CraneObj.transform.localPosition.y, currentXPos);
            */
            CraneObj.transform.localPosition += CraneObj.transform.InverseTransformDirection(CraneObj.transform.forward * -speedLifter * Time.deltaTime);

            currentXPos = CraneObj.transform.localPosition.z;
            currentXPos = Mathf.Clamp(CraneObj.transform.localPosition.z, AxisLockClampMin, AxisLockClampMax);
            CraneObj.transform.localPosition = new Vector3(CraneObj.transform.localPosition.x, CraneObj.transform.localPosition.y, currentXPos);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            /*
            CraneObj.transform.localPosition += CraneObj.transform.TransformDirection(Vector3.right * 0.05f) ;
            currentXPos = CraneObj.transform.localPosition.z;
            currentXPos = Mathf.Clamp(CraneObj.transform.position.z, AxisLockClampMin, AxisLockClampMax);
            CraneObj.transform.localPosition = new Vector3(CraneObj.transform.localPosition.x,CraneObj.transform.localPosition.y, currentXPos);
            */
            CraneObj.transform.localPosition += CraneObj.transform.InverseTransformDirection(CraneObj.transform.forward * speedLifter * Time.deltaTime);
            currentXPos = CraneObj.transform.localPosition.z;
            currentXPos = Mathf.Clamp(CraneObj.transform.localPosition.z, AxisLockClampMin, AxisLockClampMax);
            CraneObj.transform.localPosition = new Vector3(CraneObj.transform.localPosition.x, CraneObj.transform.localPosition.y, currentXPos);
     



            /*
            CraneObj.transform.localPosition += CraneObj.transform.InverseTransformDirection(CraneObj.transform.forward * 0.25f * Time.deltaTime);
            currentXPos = CraneObj.transform.localPosition.z;
            currentXPos = Mathf.Clamp(CraneObj.transform.position.z, AxisLockClampMin, AxisLockClampMax);

            CraneObj.transform.localPosition = new Vector3(CraneObj.transform.localPosition.x, CraneObj.transform.localPosition.y, currentXPos);
            */
        }
    }


}
