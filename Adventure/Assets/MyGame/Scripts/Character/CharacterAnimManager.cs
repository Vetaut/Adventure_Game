using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimManager : MonoBehaviour
{
    private NavMeshAgent m_agent;
    private Animator m_animator;

    private bool isRunning = false;

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        RunningAnimationController();
    }

    private void RunningAnimationController()
    {
        if (m_agent.velocity.magnitude > 0)
        {
            isRunning = true;
            m_animator.SetBool("Running", isRunning);
        }
        else if (isRunning)
        {
            isRunning = false;
            m_animator.SetBool("Running", isRunning);
        }
    }
}
