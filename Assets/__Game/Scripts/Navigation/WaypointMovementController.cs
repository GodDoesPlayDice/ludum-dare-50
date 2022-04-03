using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaypointMovementController : MonoBehaviour
{
    #region Inspector

    [SerializeField] private float distanceToPass = 0.5f;
    [SerializeField] private WaypointController waypoint;

    #endregion

    public WaypointController GetCurrentWaypoint()
    {
        if (Vector3.Distance(transform.position, waypoint.transform.position) < distanceToPass)
        {
            if (waypoint.nextWaypoints.Length > 0)
            {
                waypoint = waypoint.nextWaypoints[Random.Range(0, waypoint.nextWaypoints.Length - 1)];
            }
        }

        return waypoint;
    }
}