//-----------------------------------------------------------------------
// <copyright file="EnemyController.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
using UnityEngine;

namespace Alblo.Actors.Player
{
    public class EnemyController : MonoBehaviour, IActorController
    {
        [Tooltip("The target that the enemy will try to catch")]
        [SerializeField]
        private Transform target = null;

        [Tooltip("How many times you have to shoot the enemy")]
        [SerializeField]
        private int lives = 3;

        public bool IsShooting => false;

        public Vector2 MovementDirection { get; private set; } = Vector2.zero;
        public Direction LookingAt { get; private set; } = Direction.None;
        public Direction ShootingDirection => Direction.None;

        private void FixedUpdate()
        {
            this.MovementDirection = (this.target.position - this.transform.position).normalized;

            Vector2 facingDirection = this.MovementDirection;

            this.LookingAt = Direction.FromVector2(facingDirection);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Utils.TagsAndLayers.Projectile))
            {
                this.lives -= 1;
                if (this.lives <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
