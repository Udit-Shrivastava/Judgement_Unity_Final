using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    PatrolMovement controller;
    public Waypoint currentWaypoint;
    FieldOfView fov;
    bool canSeePlayer;


    private void Awake()
    {
        controller = GetComponent<PatrolMovement>();
        fov = GetComponent<FieldOfView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (fov.canHearTarget)
            controller.SetDestination(fov.hearedPlayerLocation);
        if (fov.canSeePlayer)
        {
            controller.SetDestination(fov.detectedPlayerLocation);
        }
        else if (controller.reachedDestination == true && fov.canSeePlayer == false && fov.canHearTarget == false)
        {
            currentWaypoint = currentWaypoint.nextWayPoint;
            controller.SetDestination(currentWaypoint.GetPosition());
        }

    }
}