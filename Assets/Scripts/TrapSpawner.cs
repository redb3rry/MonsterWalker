using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 8f;
    [SerializeField] GameObject[] traps;
    public float timeBetweenTraps= 5f;
    void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnTrap", 2f, timeBetweenTraps);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }
    private GameObject GetRandomTrap()
    {
        return traps[UnityEngine.Random.Range(0, traps.Length)];
    }
    
    private float GetRandomNumberInRange(float a, float b)
    {
        return UnityEngine.Random.Range(a, b);
    }

    private void SpawnTrap()
    {
        GameObject randTrap = GetRandomTrap();
        if (randTrap.name == "Manhole")
        {
            minX = 2f;
            maxX = 7f;
        }
        else
        {
            minX = 1f;
            maxX = 8f;
        }
        Instantiate(randTrap, new Vector2(GetRandomNumberInRange(minX, maxX), 8f), new Quaternion());
    }
}
