using System.Collections;
using UnityEngine;

namespace Assets.Weapons
{
    public class LazerBullet : Bullet
    {
        public override void Awake()
        {
            base.Awake();
            SpeedShot = 15f;
            Damage = 5;
        }

        private void Start()
        {
            Fire();
        }

        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            IDamageable damageable;

            if (collision.collider.TryGetComponent(out damageable))
            {
                damageable.TakeDamage(Damage);
                Destroy(gameObject);
            }
            else if (collision.collider.tag == "Obstacles")
            {
                Destroy(gameObject);
            }
            else if (collision.collider.TryGetComponent(out LevelBorder levelBorder))
            {
                Destroy(gameObject);
            }
        }

        public override void IncreaseWeaponDamage(float weaponDamage)
        {
            Damage += weaponDamage;
        }

        protected override void Fire()
        {
            _rigidbody2D.AddForce(SpeedShot * transform.up, ForceMode2D.Impulse);
        }
    }
}