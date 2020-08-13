using System.Collections;
using UnityEngine;

public class PlayerTurnState : BattleState
{
    bool hasPlayed = false;
    public PlayerTurnState(BattleManager battleManager) : base(battleManager)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Player Turn!");

        // While Thinking
        while(_battleManager.player.brain.BattleThink(_battleManager.player))
        {
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
    }

    public override IEnumerator Attack()
    {
        hasPlayed = true;
        Debug.Log("Player attacks for " + _battleManager.playerData.Attack());
        var isDead = _battleManager.enemyData.TakeDamage(_battleManager.playerData.Attack());
        yield return new WaitForSeconds(2.0f);

        if (isDead)
        {
            _battleManager.SetState(new Won(_battleManager));
        }
        else
        {
            _battleManager.SetState(new EnemyTurn(_battleManager));
        }
    }
}

