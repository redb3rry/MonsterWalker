using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 8f;
    [SerializeField] GameObject[] traps;
    [SerializeField] float timeBetweenTraps= 5f;
    void Start()
    {
        InvokeRepeating("SpawnTrap", 3f, timeBetweenTraps);
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
        Instantiate(GetRandomTrap(), new Vector2(GetRandomNumberInRange(minX, maxX), 8f), new Quaternion());
    }
}
