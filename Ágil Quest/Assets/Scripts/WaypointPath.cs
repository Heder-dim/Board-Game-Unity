using UnityEngine;
using System.Collections.Generic;

public class WaypointPath : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();

    void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }
    }
}
