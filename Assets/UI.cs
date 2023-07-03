using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _rangeWeaponText;
    [SerializeField] private Text _meleeWeaponText;

    [SerializeField] private Player _player;
    [SerializeField] private RangeWeapon _rangeWeapon;
    [SerializeField] private MeleeWeapon _meleeWeapon;
}
