using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Assets.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] protected Transform Target;
        [SerializeField] protected float Speed;

        protected Rigidbody2D Rigidbody2D;


        private void Start()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Target = FindObjectOfType<Player>().transform;

            Speed = Random.Range(5, 10);
        }

        private void FixedUpdate()
        {
            Move();
        }

        protected Vector2 GetDirectionToPlayer()
        {
            Vector2 direction = Target.position - transform.position;
            direction.Normalize();

            return direction;
        }

        protected void RotateToPlayer(Vector2 direction)
        {
            float faceAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(faceAngle - 90f, Vector3.forward);
        }

        protected void Move()
        {
            if (Target != null)
            {
                Vector2 direction = GetDirectionToPlayer();

                RotateToPlayer(direction);

                Rigidbody2D.velocity = direction * Speed;

                //transform.LookAt(direction);
            }
        }
    }
}