using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : CharacterAttack
{
    private float lastAttackTime = 0;

    public void enemyAttack()
    {
        if(Time.time - lastAttackTime > 1.0f)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

}
