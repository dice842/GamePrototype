using CrashKonijn.Goap.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBrain : MonoBehaviour
{
    private AgentBehaviour agent;

    private void Awake()
    {
        this.agent = this.GetComponent<AgentBehaviour>();
    }

    private void Start()
    {
        this.agent.SetGoal<WanderGoal>(false);
    }
}
