﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Weapon[] weapons;

    void Awake()
    {
        // Retrieve the weapon only once
        weapons = GetComponentsInChildren<Weapon>();
    }

    void Update()
    {
        {
            foreach (Weapon weapon in weapons)
            {
                // Auto-fire
                if (weapon != null && weapon.CanAttack())
                {
                    weapon.Attack(true);
                    soundEffects.Instance.MakeEnemyShotSound();
                }
            }
        }
    }
}
