using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangeCombatControl : PlayerControl
{
    protected RangeWeapon RangeWeapon;

    public override void Awake()
    {
        base.Awake();

        RangeWeapon = GetComponentInChildren<RangeWeapon>();

        PlayerInput.Player.Range.performed += shootContext => OnShoot();
    }

    public void OnShoot()
    {
        RangeWeapon.Attack();
    }
}
