using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalisticBallController : MonoBehaviour
{
   public  Rigidbody rb;
    public float forceNum = 10000f;

    public CraineControlller CrControl;


    public List<GameObject> nodes;
    public Transform rotatorTransCrane;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                //rb.AddRelativeForce(ray.direction * forceNum * Time.deltaTime, ForceMode.Impulse);
                nodes = CrControl.NodesList;
                Debug.Log(CrControl.NodesList.Count);
                for (int i = 0; i < nodes.Count; i++)
                {
                    Rigidbody rbSet = nodes[i].transform.GetComponent<Rigidbody>();

                    //rbSet.velocity = nodes[i].transform.forward * forceNum;
                    rbSet.velocity = CrControl.rotatorTrans.transform.forward * forceNum;
                }

            }
            //rb.velocity = Vector3.forward * forceNum;
        }
    }
    public void SetLoopOfNodeList1()
    {
        nodes = CrControl.NodesList;
        Debug.Log(CrControl.NodesList.Count);
        for (int i = 0; i < nodes.Count; i++)
        {
            Rigidbody rbSet = nodes[i].transform.GetComponent<Rigidbody>();
            rbSet.velocity = nodes[i].transform.right * forceNum;
        }

    }
    public void SetLoopOfNodeList()
    {
        nodes = CrControl.NodesList;
        Debug.Log(CrControl.NodesList.Count);
        for(int i = 0; i < nodes.Count;i++)
         {
            Rigidbody rbSet = nodes[i].transform.GetComponent<Rigidbody>();
           rbSet.velocity = nodes[i].transform.right * forceNum;
        }

    }

}
