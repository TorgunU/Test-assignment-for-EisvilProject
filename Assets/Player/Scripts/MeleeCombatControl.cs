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
        //PlayerInput.Player.Melee.performed += OnHit;
    }

    //public void OnHit(InputAction.CallbackContext callbackContext)
    //{
    //    MeleeWeapon.Attack();
    //}

    public void OnHit()
    {
        MeleeWeapon.Attack();
    }
}
