//-----------------------------------------------------------------------
// <copyright file="EnemyLife.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
using UnityEngine;

namespace Alblo.Actors.Enemy
{
    public class EnemyLife : MonoBehaviour
    {
        [Tooltip("hits before dying")]
        [SerializeField]
        private int hits = 3;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(TagsAndLayers.Projectile))
            {
                this.hits--;
                if (this.hits <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
