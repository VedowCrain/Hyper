using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriSpawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject[] TriPrefab;
    public float Timer;
    private float CurrentTimer;

    // Use this for initialization
    void Start()
    {
        CurrentTimer = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTimer -= Time.deltaTime;

        if (CurrentTimer <= 0)
        {
            Instantiate(TriPrefab[Random.Range(0, TriPrefab.Length)], SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.position, SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.rotation);
            CurrentTimer = Timer;
        }
    }
}
