using CrashKonijn.Goap.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoapSetBinder : MonoBehaviour
{
    public void Awake()
    {
        var runner = FindObjectOfType<GoapRunnerBehaviour>();
        var agent = GetComponent<AgentBehaviour>();
        agent.GoapSet = runner.GetGoapSet("GettingStartedSet");
    }
}
