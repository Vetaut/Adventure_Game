using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{
    Animator m_animator;
    [SerializeField] protected float m_maxHealth;
    [SerializeField] protected float m_currentHealth;
    [SerializeField] protected GameObject m_blood;
    [SerializeField] protected GameObject m_deathCloud;

    private bool m_isStaggered = false;

    private void Awake()
    {
        m_animator = GetComponentInChildren<Animator>();
    }

    public virtual void TakeDamage(float damageAmount)
    {
        m_isStaggered = true;
        m_currentHealth -= damageAmount;
        StartCoroutine(TakeDamageAnim());

        if(m_currentHealth < 0.1f)
        {
            Die();
        }
    }

    IEnumerator TakeDamageAnim()
    {
        m_blood.SetActive(true);
        m_animator.SetTrigger("TookDamage");
        yield return new WaitForSeconds(0.8f);
        m_isStaggered = false;
        m_blood.SetActive(false);
    }

    public float GetCurrentHealth()
    {
        return m_currentHealth;
    }

    public bool IsAlive()
    {
        return (m_currentHealth > 0);
    }

    public bool IsAbleToAttack()
    {
        return (m_currentHealth > 0) && !m_isStaggered;
    }

    void Die()
    {
        m_animator.SetBool("IsDead", true);
        m_animator.SetTrigger("Die");
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(3f);
        //Destroy(gameObject);
        m_deathCloud.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        m_animator.SetBool("IsDead", false);
        gameObject.SetActive(false);
    }
}
