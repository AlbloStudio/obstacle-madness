//-----------------------------------------------------------------------
// <copyright file="Bullet.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
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
        private Direction shootingDirection = Direction.None;

        public void Shoot(Direction direction, float directionOffset)
        {
            this.shootingDirection = direction;

            if (this.shootingDirection.IsVertical)
            {
                this.spriteTransform.Rotate(new Vector3(0, 0, 90));
            }

            this.transform.Translate(this.shootingDirection.GetAsVector2(directionOffset));
        }

        private void Start()
        {
            this.rigidBody = this.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float speedFactor = Time.fixedDeltaTime * this.speed;
            Vector2 movement = this.shootingDirection.GetAsVector2(speedFactor);
            Vector2 newPosition = (Vector2)this.transform.position + movement;
            this.rigidBody.MovePosition(newPosition);
        }

        private void OnCollisionEnter2D(Collision2D _)
        {
            Destroy(this.gameObject);
        }
    }
}
