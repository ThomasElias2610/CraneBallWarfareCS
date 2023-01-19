using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CraineControlller : MonoBehaviour
{

    public GameObject NodePref;

    public List<GameObject> NodesList;

    public LineRenderer lineRend;
    public Cinemachine.CinemachineVirtualCamera c_VirtualCam;
    public CinemachineVirtualCamera c_VirtualCam2;

    public GameObject Magnet;
    public GameObject balsticBall;

    GameObject HookIns;
    GameObject hookObjectAttached;
    public GameObject hookObjectAttachedSetter;

    public GameObject[] getNodesPrev;
    public GameObject lastNodeCreated;
    public int NumOfNodes;
    public int MaxNodes, MinNodes;
    public bool set1;

    public bool isMagnet;

    public bool isMainCam;

    public float nodeLengthCreate = -0.2f;

    public float heightCheck;
    public float MinheightCheck;
    public float MaxheightCheck;
    public float HeightCheckIncriment;

    public GameObject CranePollScrewRotateGO1;
    public GameObject CranePollScrewRotateGO2;

    public bool isLiftUp;
    public float liftpollRot = 5f;

    public Cinemachine.CinemachineFreeLook c_VirtualCam3;

    public Transform rotatorTrans;
    // Start is called before the first frame update
    private void Awake()
    {
        lineRend = GetComponent<LineRenderer>();
        NumOfNodes = 0;

        SetNodes(5);
        isMagnet = false;
    }
    void Start()
    {
        c_VirtualCam3.Priority = 100;

        SwitchPiority1();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.T) && NumOfNodes < MaxNodes)
        {
            //Put Rope Down
            isLiftUp = false;
            RotatePollsGO();

            Vector3 setVec = NodesList[1].transform.position;
            NodesList[1].transform.position = new Vector3(setVec.x, setVec.y - 0.01f, setVec.z);
            heightCheck += HeightCheckIncriment * Time.time;

            SetNodeDownVR1();
        }



        if (Input.GetKey(KeyCode.R) && NumOfNodes > MinNodes)
        {
            //Put Rope Up
            isLiftUp = true;
            RotatePollsGO();
            Vector3 setVec = NodesList[1].transform.position;
            NodesList[1].transform.position = new Vector3(setVec.x, setVec.y + 0.01f, setVec.z);
            heightCheck -= HeightCheckIncriment * Time.time;

            SetNodeUpVR1();



        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ReplaceHook();
        }
        SetLineNodes();
        SwitchPiority();
    }


    public void SetNodeDownVR1()
    {

        if (heightCheck >= MaxheightCheck)
        {
            Vector3 SETvecIns = NodesList[0].transform.position;
            //SETvecIns.y = SETvecIns.y + nodeLengthCreate;
            GameObject SetNodeIns = Instantiate(NodePref, SETvecIns, Quaternion.identity);




            getNodesPrev = NodesList.ToArray();


            NodesList.Add(SetNodeIns);
            NodesList[1] = SetNodeIns;
            getNodesPrev[1].GetComponent<CharacterJoint>().connectedBody = NodesList[1].transform.GetComponent<Rigidbody>();
            getNodesPrev[1].GetComponent<CharacterJoint>().autoConfigureConnectedAnchor = false;
            //


            //
            Vector3 vecSet = new Vector3(0, nodeLengthCreate, 0);
            getNodesPrev[1].GetComponent<CharacterJoint>().connectedAnchor = vecSet;
            NumOfNodes++;
            for (int i = 2; i < NumOfNodes; i++)
            {
                NodesList[i] = getNodesPrev[i - 1].transform.gameObject;
                NodesList[i].gameObject.transform.parent = null;
                NodesList[i].GetComponent<Rigidbody>().isKinematic = false;
            }
            NodesList[1].gameObject.transform.SetParent(NodesList[0].transform);
            //
            SetNodeIns.GetComponent<CharacterJoint>().connectedBody = NodesList[0].transform.GetComponent<Rigidbody>();
            SetNodeIns.GetComponent<CharacterJoint>().autoConfigureConnectedAnchor = false;

            Vector3 vecSet1 = new Vector3(0, nodeLengthCreate, 0);
            NodesList[1].GetComponent<CharacterJoint>().connectedAnchor = new Vector3(0, 0, 0);

            //
            NodesList[1].GetComponent<Rigidbody>().isKinematic = false;

            heightCheck = 0;
        }
    }

    public void SetNodeUpVR1()
    {
        if (heightCheck <= MinheightCheck)
        {
            Destroy(NodesList[1].gameObject);
            NodesList.RemoveAt(1);
            NodesList[2].GetComponent<CharacterJoint>().connectedBody = NodesList[1].GetComponent<Rigidbody>();
            NodesList[2].GetComponent<CharacterJoint>().autoConfigureConnectedAnchor = false;
            Vector3 vecSet = new Vector3(0, nodeLengthCreate, 0);
            NodesList[2].GetComponent<CharacterJoint>().connectedAnchor = vecSet;
            NodesList[1].GetComponent<CharacterJoint>().connectedBody = NodesList[0].GetComponent<Rigidbody>();
            NodesList[1].GetComponent<CharacterJoint>().connectedAnchor = new Vector3(0, 0, 0);

            NodesList[1].GetComponent<Rigidbody>().isKinematic = false;
            NodesList[1].gameObject.transform.SetParent(NodesList[0].transform);
            //NodesList[2].GetComponent<CharacterJoint>().autoConfigureConnectedAnchor = true;
            //


            //
            NumOfNodes--;
            heightCheck = 0;

        }
    }
    public void SetNodes(int numOfNodesS)
    {
        float SetHeightDis = 2f;
        Vector3 SETvec = this.transform.position;






        this.transform.gameObject.name = "CraneControl";
        NodesList.Add(this.transform.gameObject);
        lastNodeCreated = this.transform.gameObject;
        Vector3 SETvecIns = lastNodeCreated.transform.position;
        float currentHeightCreatedYOffset = SETvecIns.y;
        lastNodeCreated.transform.position = new Vector3(SETvecIns.x, currentHeightCreatedYOffset, SETvecIns.z);
        lastNodeCreated.GetComponent<Rigidbody>().isKinematic = true;
        NumOfNodes++;
        for (int i = 0; i < numOfNodesS; i++)
        {
            Vector3 SETvecIns1S = lastNodeCreated.transform.position;

            GameObject SetNodeIns = Instantiate(NodePref, SETvecIns1S, Quaternion.identity);
            SetNodeIns.transform.gameObject.name = "Node" + i;
            NodesList.Add(SetNodeIns);
            SetNodeIns.GetComponent<Rigidbody>().isKinematic = true;
            GameObject prevNode = lastNodeCreated;
            lastNodeCreated = SetNodeIns;
            Vector3 SETvecInsS = lastNodeCreated.transform.position;

            currentHeightCreatedYOffset = SETvecIns1S.y + nodeLengthCreate;

            lastNodeCreated.transform.position = new Vector3(SETvecIns.x, currentHeightCreatedYOffset, SETvecIns.z);
            SetNodeIns.GetComponent<CharacterJoint>().connectedBody = prevNode.GetComponent<Rigidbody>();
            Vector3 vecSet = new Vector3(0, nodeLengthCreate, 0);

            SetNodeIns.GetComponent<CharacterJoint>().autoConfigureConnectedAnchor = false;
            SetNodeIns.GetComponent<CharacterJoint>().connectedAnchor = vecSet;
            //SetNodeIns.GetComponent<CharacterJoint>().autoConfigureConnectedAnchor = true;

            NumOfNodes++;


        }
        CreateHooK(lastNodeCreated);
    }

    public void ReplaceHook()
    {
        if (isMagnet)
        {
            GameObject setGO = NodesList[NodesList.Count - 1];
            Vector3 setV = new Vector3(setGO.transform.position.x, setGO.transform.position.y, setGO.transform.position.z);
            GameObject prevHook = hookObjectAttached;
            hookObjectAttached = Instantiate(balsticBall, setV, Quaternion.identity);
            hookObjectAttached.GetComponent<BalisticBallController>().CrControl = this;

            Destroy(prevHook);
            hookObjectAttached.transform.SetParent(HookIns.transform);

            isMagnet = false;
        }
        else
        {
            GameObject setGO = NodesList[NodesList.Count - 1];
            Vector3 setV = new Vector3(setGO.transform.position.x, setGO.transform.position.y, setGO.transform.position.z);
            GameObject prevHook = hookObjectAttached;
            hookObjectAttached = Instantiate(Magnet, setV, Quaternion.identity);
            Destroy(prevHook);
            hookObjectAttached.transform.SetParent(HookIns.transform);



            isMagnet = true;
        }
    }
    public void SetLineNodes()
    {
        Vector3 SETvec = this.transform.position;

        for (int i = 0; i < NumOfNodes; i++)
        {
            lineRend.positionCount = NumOfNodes;
            lineRend.SetPosition(i, NodesList[i].transform.position);
        }
    }

    public void CreateHooK(GameObject lastPostCreated)
    {
        float setF = lastPostCreated.transform.position.y - 5.5f;
        Vector3 setV = new Vector3(lastPostCreated.transform.position.x, setF, lastPostCreated.transform.position.z);
        heightCheck = 0;
        HookIns = Instantiate(hookObjectAttachedSetter, setV, Quaternion.identity);
        HookIns.GetComponent<Rigidbody>().isKinematic = true;
        NodesList.Add(HookIns);
        HookIns.GetComponent<CharacterJoint>().connectedBody = lastNodeCreated.GetComponent<Rigidbody>();
        HookIns.GetComponent<CharacterJoint>().autoConfigureConnectedAnchor = false;
        Vector3 vecSet = new Vector3(0, nodeLengthCreate, 0);
        HookIns.GetComponent<CharacterJoint>().connectedAnchor = vecSet;
        NumOfNodes++;
        hookObjectAttached = Instantiate(balsticBall, setV, Quaternion.identity);
        hookObjectAttached.GetComponent<BalisticBallController>().CrControl = this;
        hookObjectAttached.transform.SetParent(HookIns.transform);
        c_VirtualCam.m_LookAt = HookIns.transform;
        c_VirtualCam2.m_LookAt = HookIns.transform;

        NodesList[1].gameObject.transform.SetParent(NodesList[0].transform);

        for (int i = 1; i < NodesList.Count; i++)
        {
            NodesList[i].GetComponent<Rigidbody>().isKinematic = false;
        }
        NodesList[1].GetComponent<Rigidbody>().isKinematic = true;

        HookIns.GetComponent<CharacterJoint>().autoConfigureConnectedAnchor = true;


    }

    public void SwitchPiority()
    {
        if (NumOfNodes > 30)
        {
            c_VirtualCam2.Priority = 1;
            c_VirtualCam.Priority = 0;

        }
        else
        {
            c_VirtualCam.Priority = 1;
            c_VirtualCam2.Priority = 0;

        }
    }

    public void SwitchPiority1()
    {
            c_VirtualCam3.Priority = -100;
            c_VirtualCam.Priority = 1;
            c_VirtualCam2.Priority = 0;

        
    }
    public void RotatePollsGO()
    {


        if(isLiftUp)
        {
            CranePollScrewRotateGO1.transform.Rotate(Vector3.up * liftpollRot * Time.deltaTime, Space.Self);
            CranePollScrewRotateGO2.transform.Rotate(-Vector3.up * liftpollRot * Time.deltaTime, Space.Self);

        }
        else
        {
            CranePollScrewRotateGO1.transform.Rotate(-Vector3.up * liftpollRot * Time.deltaTime, Space.Self);
            CranePollScrewRotateGO2.transform.Rotate(Vector3.up * liftpollRot * Time.deltaTime, Space.Self);
        }
    }

}
