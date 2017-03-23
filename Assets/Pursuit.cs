using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    float minSpeed = 0.5f;
    [SerializeField]
    float maxSpeed = 2f;
    [SerializeField]
    float rotationSpeed = 5f;
    float speed;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        if (target != null)
        {
            Flock flock = target.GetComponent<Flock>();

            Vector3 direction = (flock.futurePos() - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation,
                                          Quaternion.LookRotation(direction),
                                          rotationSpeed * Time.deltaTime);

            transform.Translate(0, 0, Time.deltaTime * speed);
        }
    }
}
