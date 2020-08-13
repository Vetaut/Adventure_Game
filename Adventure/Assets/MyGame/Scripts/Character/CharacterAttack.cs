using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] protected float m_attackPower = 10.0f;
    [SerializeField] protected float m_attackRange = 0.5f;
    public Weapon weapon;

    public void Attack()
    {

    }
    /*
    CharacterData character;
    
    Animator m_animator;

    

    [SerializeField] protected Transform m_attackPoint;
    
    [SerializeField] protected LayerMask m_enemiesLayers;

    protected bool m_isAttacking = false;

    private void Awake()
    {
        character = GetComponent<CharacterData>();
        m_animator = GetComponentInChildren<Animator>();
    }

    protected void OnMouseDown()
    {
        AttackHelper();
    }

    public void Attack()
    {
        AttackHelper();
    }

    protected virtual void AttackHelper()
    {
        if (!m_isAttacking && character.IsAbleToAttack()) {

            Collider[] enemiesHit = Physics.OverlapSphere(m_attackPoint.position, weapon.GetRange(), m_enemiesLayers);

            foreach (Collider enemy in enemiesHit)
            {
                if (enemy.GetComponent<CharacterData>())
                {
                    enemy.GetComponent<CharacterData>().TakeDamage(weapon.GetDamage());
                }
            }

            StartCoroutine(AttackAnim());
        }
    }

    protected IEnumerator AttackAnim()
    {
        m_isAttacking = true;
        m_animator.SetTrigger("IsAttacking");
        yield return new WaitForSeconds(2f);
        m_isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_attackPoint.position, weapon.GetRange());
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }

    public Transform GetAttackLocation()
    {
        return m_attackPoint;
    }
    */
}
