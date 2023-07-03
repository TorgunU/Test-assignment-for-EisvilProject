using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : RangeWeapon
{
    private void Start()
    {
        Name = "Лазер";
        Damage = 1000;
        AttackFrequencyInSeconds = 0.2f;
    }

    public override void Shoot()
    {
        CreateBullet();
    }

    protected void CreateBullet()
    {
        GameObject bulletObject = Instantiate(BulletPrefab, AttackPoint.position, AttackPoint.rotation);

        if (bulletObject.TryGetComponent(out Bullet bullet))
        {
            bullet.IncreaseWeaponDamage(Damage);
        }
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(AttackFrequencyInSeconds);

        IsAttackCooldowned = false;
    }
}