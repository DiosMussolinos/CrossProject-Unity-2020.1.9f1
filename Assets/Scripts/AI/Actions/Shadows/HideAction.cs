using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Hide")]
public class HideAction : Action
{
    public override void Act(FSM entity)
    {
       
            entity.GetAgent().SetDestinationTo(entity.GetAgent().waypointInCorner.position);
            entity.GetAgent().UpdateSpeed(15f);
            if(Vector3.Distance(entity.GetAgent().transform.position, entity.GetAgent().waypointInCorner.position) <= 3f)
            {
                entity.GetAgent().imaginaryFriend.InitialHidingTimer -= Time.deltaTime;
                //Debug.Log(entity.GetAgent().imaginaryFriend.InitialHidingTimer);
            }
        
       
            //create entry action to calc closest corner and wp to it and set destinationTo
            //in this action nothing is needed
            // OR can use if path pending condition here to only calc once...
            
        
        
    }
}
