using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Passed 3rd Waypoint")]
public class Passed3Waypoints : Condition
{
    public override bool Validate(FSM entity)
    {
        return entity.GetAgent().pandaCountDown >= 3 && entity.GetAgent().imaginaryFriend.ID == 2;
        
    }
}
