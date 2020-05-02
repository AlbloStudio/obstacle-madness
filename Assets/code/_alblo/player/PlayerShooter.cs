//-----------------------------------------------------------------------
// <copyright file="PlayerShooter.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using UnityEngine;

namespace Alblo.Actors.Player
{
    public class PlayerShooter : MonoBehaviour
    {
        [Tooltip("The bullet prefab")]
        [SerializeField]
        private Bullet bullet = null;

        [Tooltip("the bullet frequency, one bullet every rate seconds")]
        [SerializeField]
        private float rate = 0.3f;

        private PlayerAnimation playerAnimation = null;

        private float timeSinceLastBullet = 0f;
        private bool isShooting = false;

        private void Start()
        {
            this.playerAnimation = this.GetComponent<PlayerAnimation>();
        }

        private void Update()
        {
            this.HandleShooting();
        }

        private void HandleShooting()
        {
            this.isShooting = this.GetShootVector() != Vector2.zero;

            if (this.isShooting)
            {
                this.playerAnimation.ChangelayerFacing(this.GetShootVector());
            }

            if (this.timeSinceLastBullet > 0)
            {
                this.timeSinceLastBullet -= Time.deltaTime;
            }
            else
            {
                if (this.isShooting)
                {
                    this.ShootBullet();
                    this.timeSinceLastBullet = this.rate;
                }
            }
        }

        private void ShootBullet()
        {
            Vector2 shootVector = this.GetShootVector();
            var playerOffset = Vector2.Scale(new Vector2(0.6f, 0.7f), shootVector);

            VectorUtils.Axis axis = shootVector.x != 0 ? VectorUtils.Axis.x : VectorUtils.Axis.y;
            float offsetComponent = axis == VectorUtils.Axis.x ? playerOffset.x : playerOffset.y;

            Bullet bulletInstance = Instantiate(this.bullet, this.transform.position, Quaternion.identity);
            bulletInstance.SetBulletTransform(axis, offsetComponent);
        }

        private Vector2 GetShootVector()
        {
            float horizontalShoot = Input.GetAxisRaw("shootHorizontal");
            float verticalShoot = Input.GetAxisRaw("shootVertical");

            return new Vector2(horizontalShoot, verticalShoot);
        }
    }
}
