using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Generate Marks")]
public class GenerateMarks : Action
{
    public override void Act(FSM entity)
    {
        if(entity.GetAgent().imaginaryFriend.ID == ShadowsID.Lion)
        {
            if (!entity.GetAgent().marks.Any())
            {
                entity.GetAgent().marks.Add(entity.GetAgent().GetRandomWaypoints());
                entity.GetAgent().marks.Add(entity.GetAgent().GetRandomWaypoints());
                foreach (Waypoints mark in entity.GetAgent().marks)
                {
                    entity.GetAgent().targets.Insert(0, mark);
                }
            }
            else if (entity.GetAgent().marks.Count == 1)
            {
                entity.GetAgent().marks.Add(entity.GetAgent().GetRandomWaypoints());
                foreach (Waypoints mark in entity.GetAgent().marks)
                {
                    entity.GetAgent().targets.Insert(0, mark);
                }
            }               
            entity.GetAgent().CalculateFirstPath();          
        }
        
    }
}
