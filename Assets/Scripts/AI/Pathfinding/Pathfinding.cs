using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;
using System.Linq;

public static class Pathfinding
{
    private static float Heuristic(Waypoints wp1, Waypoints wp2)
    {
        return Vector3.Distance(wp1.transform.position, wp2.transform.position);
    }

    private static List<Waypoints> ReconstructPath(Dictionary<Waypoints, Waypoints> cameFrom, Waypoints current, Waypoints start)
    {
        List<Waypoints> finalPath = new List<Waypoints>();
        finalPath.Add(current);
        while (current != start)
        {
            foreach (Waypoints wp in cameFrom.Keys)
            {
                if (wp == current)
                {
                    current = cameFrom[wp];
                    finalPath.Add(current);
                }
            }
        }
        finalPath.Reverse();
        return finalPath;
    }

    public static List<Waypoints> FindPath(Waypoints start, Waypoints goal, List<Waypoints> waypoints)
    {
        List<Waypoints> closedSet = new List<Waypoints>();
        SimplePriorityQueue<Waypoints> openSet = new SimplePriorityQueue<Waypoints>();
        openSet.Enqueue(start, Heuristic(start, goal));

        Dictionary<Waypoints, Waypoints> cameFrom = new Dictionary<Waypoints, Waypoints>();

        Dictionary<Waypoints, float> gScore = new Dictionary<Waypoints, float>();
        foreach (Waypoints wp in waypoints)
        {
            gScore.Add(wp, Mathf.Infinity);
        }

        gScore[start] = 0;

        while (openSet.Count > 0)
        {
            Waypoints current = openSet.Dequeue();
            if (current == goal)
            {
                return ReconstructPath(cameFrom, current, start);
            }
            closedSet.Add(current);
            foreach (Waypoints neighbour in current.edges)
            {
                if (closedSet.Contains(neighbour))
                {
                    continue;
                }
                if (!openSet.Contains(neighbour))
                {
                    openSet.Enqueue(neighbour, gScore[neighbour] + Heuristic(neighbour, goal));
                }
                float tentative_gScore = gScore[current] + Vector3.Distance(current.transform.position, neighbour.transform.position);
                if (tentative_gScore >= gScore[neighbour])
                {
                    continue;
                }
                cameFrom[neighbour] = current;
                gScore[neighbour] = tentative_gScore;
                openSet.UpdatePriority(neighbour, gScore[neighbour] + Heuristic(neighbour, goal));

            }
        }
        return new List<Waypoints>();
    }
}
