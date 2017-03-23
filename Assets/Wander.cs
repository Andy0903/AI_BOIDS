using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    float timeCounter = 0;
    [SerializeField]
    float minSpeed = 0.5f;
    [SerializeField]
    float maxSpeed = 2f;
    [SerializeField]
    float rotationSpeed = 5f;
    float speed;
    Vector3 target;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        if (target != null)
        {
            UpdateTarget();

            Vector3 direction = (target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                          Quaternion.LookRotation(direction),
                                          rotationSpeed * Time.deltaTime);

            transform.Translate(0, 0, Time.deltaTime * speed);
        }
    }

    void UpdateTarget()
    {
        if (timeCounter + 0.3f < Time.time)
        {
            timeCounter = Time.time;
            float x = Mathf.Cos(Random.Range(-1f, 1f));
            float y = Mathf.Sin(Random.Range(-1f, 1f));
            float z = transform.position.z + Random.Range(-1f, 1f);

            target = new Vector3(x, y, z);
        }
    }
}
