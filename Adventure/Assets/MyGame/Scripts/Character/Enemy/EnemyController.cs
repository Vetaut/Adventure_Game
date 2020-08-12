using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    /*
    [SerializeField] private float m_lookRadius = 5.0f;
    [SerializeField] private float m_turnSpeed = 5.0f;

    Animator m_animator;
    Transform m_target;
    NavMeshAgent m_agent;
    [SerializeField] EnemyAttack m_attackScript;
    [SerializeField] CharacterData characterData;

    private void Start()
    {
        m_animator = GetComponentInChildren<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
        m_target = PlayerManager.instance.player.transform;

        Vector3 attackDistance = m_attackScript.GetAttackLocation().position - transform.position;

        m_agent.stoppingDistance = attackDistance.magnitude + (m_attackScript.GetWeapon().GetRange() * 0.5f);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, m_target.position);

        if (distance < m_lookRadius && characterData.IsAlive())
        {
            m_agent.SetDestination(m_target.position);

            if (distance <= m_agent.stoppingDistance)
            {
                m_attackScript.enemyAttack();
                FaceTarget();
                UpdateAnimator(0);
            }
            else
            {
                UpdateAnimator(1);
            }
        }
        else if (characterData.IsAlive()) 
        {
            m_agent.SetDestination(transform.position);
            UpdateAnimator(0);
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (m_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * m_turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_lookRadius);
    }


    void UpdateAnimator(float data)
    {
        if (m_animator)
        {
            m_animator.SetFloat("Running", data);
        }
    }
    */
}
