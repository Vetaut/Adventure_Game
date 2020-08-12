using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Weapon,
        Potion,
        Quest,
        Junk
    };

    public int value = 1;
    public int weight = 1;
    public ItemType type = ItemType.Weapon;
}
