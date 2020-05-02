//-----------------------------------------------------------------------
// <copyright file="PlayerAnimation.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using UnityEngine;

namespace Alblo.Actors.Player
{
    public enum PlayerDirection
    {
        Front = 0,
        Back = 1,
        Left = 2,
        Right = 3,
    }

    public class PlayerAnimation : MonoBehaviour
    {
        [Tooltip("speed the player has when moving")]
        [SerializeField]
        private float speed = 5f;

        private Animator animator;
        private Rigidbody2D body;
        private SpriteRenderer spriteRenderer;
        private PlayerDirection playerDirection = PlayerDirection.Front;

        public void ChangelayerFacing(Vector2 lookingAt)
        {
            if (lookingAt.x != 0)
            {
                this.playerDirection = lookingAt.x < 0 ? PlayerDirection.Left : PlayerDirection.Right;
            }
            else if (lookingAt.y != 0)
            {
                this.playerDirection = lookingAt.y > 0 ? PlayerDirection.Back : PlayerDirection.Front;
            }

            this.animator.SetInteger("direction", (int)this.playerDirection);
            this.spriteRenderer.flipX = this.playerDirection == PlayerDirection.Left;
        }

        private void Start()
        {
            this.animator = this.GetComponent<Animator>();
            this.body = this.GetComponent<Rigidbody2D>();
            this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            this.MovePlayer();
        }

        private void MovePlayer()
        {
            var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            this.ChangelayerFacing(input);
            this.ChangePlayerPosition(input);

            this.animator.speed = input.magnitude;
        }

        private void ChangePlayerPosition(Vector2 input)
        {
            Vector2 movement = input * Time.fixedDeltaTime * this.speed;
            Vector2 newPosition = (Vector2)this.transform.position + movement;
            this.body.MovePosition(newPosition);
        }
    }
}
