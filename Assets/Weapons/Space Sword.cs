using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSword : MeleeWeapon
{
    private void Start()
    {
        Name = "Космический меч";
        Damage = 10;
        AttackFrequencyInSeconds = 2f;
        AttackRange = 0.8f;
        

        IngoredLayer = gameObject.transform.parent.gameObject.layer;
    }

    protected override void Hit()
    {
        Collider2D[] hitedColliders = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange);

        foreach (var collider in hitedColliders)
        {
            if(collider.gameObject.layer != IngoredLayer)
            {
                if (collider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(Damage);
                }
            }
        }
    }

    public override IEnumerator CalculatingAttackDelay()
    {
        yield return new WaitForSeconds(AttackFrequencyInSeconds);

        IsAttackCooldowned = false;
    }

    private void OnDrawGizmos()
    {
        if (AttackPoint == null)
            return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}