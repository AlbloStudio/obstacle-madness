//-----------------------------------------------------------------------
// <copyright file="PlayerAnimation.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
using UnityEngine;

namespace Alblo.Actors.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [Tooltip("speed the player has when moving")]
        [SerializeField]
        private float speed = 5f;

        private Animator animator;
        private Rigidbody2D body;
        private IActorController actorController = null;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            this.animator = this.GetComponent<Animator>();
            this.body = this.GetComponent<Rigidbody2D>();
            this.spriteRenderer = this.GetComponent<SpriteRenderer>();
            this.actorController = this.GetComponent<IActorController>();
        }

        private void FixedUpdate()
        {
            this.MovePlayer();
            this.ChangeFacingDirection();
        }

        private void MovePlayer()
        {
            Vector2 movement = this.actorController.MovementDirection * Time.fixedDeltaTime * this.speed;
            Vector2 newPosition = (Vector2)this.transform.position + movement;
            this.body.MovePosition(newPosition);

            this.animator.speed = this.actorController.MovementDirection.magnitude;
        }

        private void ChangeFacingDirection()
        {
            this.animator.SetInteger("direction", (int)this.actorController.LookingAt.Facing);
            this.spriteRenderer.flipX = this.actorController.LookingAt.Facing == Facings.Left;
        }
    }
}
