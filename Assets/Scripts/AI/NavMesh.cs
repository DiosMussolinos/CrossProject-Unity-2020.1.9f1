using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System.Linq;

public class NavMesh : MonoBehaviour
{
    public List<Waypoints> waypoints;
    private NavMeshAgent agent;
    private int currWaypoint;
    public Waypoints origin;
    private List<Waypoints> path;
    public float timer;
    public List<Waypoints> targets;
    private int currTarget;
    public GameObject player;
    public bool isGoingBack;
    public float extraRotationSpeed = 10f;
    public Attributes imaginaryFriend;
    public SpeechManager narrations;
    public bool hasSpoken;
    
    // CAT:
    public GameObject[] corners;
    public Transform waypointInCorner;

    public AudioSource animalSFX;
 
    // PANDA :
    public int pandaCountDown = 0;
    public float pandaSleep = 5f;
    public float initialPandaSleepTimer = 5f;

    public ControlAndMovement control;

    //DEER :
    public int deerCountDown = 0;
    public float deerSearch = 3f;
    public float deerSearchInitial = 3f;
    public float deerRotationSpeed = 4f;
    public int sideRotation = 1;
    private int randomNumb;

    public SpeechManager GetNarrations()
    {
        return narrations;
    }

    public int ShadowID()
    {
        return imaginaryFriend.ID;
    }

    public bool IsPathStalled()
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;

    }

    public void EnableCollisionAvoidance()
    {
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
    }

    public void DisableCollisionAvoidance()
    {
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
    }

    public Waypoints GetClosestWaypoint(Vector3 goal)
    {
        float minDist = Mathf.Infinity;
        Waypoints waypoint = null;
        foreach (Waypoints wp in waypoints)
        {
            if (Vector3.Distance(goal, wp.transform.position) < minDist)
            {
                minDist = Vector3.Distance(agent.transform.position, wp.transform.position);
                waypoint = wp;
            }
        }
        return waypoint;
    }

    public void Stroll()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance) // if agent is stopped (if he is on a waypoint)
        {
            if (currWaypoint >= path.Count) // if reached a target
            {
                // mustPause = true;
                UpdateIFPath(); //recalculate path
                currTarget++;
                currWaypoint = 0;
            }
            try
            {
                agent.SetDestination(path[currWaypoint].transform.position); // move to next waypoint
            }
            catch (System.Exception)
            {
                throw;
            }
            currWaypoint++;
        }
    }

    public void Patrol()
    {

        {
            if (currWaypoint >= path.Count)
            {
                if (currTarget >= targets.Count)
                {
                    currTarget = 0;
                }
                UpdatePath(); //recalculate path
                currTarget++;
                currWaypoint = 0;
            }
            agent.SetDestination(path[currWaypoint].transform.position); // move to next waypoint
            currWaypoint++;
            pandaCountDown += 1;
            /*DEER*/
            randomNumb = Random.Range(1, 3);
            if (randomNumb == 1)
            {
                sideRotation = 1;
            }
            else
            {
                sideRotation = -1;
            }
            deerCountDown += 1;
            //Debug.Log(pandaCountDown);
        }
    }

    public void RabbitPatrol()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance) // if agent is stopped (if he is on a waypoint)
        {
            

            if (currWaypoint >= path.Count)
            {
                if (currTarget >= targets.Count)
                {
                    currTarget = 0;
                }
                //float normalDistanceRestart = Vector3.Distance(transform.position, path[currWaypoint + 1].transform.position);
                //Vector3 jumpingRestart = new Vector3(agent.velocity.x, normalDistanceRestart, 0);
                //rb.AddForce(jumpingRestart);

                UpdatePath(); //recalculate path
                currTarget++;
                currWaypoint = 0;
            }


            //float normalDistance = Vector3.Distance(transform.position, path[currWaypoint + 1].transform.position);
            //Vector3 jumping = new Vector3(agent.velocity.x, normalDistance, 0);
            //rb.AddForce(jumping);
            //Debug.Log(rb.velocity.y);
            agent.SetDestination(path[currWaypoint].transform.position); // move to next waypoint
            currWaypoint++;
        }
    }
   
    public void Navigate()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance) // if agent is stopped (if he is on a waypoint)
        {
            agent.SetDestination(path[currWaypoint].transform.position); // move to next waypoint
            currWaypoint++;
        }
    }


    public void ResumeAgent()
    {
        agent.isStopped = false;
    }

    public void PauseAgent()
    {
        agent.isStopped = true;
    }

    public void UpdatePath()
    {
        try
        {
            path = Pathfinding.FindPath(path[currWaypoint - 1], targets[currTarget], waypoints);
        }
        catch (System.Exception ex)
        {
            
            throw ex;
        }

    }

    public void UpdateIFPath() //note: use this if shadow's patrol is stuck at path.count = 0
    {
        try
        {
            path = Pathfinding.FindPath(path[currWaypoint - 1], targets[currTarget], waypoints);
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

    public bool HasReachedEndOfPathOrNoPath()
    {
        return currWaypoint >= path.Count;
    }

    public void UpdateTargets()
    {
        currTarget++;
    }

    public bool IsAtDestination()
    {
        return (!agent.hasPath || (Vector3.Distance(agent.transform.position, targets[currTarget].transform.position) <= 2f)) && currTarget < targets.Count;
    }

    public bool HasReachedFinalTarget()
    {
        return currTarget >= targets.Count && currWaypoint >= path.Count;
    }

    public bool ReachedGoal()
    {
        if (Vector3.Distance(agent.transform.position, targets[targets.Count - 1].transform.position) <= 2f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ReachedOrigin()
    {
        if (Vector3.Distance(agent.transform.position, origin.transform.position) <= 5f)
        {
            currTarget = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GoBack()
    {
        if (!isGoingBack)
        {
            path = Pathfinding.FindPath(targets.Last(), origin, waypoints);
            currWaypoint = 0;
            isGoingBack = true;
        }
        Navigate();
    }

    public void UpdateSpeed(float speed)
    {
        agent.speed = speed;
    }

    public void RotationSpeedExtra()
    {
        Vector3 lookrotation = (agent.steeringTarget - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), extraRotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0f, transform.rotation.eulerAngles.y, 0f));
    }

    public void RestartTimer()
    {
        pandaSleep = initialPandaSleepTimer;
    }

    public void RestartDeerTimer()
    {
        deerSearch = deerSearchInitial;
    }


    public void SetDestinationTo(Vector3 target)
    {
        agent.SetDestination(target);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || (collision.gameObject.CompareTag("Shadow")))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    public void CalculateFirstPath()
    {
        currTarget = 0;
        path = Pathfinding.FindPath(GetClosestWaypoint(transform.position), targets[currTarget], waypoints);
        currTarget++;
        currWaypoint = 0;
    }

    // CAT FUNCTIONS:
    public GameObject GetClosestCorner()
    {
        float minDist = Mathf.Infinity;
        GameObject corner = null;
        foreach (GameObject c in corners)
        {
            if (Vector3.Distance(agent.transform.position, c.transform.position) < minDist)
            {
                minDist = Vector3.Distance(agent.transform.position, c.transform.position);
                corner = c;
            }
        }
        return corner;
    }

    // PLAYER'S SHADOW FUNCTIONS:
    public Waypoints RandomizeTargets()
    {
        targets.Clear();
        targets.Add(waypoints[Random.Range(0, waypoints.Count)]);
        return targets[0];
    }

    public void IncreaseHeartbeat()
    {
        //control
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        CalculateFirstPath();
        timer = Random.Range(5, 10);
        agent.speed = imaginaryFriend.Speed;
        control = player.GetComponent<ControlAndMovement>();
        hasSpoken = false;
    }

    private void FixedUpdate()
    {
        if (this.CompareTag("Shadow"))
        {
            imaginaryFriend.VisionRange = control.IncreasingHeartBeatDistance();
        } 
    }
        
}
