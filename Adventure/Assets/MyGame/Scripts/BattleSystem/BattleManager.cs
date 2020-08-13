using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    int player;
    int enemy;

    BattleState m_currentState;

    public string printHere()
    {
        return "Here";
    }

    public void SetUpBattle()
    {


        SetState(new BeginState(this));
    }

    public void SetState(BattleState state)
    {
        m_currentState = state;
        StartCoroutine(state.Start());
    }

    public void PerformAttack()
    {
        StartCoroutine(m_currentState.Attack());
    }
}
