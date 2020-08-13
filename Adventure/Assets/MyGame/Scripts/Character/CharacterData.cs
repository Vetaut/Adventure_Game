using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{
    Animator m_animator;
    [SerializeField] protected GameObject m_blood;
    [SerializeField] protected GameObject m_deathCloud;

    public List<Item> inventory = new List<Item>(10);
    [SerializeField] protected float m_maxHealth = 100;
    [SerializeField] protected float m_currentHealth;
    public Weapon equippedWeapon;

    public void AddItemToInventory(Item item)
    {
        inventory.Add(item);
    }

    [SerializeField] protected Text m_healthText;
    public HealthBar m_healthBar;
    [SerializeField] private float Damage = 10.0f;

    private void Awake()
    {
        m_animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        m_currentHealth = m_maxHealth;
        m_healthBar = GetComponentInChildren<HealthBar>();
        m_healthText = GetComponentInChildren<Text>();
        SetMaxHealth();
    }

    public void SetMaxHealth()
    {
        m_healthBar.SetMaxHealth(m_maxHealth);
        m_healthText.text = m_currentHealth + " / " + m_maxHealth;
    }

    public void UpdateHealthUI()
    {
        m_healthBar.SetHealth(m_currentHealth);
        m_healthText.text = m_currentHealth + " / " + m_maxHealth;
    }

    public bool TakeDamage(float damageAmount)
    {
        m_currentHealth -= damageAmount;
        UpdateHealthUI();
        StartCoroutine(TakeDamageAnim());
        return m_currentHealth <= 0;
    }

    IEnumerator TakeDamageAnim()
    {
        m_blood.SetActive(true);
        m_animator.SetTrigger("TookDamage");
        yield return new WaitForSeconds(0.8f);
        m_blood.SetActive(false);
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

    public float Attack()
    {
        return Damage + equippedWeapon.GetDamage();
    }

    /*
    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        m_healthBar.SetHealth(m_currentHealth);
        m_healthText.text = m_currentHealth + " / " + m_maxHealth;
    }

    /*
    Animator m_animator;

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
    */
}
