using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState : MonoBehaviour
{
    protected readonly BattleManager _battleManager;

    public BattleState(BattleManager battleManager)
    {
        _battleManager = battleManager;
    }

    public virtual string printMyName()
    {
        return "basic";
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Attack()
    {
        Debug.Log("attack basic");
        yield break;
    }

    public virtual IEnumerator Move()
    {
        yield break;
    }

    public virtual IEnumerator Pass()
    {
        yield break;
    }
}
