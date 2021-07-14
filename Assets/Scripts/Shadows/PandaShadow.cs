using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaShadow : Attributes
{
    public override string Name { get; set; } = "Panda";

    public override ShadowsID ID { get; set; } = ShadowsID.Panda;

    public override float Speed { get; set; } = 5f;
    public override float ChasingSpeed { get; set; } = 3.5f;
    public override float ChaseRange { get; set; } = 7f;
    public override float VisionRange { get; set; } = 10f;
    public override float AttackRange { get; set; } = 6f;
    public override float SearchTimer { get; set; } = 12f;
    public override float ChaseTimer { get; set; } = 23f;
    public override float InitialChaseTimer { get; set; } = 25f;
    public override float InitialSearchTimer { get; set; } = 12f;
    public override float Damage { get; set; } = 30f;
    public override Vector3 LastPlayerPosition { get; set; }
}
