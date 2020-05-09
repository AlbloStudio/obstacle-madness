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

        private PlayerController playerController = null;
        private float timeSinceLastBullet = 0f;

        private void Start()
        {
            this.playerController = this.GetComponent<PlayerController>();
        }

        private void Update()
        {
            this.HandleShooting();
        }

        private void HandleShooting()
        {
            if (this.timeSinceLastBullet > 0)
            {
                this.timeSinceLastBullet -= Time.deltaTime;
            }
            else
            {
                if (this.playerController.IsShooting)
                {
                    this.ShootBullet();
                    this.timeSinceLastBullet = this.rate;
                }
            }
        }

        private void ShootBullet()
        {
            Bullet bulletInstance = Instantiate(this.bullet, this.transform.position, Quaternion.identity);
            bulletInstance.Shoot(this.playerController.ShootingDirection, 0.65f);
        }
    }
}
