//-----------------------------------------------------------------------
// <copyright file="Bullet.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using UnityEngine;

namespace Alblo.Actors
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private Transform spriteTransform = null;
        [SerializeField]
        private float speed = 10f;

        private Rigidbody2D rigidBody;
        private Vector2 shootingDirection = Vector2.zero;

        public void SetBulletTransform(VectorUtils.Axis axis, float directionOffset)
        {
            var shootingDirectionOffset = new Vector2(directionOffset, 0);

            if (axis == VectorUtils.Axis.y)
            {
                shootingDirectionOffset = new Vector2(0, directionOffset);
                this.spriteTransform.Rotate(new Vector3(0, 0, 90));
            }

            this.transform.Translate(shootingDirectionOffset);
            this.shootingDirection = shootingDirectionOffset.normalized;
        }

        private void Start()
        {
            this.rigidBody = this.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float factor = Time.fixedDeltaTime * this.speed;
            Vector2 movement = this.shootingDirection * factor;
            Vector2 newPosition = (Vector2)this.transform.position + movement;
            this.rigidBody.MovePosition(newPosition);
        }

        private void OnCollisionEnter2D(Collision2D _)
        {
            Destroy(this.gameObject);
        }
    }
}
