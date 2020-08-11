﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Animator m_animator;

    protected CharacterAttack characterAttack;
    protected CharacterData characterData;

    private void Awake()
    {
        m_animator = GetComponentInChildren<Animator>();
    }

    private void OnMouseDown()
    {
        characterAttack.Attack();
    }
}