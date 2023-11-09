using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderTargerSensor : LocalTargetSensorBase
{
    public override void Created()
    {
    }
    public override void Update()
    {
    }
    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        var random = this.GetRandomPosition(agent);
        return new PositionTarget(random);
    }
    private Vector3 GetRandomPosition(IMonoAgent agent)
    {
        var random = Random.insideUnitCircle * 5f;
        var Position = agent.transform.position + new Vector3(random.x, 0f, random.y);

        return Position;

    }
}
