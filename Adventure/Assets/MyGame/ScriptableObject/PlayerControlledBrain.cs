using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Brains/Player Controlled")]
public class PlayerControlledBrain : CharacterBrain
{
    public override void Think(CharacterThinker character)
    {
        var movement = character.GetComponent<CharacterMovement>();

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                movement.m_agent.destination = hit.point;
            }
        }
    }
}
