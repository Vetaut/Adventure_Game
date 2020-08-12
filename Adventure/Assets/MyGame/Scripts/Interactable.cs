using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected float m_distToGrab = 2.0f;
    public float _m_distToGrab { get => m_distToGrab; }

    protected bool isFocus = false;
    protected Transform character;

    protected virtual void Update()
    {
        if(isFocus)
        {
            if(IsAbleToGrab(character.position))
            {
                Interact();
            }
        }
    }

    public void IsFocused(Transform character)
    {
        this.character = character;
        isFocus = true;
    }

    protected void DeFocused()
    {
        character = null;
        isFocus = false;
    }

    public virtual void Interact()
    {
        Debug.Log(name + " was touched!");
        DeFocused();
    }

    public virtual bool IsAbleToGrab(Vector3 position)
    {
        return Vector3.Distance(position, transform.position) <= m_distToGrab;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, m_distToGrab);
    }
}
