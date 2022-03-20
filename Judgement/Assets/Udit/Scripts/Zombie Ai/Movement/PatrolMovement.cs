using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public Vector3 destiantion;
    public bool reachedDestination;
    public float stopDistance = 0.5f;
    public float rotationspeed = 10f;
    public float moveSpeed = 3f;
    void Update()
    {
        if (transform.position != destiantion)
        {
            Vector3 destinationDirection = destiantion - transform.position;
            destinationDirection.y = 0;

            float destiantionDistance = destinationDirection.magnitude;

            if (destiantionDistance >= stopDistance)
            {
                reachedDestination = false;
                Quaternion targetRotaion = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotaion, rotationspeed * Time.deltaTime);
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                reachedDestination = true;
            }
        }
        else
            reachedDestination = true;

    }

    public void SetDestination(Vector3 destination)
    {
        this.destiantion = destination;
        reachedDestination = false;
    }
}
