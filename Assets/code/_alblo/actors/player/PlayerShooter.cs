//-----------------------------------------------------------------------
// <copyright file="PlayerShooter.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
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
        private Timer shooterTimer;

        private void Start()
        {
            this.playerController = this.GetComponent<PlayerController>();
            this.shooterTimer = Timer.Create(this.rate, this.ShootBullet, true);
        }

        private void Update()
        {
            this.shooterTimer.Mode = this.playerController.IsShooting ? TimerModes.Running : TimerModes.Ready;
            this.shooterTimer.Tick(Time.deltaTime);
        }

        private void ShootBullet()
        {
            Bullet bulletInstance = Instantiate(this.bullet, this.transform.position, Quaternion.identity);
            bulletInstance.Shoot(this.playerController.ShootingDirection, 0.65f);
        }
    }
}
