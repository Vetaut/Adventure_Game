using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Brains/Player Controlled")]
public class PlayerControlledBrain : CharacterBrain
{
    CharacterMovement movement;
    [SerializeField] LayerMask enemyLayer;
    private delegate IEnumerator action();

    public override void Initialize(CharacterThinker character)
    {
        movement = character.GetComponent<CharacterMovement>();
    }

    public override void PassiveThink(CharacterThinker character)
    {
        movement = character.GetComponent<CharacterMovement>();
        LeftMouseDown(character);
    }

    private void LeftMouseDown(CharacterThinker character)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {

                Interactable interactable;

                if (hit.collider.TryGetComponent(out interactable))
                {
                    interactable.IsFocused(character.transform);

                    if (interactable.IsAbleToGrab(character.transform.position))
                    {
                        interactable.Interact();
                    }
                    else
                    {
                        // Vector3 offset = character.transform.position - interactable.transform.position;
                        // offset.y = 0;
                        // Vector3 destination = interactable.transform.position + (offset.normalized * interactable._m_distToGrab);

                        movement.Move(interactable.transform.position, interactable._m_distToGrab * 0.8f);
                    }
                }
                else
                {
                    movement.Move(hit.point);
                }
            }
        }
    }


    public override bool BattleThink(CharacterThinker character)
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, enemyLayer))
            {
                Debug.Log("I attempted an attack");
                GameManager.instance.battleManager.PerformAttack();
                return false;
            }
        }

        return true;
    }
}
