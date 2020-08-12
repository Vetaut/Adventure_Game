using System;
using System.Collections;
using UnityEngine;

public class BeginState : BattleState
{
    public BeginState(BattleManager battleManager) : base(battleManager)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Start Methods");

        yield return new WaitForSeconds(2f);
    }

}
