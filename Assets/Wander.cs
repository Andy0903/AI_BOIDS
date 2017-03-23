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
    float angle;

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

            angle += Random.Range(-10, 10);

            float radius = 4;
            float circleOffset = 5;

            Vector3 circleCentrum = Vector3.Normalize(target - transform.position) * circleOffset;

            target.x = circleCentrum.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            target.y = circleCentrum.y;
            target.z = circleCentrum.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        }
    }
}
