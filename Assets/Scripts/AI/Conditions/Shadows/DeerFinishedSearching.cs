using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Deer Finished")]

public class DeerFinishedSearching : Condition
{
    private int randomNumb;

    public override bool Validate(FSM entity)
    {
        //TimerRodando
        entity.GetAgent().deerSearch -= Time.deltaTime;

        entity.GetAgent().transform.Rotate(0, entity.GetAgent().deerRotationSpeed * entity.GetAgent().sideRotation * Time.deltaTime, 0);

        return entity.GetAgent().deerSearch <= 0;
    }
}
