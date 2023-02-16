using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject BulletPref;
    public GameObject RotatorBase;

    public GameObject Rotator;
    public float CurrentFireRate;
    public float SetFireRate;
    public float MinF, MaxF;
    public float TimeToActive = 20f;
    public bool isActive;
    public LayerMask Layer;
    public float Rad;
    public Transform PlaceOfFire;
    public ParticleSystem psDestruction;
    public float CurrentOffset;
    public float CurrentRotatorRotX;
    public float minOffSet, MaxOffset;
    public float minYaw, maxYaw;
    public float RotationSpeed;
    public bool SetRotationOffset = false;
    Quaternion lookRotation1;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        Invoke("SetActivated", TimeToActive);
        SetFireRate = Random.Range(MinF, MaxF);
        rb = this.transform.parent.parent.gameObject.GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        CurrentFireRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            RaycastHit hit;
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, Rad,Layer);
            foreach (Collider hitCollider in hitColliders)
            {
                RotateToTheBasePlayer(hitCollider.transform.gameObject);
                CurrentFireRate += Time.deltaTime;
                if (CurrentFireRate > SetFireRate)
                {
                    Shoot();
                    CurrentFireRate = 0;
                }
            }

             
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "Ground")
        {
          ParticleSystem PSDesIns = Instantiate(psDestruction, transform.position, Quaternion.identity);
            Destroy(PSDesIns, 5f);
            Destroy(this.transform.parent.parent.gameObject);
        }
    }
    public void RotateToTheBasePlayer(GameObject player)
    {
        Vector3 lookDirection = player.transform.position - RotatorBase.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
        Quaternion StoredRotation = Rotator.transform.rotation;
        StoredRotation.x = Mathf.Clamp(StoredRotation.x, minYaw, maxYaw);
        Vector3 rotation = Quaternion.Lerp(RotatorBase.transform.rotation, lookRotation, Time.deltaTime * RotationSpeed).eulerAngles;
        float getYRotation = rotation.y;



        //RotatorBase.transform.rotation = Quaternion.Euler(RotatorBase.transform.eulerAngles.x, getYRotation, RotatorBase.transform.eulerAngles.z);
        //Quaternion lookRotation1 = Quaternion.LookRotation(lookDirection);

        if (SetRotationOffset == false)
        {
            CurrentRotatorRotX = 0f;
            lookRotation1 = Quaternion.LookRotation(lookDirection);

            CurrentOffset = Random.Range(minOffSet, MaxOffset);
            CurrentRotatorRotX += CurrentOffset;
            //lookRotation1.x = lookRotation1.x + CurrentOffset;
            //CurrentRotatorRotX = Mathf.Clamp(lookRotation1.x, minOffSet, MaxOffset);
            //lookRotation1 = Quaternion.Euler(lookRotation1.x + CurrentOffset, lookRotation1.y, lookRotation1.z);
            lookRotation1 = Quaternion.Euler(CurrentRotatorRotX * Mathf.Rad2Deg, lookRotation1.y, lookRotation1.z);
            SetRotationOffset = true;
        }
        Vector3 rotationR = Quaternion.Lerp(Rotator.transform.localRotation, lookRotation1, Time.deltaTime * RotationSpeed).eulerAngles;

        float angleXRotator = rotationR.x;

        //Rotator.transform.rotation = Quaternion.Euler(CurrentRotatorRotX, Rotator.transform.eulerAngles.y, Rotator.transform.eulerAngles.z);
        //Rotator.transform.rotation = Quaternion.Euler(rotationR.x, Rotator.transform.eulerAngles.y, Rotator.transform.eulerAngles.z);
        Rotator.transform.eulerAngles = new Vector3(rotationR.x, Rotator.transform.eulerAngles.y, Rotator.transform.eulerAngles.z);
        //Rotator.transform.rotation = Quaternion.Euler(rotationR.x, Rotator.transform.eulerAngles.y, Rotator.transform.eulerAngles.z);

        //Rotator.transform.eulerAngles = new Vector3(CurrentRotatorRotX, Rotator.transform.eulerAngles.y, Rotator.transform.eulerAngles.z);
        //RotateBase
        RotatorBase.transform.eulerAngles = new Vector3(RotatorBase.transform.eulerAngles.x, rotation.y, RotatorBase.transform.eulerAngles.z);


    }
    public void SetActivated()
    {
        rb.freezeRotation = false;

        isActive = true;
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(BulletPref, PlaceOfFire.transform.position, PlaceOfFire.transform.rotation);

        SetRotationOffset = false;
        Destroy(bullet, 20f);
    }
}
