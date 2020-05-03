//-----------------------------------------------------------------------
// <copyright file="PlayerController.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
using UnityEngine;

namespace Alblo.Actors.Player
{
    public class PlayerController : MonoBehaviour
    {
        public Vector2 MovementDirection { get; private set; }
        public Direction LookingAt { get; private set; }
        public Direction ShootingDirection { get; private set; }
        public bool IsShooting => !this.ShootingDirection.IsNone;

        private void FixedUpdate()
        {
            var shootInputDirection = new Vector2(Input.GetAxisRaw("shootHorizontal"), Input.GetAxisRaw("shootVertical"));
            this.MovementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector2 facingDirection = shootInputDirection != Vector2.zero ? shootInputDirection : this.MovementDirection;

            this.LookingAt = Direction.FromVector2(facingDirection);
            this.ShootingDirection = shootInputDirection != Vector2.zero ? Direction.FromVector2(shootInputDirection) : Direction.None;
        }
    }
}
