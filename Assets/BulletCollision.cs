using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float force = 100;
    public ParticleSystem ps;
    public LayerMask layer;

    public float Dmg;
    public float minDmg, MaxDmg;

    // Start is called before the first frame update
    void Start()
    {
        Dmg = Random.Range(minDmg, MaxDmg);
        Destroy(this.gameObject, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * force * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.gameObject.layer);
        if(other.transform.gameObject.tag == "PlayerBase")
        {
            ParticleSystem psS = Instantiate(ps, transform.position, transform.rotation.normalized);
            Destroy(psS, 5f);
            //DownPlayerHealth
            CraneStats crStats = other.transform.gameObject.GetComponentInParent<CraneStats>();
            crStats.damagingCrane(Dmg);
            Destroy(this.gameObject);
        }
        if(other.transform.gameObject.tag == "TranparentWall")
        {
            ParticleSystem psS = Instantiate(ps, transform.position, transform.rotation.normalized);
            Destroy(psS, 5f);
            Destroy(this.gameObject);
        }
        if (other.transform.gameObject.tag == "WallDefender")
        {
            ParticleSystem psS = Instantiate(ps, transform.position, transform.rotation.normalized);
            Destroy(psS, 5f);
            WallDefendBox wdDefendBox = other.transform.gameObject.GetComponent<WallDefendBox>();
            wdDefendBox.SetDamageBox(Dmg);
            Destroy(this.gameObject);
        }
    }
}
