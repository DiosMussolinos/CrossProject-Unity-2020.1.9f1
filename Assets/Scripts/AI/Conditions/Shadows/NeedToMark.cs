using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Need to Mark")]
public class NeedToMark : Condition
{
    public override bool Validate(FSM entity)
    {       
        bool isClose = false;
        foreach (Waypoints wp in entity.GetAgent().marks)
        {
           isClose = Vector3.Distance(entity.GetAgent().transform.position, entity.GetAgent().targets[0].transform.position) <= 5f && entity.GetAgent().targets[0].transform.position == wp.transform.position;
            if (isClose)
                break;
        }
        return isClose;
    }
}
