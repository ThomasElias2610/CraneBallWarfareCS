using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesSpawner : MonoBehaviour
{
    [SerializeField] public float Radius = 5f;

    public GameObject[] BoxesRandom;
    [SerializeField] public static bool TimeIsStarted;
    public float PerTime = 3;
    public float CurrentTime;
    public float MinTime, MaxTime;
    public int NumberOfSpaws;
    public int MinSpawn, MaxSpawn;
    // Start is called before the first frame update
    void Start()
    {
        TimeIsStarted = true;
        CurrentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeIsStarted)
        {
            CurrentTime += Time.deltaTime;
            if(CurrentTime > PerTime)
            {

                PerTime = Random.Range(MinTime, MaxTime);
                SpawnObject();
                CurrentTime = 0;
            }
        }
    }
    public void SpawnObject()
    {
        NumberOfSpaws = Random.Range(MinSpawn, MaxSpawn);
        for (int i = 0; i < NumberOfSpaws; i++)
        {
            int RandomNum = Random.Range(10, 40);
            if(RandomNum <= 20)
            {
                SpawnADefender();
                SpawnAAttacker();
            }
            else if(RandomNum > 20 && RandomNum <= 30)
            {
                SpawnAHealthBox();
                SpawnAAttacker();
            }
            else
            {
                SpawnAHealthBox();
            }
        }
    }

    public void SpawnADefender()
    {
        Vector3 setPos = transform.position + Random.insideUnitSphere * Radius ;
      GameObject set =  Instantiate(BoxesRandom[0], setPos, Quaternion.identity);

    }

    public void SpawnAAttacker()
    {
        Vector3 setPos = transform.position + Random.insideUnitSphere * Radius;
        Instantiate(BoxesRandom[1], setPos, Quaternion.identity);


    }

    public void SpawnAHealthBox()
    {
        Vector3 setPos = transform.position + Random.insideUnitSphere * Radius;
        Instantiate(BoxesRandom[2], setPos, Quaternion.identity);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
