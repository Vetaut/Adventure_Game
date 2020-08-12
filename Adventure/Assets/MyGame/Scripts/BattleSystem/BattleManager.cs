using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    CharacterData player;
    CharacterData enemy;

    BattleState m_currentState;

    public void SetState(BattleState state)
    {
        m_currentState = state;
        StartCoroutine(state.Start());
    }

    public void OnAttackButton()
    {
        StartCoroutine(m_currentState.Attack());
    }
}
