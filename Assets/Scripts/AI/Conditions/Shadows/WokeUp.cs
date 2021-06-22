using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Woke Up")]
public class WokeUp : Condition
{
    public override bool Validate(FSM entity)
    {
        //TimerRodando
        entity.GetAgent().pandaSleep -= Time.deltaTime;

        return entity.GetAgent().pandaSleep <= 0;
    }
}
