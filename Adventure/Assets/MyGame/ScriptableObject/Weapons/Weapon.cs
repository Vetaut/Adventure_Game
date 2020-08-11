using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] protected string m_weaponName;
    [SerializeField] protected float m_weaponDamage;
    [SerializeField] protected float m_weaponRange;
    [SerializeField] protected MeshRenderer meshRenderer;
    [SerializeField] protected MeshFilter meshFilter;
    [SerializeField] protected Vector3 spawnPosition;
    
    public float GetDamage()
    {
        return m_weaponDamage;
    }

    public float GetRange()
    {
        return m_weaponRange;
    }
}
