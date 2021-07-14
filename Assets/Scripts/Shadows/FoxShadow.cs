using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxShadow : Attributes
{
    public override string Name { get; set; } = "Rabbit";
    public override ShadowsID ID { get; set; } = ShadowsID.Rabbit;
    public override float Speed { get; set; } = 4f;
    public override float ChasingSpeed { get; set; } = 7f;
    public override float ChaseRange { get; set; } = 5f;
    public override float VisionRange { get; set; } = 3f;
    public override float AttackRange { get; set; } = 3f;
    public override float SearchTimer { get; set; } = 8f;
    public override float ChaseTimer { get; set; } = 25f;
    public override float InitialChaseTimer { get; set; } = 25f;
    public override float InitialSearchTimer { get; set; } = 10f;
    public override float Damage { get; set; } = 18f;
    public override Vector3 LastPlayerPosition { get; set; }
    public override float HidingTimer { get; set; } = 20f;
    public override float InitialHidingTimer { get; set; } = 20f;
}
