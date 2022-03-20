using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Vector3 destination;
    public bool reachedDestination;
    public float stopDistance = 0.5f;
    public float rotationspeed = 10f;
    public float moveSpeed = 3f;
    FieldOfView fov;

    private void Awake()
    {
        fov = GetComponent<FieldOfView>();
    }

    void Update()
    {
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destiantionDistance = destinationDirection.magnitude;

            if (fov.canSeePlayer == true)
            {
                destination = fov.detectedPlayerLocation;
            }


            if(fov.canHearTarget == true)
            {
                destination = fov.hearedPlayerLocation;
            }

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
                SetDestination();
            }
        }
        else
            reachedDestination = true;

    }

    void SetDestination()
    {
        PlayerPrefs.SetFloat("Des.x", Random.Range(-33f, 33f));
        PlayerPrefs.SetFloat("Des.z", Random.Range(-25f, 25f));

        destination = new Vector3(PlayerPrefs.GetFloat("Des.x"), 0, PlayerPrefs.GetFloat("Des.z"));

        //destination = new Vector3(Random.Range(-33f, 33f), 0, Random.Range(-25f, 25));

    }


}


