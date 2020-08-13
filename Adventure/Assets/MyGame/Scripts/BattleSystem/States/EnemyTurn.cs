using UnityEngine;
using System.Collections.Generic;
using System.Collections;

class EnemyTurn : BattleState
{
    public EnemyTurn(BattleManager battleManager) : base(battleManager)
    {
    }


    public override IEnumerator Start()
    {
        _battleManager.enemy.brain.BattleThink(_battleManager.enemy);

        yield break;
    }

    
}