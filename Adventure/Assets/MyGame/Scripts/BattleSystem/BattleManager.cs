using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public CharacterThinker player;
    public CharacterThinker enemy;
    public CharacterData playerData;
    public CharacterData enemyData;

    BattleState m_currentState;

    public string printHere()
    {
        return "Here";
    }

    public void SetUpBattle(CharacterThinker player, CharacterThinker enemy)
    {
        this.player = player;
        this.enemy = enemy;
        player.TryGetComponent(out playerData);
        enemy.TryGetComponent(out enemyData);

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
