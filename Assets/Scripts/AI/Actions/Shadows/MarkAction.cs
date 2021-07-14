using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Mark")]
public class MarkAction : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().imaginaryFriend.MarkingTimer -= Time.deltaTime;
        Debug.Log(entity.GetAgent().imaginaryFriend.MarkingTimer);
        if (entity.GetAgent().imaginaryFriend.MarkingTimer <= 0)
        {
            Instantiate(entity.GetAgent().markPrefab, entity.GetAgent().GetClosestWaypoint(entity.GetAgent().transform.position).transform.position, Quaternion.identity);
            Debug.Log("Mark Created at: " + entity.GetAgent().GetClosestWaypoint(entity.GetAgent().transform.position));
        }
        entity.GetAgent().targets.Remove(entity.GetAgent().GetClosestWaypoint(entity.GetAgent().transform.position));
    }
}
