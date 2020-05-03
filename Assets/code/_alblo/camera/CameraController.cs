//-----------------------------------------------------------------------
// <copyright file="CameraController.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using UnityEngine;

namespace Alblo.Camera
{
    public class CameraController : MonoBehaviour
    {
        private const float MaxSpeed = 0.2f;
        private const float Zoom = -10f;

        [SerializeField]
        private GameObject player = null;

        private Vector3 velocity = Vector3.zero;

        private void Start()
        {
            this.transform.position = this.GetPlayerWithDistance();
        }

        private void LateUpdate()
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, this.GetPlayerWithDistance(), ref this.velocity, MaxSpeed);
        }

        private Vector3 GetPlayerWithDistance()
        {
            return new Vector3(this.player.transform.position.x, this.player.transform.position.y, Zoom);
        }
    }
}
