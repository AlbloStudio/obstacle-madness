//-----------------------------------------------------------------------
// <copyright file="EnemySpawner.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
using UnityEngine;

namespace Alblo.Actors.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [Tooltip("an enemy will spawn every frequency seconds")]
        [SerializeField]
        private float frequency = 2f;

        [Tooltip("The entity to spawn")]
        [SerializeField]
        private EnemyController enemy = null;

        [Tooltip("The target for the entity")]
        [SerializeField]
        private Transform target = null;

        [Tooltip("The terrain area of effect")]
        [SerializeField]
        private Transform araOfEffect = null;

        private BoxCollider2D area = null;
        private Timer spawnTimer;

        private void Start()
        {
            this.area = this.araOfEffect.GetComponent<BoxCollider2D>();

            this.spawnTimer = Timer.Create(this.frequency, this.Spawn);
            this.Spawn();
        }

        private void Update()
        {
            this.spawnTimer.Tick(Time.deltaTime);
        }

        private void Spawn()
        {
            EnemyController enemyInstance = Instantiate(this.enemy, Geometry.GetRandomPointInArea(this.area), Quaternion.identity);
            enemyInstance.SetTarget(this.target);
        }
    }
}
