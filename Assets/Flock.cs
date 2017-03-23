using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    float speed;
    [SerializeField]
    float minSpeed = 0.5f;
    [SerializeField]
    float maxSpeed = 2f;
    [SerializeField]
    float rotationSpeed = 5f;
    Vector3 avgHeadingDirection;
    Vector3 avgPosition;
    float cohesionDist = 4f;
    float separationDist = 2f;

    Vector3 direction;

    public Vector3 futurePos()
    {
        Vector3 pos = transform.position;
        pos += direction * speed * Time.deltaTime;

        return pos;
    }
    
	void Start ()
    {
        speed = Random.Range(minSpeed, maxSpeed);
	}
	
	void Update ()
    {
		if (Random.Range(0, 100) < 20)
        {
            UpdateBehaviors();
        }

        transform.Translate(0, 0, Time.deltaTime * speed);
	}

    void UpdateBehaviors()
    {
        Vector3 directionToCenterOfGroup = Vector3.zero;
        Vector3 separationDirection = Vector3.zero;
        float groupSpeed = 0;
        int groupSize = 0;

        foreach (GameObject g in GlobalManager.boids)
        {
            if (g != gameObject)
            {
                float distanceToBoid = Vector3.Distance(g.transform.position, transform.position);
                if (distanceToBoid <= cohesionDist)
                {
                    directionToCenterOfGroup += transform.position;
                    groupSize++;

                    if (distanceToBoid <= separationDist)
                    {
                        separationDirection += transform.position - g.transform.position;
                    }

                    Flock other = g.GetComponent<Flock>();
                    groupSpeed += other.speed;
                }
            }
        }

        if (groupSize > 0)
        {
            directionToCenterOfGroup = directionToCenterOfGroup / groupSize + (GlobalManager.targetPos - transform.position);
            speed = groupSpeed / groupSize;

            direction = (directionToCenterOfGroup + separationDirection) - transform.position;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(direction),
                                                      rotationSpeed * Time.deltaTime);
            }
        }
    }
}
