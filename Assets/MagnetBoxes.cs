using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBoxes : MonoBehaviour
{

    public GameObject setObjectToMagnetize;
    public bool isMagnetObject;
    FixedJoint jointInstance;
    HingeJoint jointInstance1;
    CharacterJoint jointInstance2;

    LineRenderer lineRend;
    public LayerMask layers;
    public Gradient lineRendAttachedBoxColor;
    public Gradient lineRenddefault;

    MeshRenderer rend;
    public Color SetCloseToTheBoxToAttach;
    public Color SetColorBoxToAttach;

    public Color setDefaultColor;

    public bool canMagnet;
    public float distanceToMangtize = 1f;

    private void Start()
    {
        isMagnetObject = false;
        canMagnet = false;
        lineRend = GetComponent<LineRenderer>();
        rend = GetComponent<MeshRenderer>();
        setDefaultColor = rend.material.color;
    }
    private void OnTriggerEnter(Collider other)
    {
       

    }
    
    private void OnTriggerExit(Collider other)
    {
        if(isMagnetObject == false && setObjectToMagnetize != null)
        {
            //if (other.transform.gameObject.tag == "AttachedBoxes")
            //{
            //    setObjectToMagnetize.GetComponent<Rigidbody>().isKinematic = false;
            //    setObjectToMagnetize.GetComponent<Rigidbody>().useGravity = true;
            //    rend.material.color = setDefaultColor;
            //    canMagnet = false;
            //    setObjectToMagnetize = null;

            //}
        }
        if (isMagnetObject == true && setObjectToMagnetize != null)
        {
            //if (other.transform.gameObject.name == setObjectToMagnetize.gameObject.name)
            //{
            //    setObjectToMagnetize.GetComponent<Rigidbody>().isKinematic = false;
            //    setObjectToMagnetize.GetComponent<Rigidbody>().useGravity = true;
            //    rend.material.color = setDefaultColor;
            //    canMagnet = false;
            //    setObjectToMagnetize = null;
            //    isMagnetObject = false;

            //}
        }

    }


    private void Update()
    {
        MagnetizeObjectVR3();

        if (isMagnetObject == false)
        {
            SetLineRendTarget();
        }
        else
        {
            lineRend.enabled = false;
        }
    
    }
    public void MagnetizeObjectVR1()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isMagnetObject == false)
            {
                if (setObjectToMagnetize != null)
                {
                    setObjectToMagnetize.GetComponent<Rigidbody>().isKinematic = false;
                    setObjectToMagnetize.GetComponent<Rigidbody>().useGravity = false;

                    jointInstance = setObjectToMagnetize.AddComponent<FixedJoint>();


                    jointInstance.connectedBody = this.GetComponent<Rigidbody>();
                    jointInstance.breakTorque = 212200f;
                    jointInstance.breakForce = 212200f;
                    jointInstance.enablePreprocessing = true;
                    jointInstance.enableCollision = true;
                    Debug.Log("ISMAGNET");
                    isMagnetObject = true;
                }
            }
            else
            {

                setObjectToMagnetize.GetComponent<Rigidbody>().isKinematic = false;
                Destroy(jointInstance);
                setObjectToMagnetize.GetComponent<Rigidbody>().useGravity = true;
                setObjectToMagnetize = null;

                isMagnetObject = false;



            }

        }
    }
    public void MagnetizeObjectVR2()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isMagnetObject == false && canMagnet)
            {
                if (setObjectToMagnetize != null)
                {
                    setObjectToMagnetize.GetComponent<Rigidbody>().isKinematic = false;
                    setObjectToMagnetize.GetComponent<Rigidbody>().useGravity = true;
                    setObjectToMagnetize.GetComponent<Rigidbody>().inertiaTensor = Vector3.zero;
                    setObjectToMagnetize.GetComponent<Rigidbody>().centerOfMass = Vector2.zero;
                    jointInstance1 = setObjectToMagnetize.AddComponent<HingeJoint>();

                    rend.material.color = SetCloseToTheBoxToAttach;

                    jointInstance1.autoConfigureConnectedAnchor = false;
                    jointInstance1.axis = new Vector3(0, 1, 0);
                    jointInstance1.connectedBody = this.GetComponent<Rigidbody>();
                   

         
                    jointInstance1.breakTorque = Mathf.Infinity;
                    jointInstance1.breakForce = Mathf.Infinity;
                    jointInstance1.enablePreprocessing = false;
                    jointInstance1.enableCollision = false;

                    jointInstance1.connectedAnchor = new Vector3(0, -2.05f, 0);
                    jointInstance1.useLimits = true;
                    JointLimits JLimits = jointInstance1.limits;
                    JLimits.bounceMinVelocity = 0.0f;
                    JLimits.bounciness = 0;
                    jointInstance1.limits = JLimits;
                    Debug.Log("ISMAGNET");
                    isMagnetObject = true;
                    canMagnet = false;
                }
            }
            else
            {
                if (setObjectToMagnetize != null)
                {

                    setObjectToMagnetize.GetComponent<Rigidbody>().isKinematic = false;
                    Destroy(jointInstance1);
                    setObjectToMagnetize.GetComponent<Rigidbody>().useGravity = true;
                    setObjectToMagnetize = null;
                    rend.material.color = setDefaultColor;
                    canMagnet = true;
                    isMagnetObject = false;
                }


            }

        }
    }
    public void MagnetizeObjectVR3()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isMagnetObject == false && canMagnet)
            {
                if (setObjectToMagnetize != null)
                {
                    setObjectToMagnetize.GetComponent<Rigidbody>().isKinematic = false;
                    setObjectToMagnetize.GetComponent<Rigidbody>().useGravity = true;
                    setObjectToMagnetize.GetComponent<Rigidbody>().inertiaTensor = Vector3.one;
                    setObjectToMagnetize.GetComponent<Rigidbody>().centerOfMass = Vector2.zero;
                    jointInstance2 = setObjectToMagnetize.AddComponent<CharacterJoint>();

                    rend.material.color = SetCloseToTheBoxToAttach;

                    jointInstance2.autoConfigureConnectedAnchor = false;
                    jointInstance2.axis = new Vector3(0, 0, 0);
  

                    jointInstance2.enablePreprocessing = true;
       
                        jointInstance2.connectedAnchor = new Vector3(0, -2.05f, 0);
                        jointInstance2.connectedBody = this.GetComponent<Rigidbody>();

                        jointInstance2.projectionAngle = 0f;

                        jointInstance2.breakTorque = Mathf.Infinity;
                        jointInstance2.breakForce = Mathf.Infinity;
                        jointInstance2.enableCollision = false;


                        Debug.Log("ISMAGNET");
                        isMagnetObject = true;
                        canMagnet = false;
                    


                }
            }
            else
            {
                if (setObjectToMagnetize != null)
                {

                    setObjectToMagnetize.GetComponent<Rigidbody>().isKinematic = false;
                    Destroy(jointInstance2);
                    setObjectToMagnetize.GetComponent<Rigidbody>().useGravity = true;
                    setObjectToMagnetize = null;
                    rend.material.color = setDefaultColor;
                    canMagnet = true;
                    isMagnetObject = false;
                }


            }

        }
    }
    public void SetLineRendTarget()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down,out hit,600f, layers) && isMagnetObject == false)
        {

            lineRend.enabled = true;
            rend.material.color = setDefaultColor;

            lineRend.SetPosition(0, transform.position);
            lineRend.SetPosition(1, hit.point);
            if(hit.transform.gameObject.tag == "AttachedBoxes"&& isMagnetObject == false)
            {
                lineRend.colorGradient = lineRendAttachedBoxColor ;
                if (Physics.Raycast(transform.position, Vector3.down, out hit, distanceToMangtize, layers))
                {

                    if (hit.transform.gameObject.tag == "AttachedBoxes")
                    {
                        setObjectToMagnetize = hit.transform.gameObject;
                        Debug.Log("attachCanDo");
                        rend.material.color = SetColorBoxToAttach;

                        canMagnet = true;
                    }


                }
            }
            else
            {
                lineRend.colorGradient = lineRenddefault;
   

            }

        }
        else
        {
         
                lineRend.SetPosition(0, transform.position);
                lineRend.SetPosition(1, transform.position);
          
        }
        

      
    }

    public void SetPhysicsWithMagnet()
    {

    }
}
