using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : CharacterData
{
    [SerializeField] protected Text m_healthText;
    public HealthBar m_healthBar;

    private void Start()
    {
        SetMaxHealth();
    }

    public void SetMaxHealth()
    {
        m_healthBar.SetMaxHealth(m_maxHealth);
        m_healthText.text = m_currentHealth + " / " + m_maxHealth;
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        m_healthBar.SetHealth(m_currentHealth);
        m_healthText.text = m_currentHealth + " / " + m_maxHealth;
    }
}
