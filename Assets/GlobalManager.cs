using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    [SerializeField]
    GameObject boidPref;
    [SerializeField]
    GameObject targetPref;

    [SerializeField]
    int worldSize = 5;
    [SerializeField]
    int numberOfBoids = 10;

    public static List<GameObject> boids = new List<GameObject>();
    public static Vector3 targetPos = Vector3.zero;

    void Start()
    {
        for (int i = 0; i < numberOfBoids; i++)
        {
            Vector3 position = GenerateRandomWorldPos();

            boids.Add(Instantiate(boidPref, position, Quaternion.identity));
        }
    }
    
    void Update()
    {
        if (Random.Range(0, 100) == 1)
        {
            targetPos = GenerateRandomWorldPos();
            targetPref.transform.position = targetPos;
        }
    }

    Vector3 GenerateRandomWorldPos()
    {
        return new Vector3(Random.Range(-worldSize, worldSize),
                           Random.Range(-worldSize, worldSize),
                           Random.Range(-worldSize, worldSize));
    }
}
