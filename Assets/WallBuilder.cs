using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WallBuilder : MonoBehaviour
{
    public Image imgFill;

    public float maxFill;
    public float currentfill;
    public bool isActiveNow;
    public GameObject DefenderWallInstance;
    public GameObject Canvas;
    public GameObject checkWallDefender;

    public float height = 5f;
    // Start is called before the first frame update
    void Start()
    {
        currentfill = 0;
        isActiveNow = true;
        imgFill.fillAmount = currentfill / maxFill;
    }
    public void fillTheBox(float fillNum)
    {
        if(isActiveNow == true)
        {
            currentfill += fillNum;
            imgFill.fillAmount = currentfill / maxFill;
            if (currentfill >= maxFill)
            {
                currentfill = maxFill;
                //InstiateBox
                GameObject goSet = Instantiate(DefenderWallInstance, this.transform.position, this.transform.rotation);
                StartCoroutine(setBoxAnim(goSet));
                //DisableTriggering
                checkWallDefender = goSet;

                //put this instance insideTheWall
                goSet.GetComponent<WallDefendBox>().wb = this;

                Canvas.SetActive(false);
                isActiveNow = false;
            }
        }

    }
 
    public void setBackToActive()
    {
        Canvas.SetActive(true);
        currentfill = 0;
        imgFill.fillAmount = currentfill / maxFill;

    }
    IEnumerator setBoxAnim(GameObject go)
    {
        Vector3 vec = new Vector3(go.transform.position.x, go.transform.position.y + height, go.transform.position.z);
        go.transform.position = Vector3.Lerp(go.transform.position, vec, 5f);
        yield return new WaitForSeconds(5f);
    }
}
