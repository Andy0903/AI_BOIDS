using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
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
        float distanceToTarget = 1;

        if (target != null)
        {
            Flock flock = target.GetComponent<Flock>();

            Vector3 direction = (flock.futurePos() - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation,
                                          Quaternion.LookRotation(direction),
                                          rotationSpeed * Time.deltaTime);

            distanceToTarget = Vector3.Distance(flock.futurePos(), transform.position);


            transform.Translate(0, 0, Time.deltaTime * speed * Mathf.Clamp(distanceToTarget, 0, 1));
            Debug.Log(Mathf.Clamp(distanceToTarget, 0, 1));
        }
    }
}
