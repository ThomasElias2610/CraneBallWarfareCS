using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawnerScript : MonoBehaviour
{
    [SerializeField] public float Radius = 5f;

    public GameObject boxSpawner;
    [SerializeField] public bool TimeIsStarted;
    public float PerTime = 3;
    public float CurrentTime;
    public float MinTime, MaxTime;
    public int NumberOfSpaws;
    public int MinSpawn, MaxSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartingTheDefenderSpawns", 30f);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeIsStarted)
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime > PerTime)
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
   
                SpawnADefender();

        }
    }
    public void SpawnADefender()
    {
        Vector3 setPos = transform.position + Random.insideUnitSphere * Radius;
        GameObject set = Instantiate(boxSpawner, setPos, Quaternion.identity);

    }
    public void StartingTheDefenderSpawns()
    {
        TimeIsStarted = true;
        CurrentTime = 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

}
