using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    private float _maxHealth;
    private float _minHealth;
    private float _personalDamage;
    private HealthBar _healthBar;
    private MeleeWeapon _meleeWeapon;

    private void Awake()
    {
        _healthBar = GetComponentInChildren<HealthBar>();
        _meleeWeapon = GetComponentInChildren<MeleeWeapon>();
    }

    private void Start()
    {
        _maxHealth = 250;
        _minHealth = 0;
        _currentHealth = _maxHealth;

        _personalDamage = 25;
        _meleeWeapon.SetDamageBuff(_personalDamage);
    }
}

public partial class Player : IDamageable
{
    public void Die()
    {
        if(_currentHealth <= _minHealth)
        {
            //play effect/animation
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);

        if (_currentHealth <= _minHealth)
        {
            Die();
        }
    }
}