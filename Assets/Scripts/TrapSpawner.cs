using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 8f;
    [SerializeField] GameObject[] traps;
    [SerializeField] GameObject[] powerUps;
    [SerializeField] GameObject coin;
    public float timeBetweenTraps= 3f;
    private bool lastManhole, lastMeat;
    void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnTrap", 1f, timeBetweenTraps);
        InvokeRepeating("SpawnCoin", 3.5f, 5f);
        InvokeRepeating("SpawnPowerUp", 5f, 7f);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }
    private GameObject GetRandomTrap()
    {
        return traps[UnityEngine.Random.Range(0, traps.Length)];
    }
    private GameObject GetRandomPowerUp()
    {
        return powerUps[UnityEngine.Random.Range(0, powerUps.Length)];
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
            minX = 2.25f;
            maxX = 6.75f;
            if (lastManhole)
            {
                randTrap = traps[0];
                lastManhole = false;
            }
            else
            {
                lastManhole = true;
            }
        }
        else if(randTrap.name == "RottenMeat")
        {
            minX = 1f;
            maxX = 8f;
            if (lastMeat)
            {
                randTrap = traps[0];
                lastMeat = false;
            }
            else
            {
                lastMeat = true;
            }
        }
        else
        {
            minX = 1f;
            maxX = 8f;
        }
        Instantiate(randTrap, new Vector2(GetRandomNumberInRange(minX, maxX), 8f), new Quaternion());
    }
    private void SpawnCoin()
    {
        minX = 1f;
        maxX = 8f;
        Instantiate(coin, new Vector2(GetRandomNumberInRange(minX, maxX), 8f), new Quaternion());
    }
    private void SpawnPowerUp()
    {
        minX = 1f;
        maxX = 8f;
        GameObject randPowerUp = GetRandomPowerUp();
        Instantiate(randPowerUp, new Vector2(GetRandomNumberInRange(minX, maxX), 8f), new Quaternion());
    }
}
