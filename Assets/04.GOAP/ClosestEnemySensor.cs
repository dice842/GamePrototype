using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestEnemySensor : LocalTargetSensorBase
{
    private GameObject player;
    public override void Created()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Update() 
    {
    }
    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        var closestTarget = player.transform;

        

        if (closestTarget == null) return null;
        return new TransformTarget(closestTarget);
    }
}
