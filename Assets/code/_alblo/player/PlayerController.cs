//-----------------------------------------------------------------------
// <copyright file="PlayerController.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
using UnityEngine;

namespace Alblo.Actors.Player
{
    public class PlayerController : MonoBehaviour, IActorController
    {
        public bool IsShooting => !this.ShootingDirection.IsNone;

        public Vector2 MovementDirection { get; private set; }
        public Direction LookingAt { get; private set; } = Direction.None;
        public Direction ShootingDirection { get; private set; } = Direction.None;

        private void FixedUpdate()
        {
            var shootInputDirection = new Vector2(Input.GetAxisRaw("shootHorizontal"), Input.GetAxisRaw("shootVertical"));
            this.MovementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector2 facingDirection = shootInputDirection != Vector2.zero ? shootInputDirection : this.MovementDirection;

            if (facingDirection != Vector2.zero)
            {
                this.LookingAt = Direction.FromVector2(facingDirection);
            }

            this.ShootingDirection = shootInputDirection != Vector2.zero ? Direction.FromVector2(shootInputDirection) : Direction.None;
        }
    }
}
