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
        public Transform target = null;

        public bool IsShooting => false;

        public Vector2 MovementDirection { get; private set; }
        public Direction LookingAt { get; private set; }
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
                Destroy(this.gameObject);
            }
        }
    }
}
