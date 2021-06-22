using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Search")]
public class SearchAction : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().SetDestinationTo(entity.GetAgent().imaginaryFriend.LastPlayerPosition);
        entity.GetAgent().transform.LookAt(entity.GetAgent().player.transform.position);
        entity.GetAgent().imaginaryFriend.InitialSearchTimer -= Time.deltaTime;

    }
}
