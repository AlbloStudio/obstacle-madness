//-----------------------------------------------------------------------
// <copyright file="EnemyController.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
using UnityEngine;

namespace Alblo.Actors.Enemy
{
    public class EnemyController : MonoBehaviour, IActorController
    {
        [Tooltip("The target that the enemy will try to catch")]
        [SerializeField]
        private Transform target = null;

        public bool IsShooting => false;

        public Vector2 MovementDirection { get; private set; } = Vector2.zero;
        public Direction LookingAt { get; private set; } = Direction.None;
        public Direction ShootingDirection => Direction.None;

        public void SetTarget(Transform newTarget)
        {
            this.target = newTarget;
        }

        private void FixedUpdate()
        {
            this.MovementDirection = (this.target.position - this.transform.position).normalized;

            Vector2 facingDirection = this.MovementDirection;

            this.LookingAt = Direction.FromVector2(facingDirection);
        }
    }
}
