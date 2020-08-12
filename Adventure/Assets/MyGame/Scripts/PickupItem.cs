using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    Vector3 originalPos;
    private float lerpTimer = 0.0f;
    [SerializeField] int m_interpolationFrameCount = 10;
    private int m_elapsedFrames = 0;
    private bool isBeingPickedUp = false;

    private void Awake()
    {
        originalPos = transform.position;
    }

    protected override void Update()
    {
        if (isBeingPickedUp) {
            LerpToCharacter();
        }
        base.Update();
    }

    public override void Interact()
    {
        PickUp();
    }

    private void PickUp()
    {
        isBeingPickedUp = true;
    }

    private void LerpToCharacter()
    {
        float interpolationRatio = (float)m_elapsedFrames / m_interpolationFrameCount;
        m_elapsedFrames++;

        transform.position = Vector3.Lerp(originalPos, character.position, interpolationRatio);

        if(m_elapsedFrames > m_interpolationFrameCount)
        {
            isBeingPickedUp = false;

            CharacterData characterData;
            if(character.gameObject.TryGetComponent(out characterData))
            {
                Item item;
                if(TryGetComponent(out item))
                {
                    characterData.AddItemToInventory(item);
                }
                
            }

            DeFocused();
            Debug.Log("Player has " + gameObject.name);
            gameObject.SetActive(false);
        }
    }
}
