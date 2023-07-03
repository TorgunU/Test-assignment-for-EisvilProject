using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeCombatControl : PlayerControl
{
    protected MeleeWeapon MeleeWeapon;

    public override void Awake()
    {
        base.Awake();

        MeleeWeapon = GetComponentInChildren<MeleeWeapon>();

        PlayerInput.Player.Melee.performed += shootContext => OnHit();
    }

    public void OnHit()
    {
        MeleeWeapon.Attack();
    }
}
