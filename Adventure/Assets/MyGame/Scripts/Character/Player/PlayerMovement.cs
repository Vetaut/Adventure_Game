using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Begin Battle!");
        CharacterThinker enemyThinker;
        if(other.gameObject.TryGetComponent(out enemyThinker))
        {
            other.enabled = false;
            GameManager.instance.BeginBattle(gameObject.GetComponent<CharacterThinker>(), enemyThinker);
        }
        
    }
}
