using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/End Search")]
public class FinishedSearching : Condition
{
    [SerializeField]
    private bool searchEnded;
    public override bool Validate(FSM entity)
    {
        if(Vector3.Distance(entity.GetAgent().player.transform.position, entity.GetAgent().transform.position) > entity.GetAgent().imaginaryFriend.VisionRange || entity.GetAgent().player.GetComponent<ControlAndMovement>().GetHeartBeat() <= 120 || entity.GetAgent().player.GetComponent<ControlAndMovement>().CollidedWithLight())
        {
            if(entity.GetAgent().imaginaryFriend.InitialSearchTimer <= 0)
            {
                return searchEnded;
            }
            else
            {
                return !searchEnded;
            }
        }
        
        return searchEnded;
        
    }
}
