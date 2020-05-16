//-----------------------------------------------------------------------
// <copyright file="PlayerLife.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alblo.Actors.Player
{
    public class PlayerLife : MonoBehaviour
    {
        private readonly Dictionary<GameObject, Timer> enemiesHitting = new Dictionary<GameObject, Timer>();

        [Tooltip("hits before dying")]
        [SerializeField]
        private int hits = 3;

        [Tooltip("Time while enemies are hitting you to lose 1 life")]
        [SerializeField]
        private float hitFrequency = 1;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(TagsAndLayers.Enemy))
            {
                if (!this.enemiesHitting.ContainsKey(collision.gameObject))
                {
                    this.Hit();
                    this.AddEnemy(collision.gameObject);
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(TagsAndLayers.Enemy))
            {
                if (this.enemiesHitting.ContainsKey(collision.gameObject))
                {
                    this.RemoveEnemy(collision.gameObject);
                }
            }
        }

        private void Update()
        {
            foreach (KeyValuePair<GameObject, Timer> enemyHitting in this.enemiesHitting)
            {
                enemyHitting.Value.Tick(Time.deltaTime);
            }
        }

        private void Hit()
        {
            this.hits--;
            if (this.hits <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void AddEnemy(GameObject enemy)
        {
            var timer = Timer.Create(this.hitFrequency, this.Hit);
            this.enemiesHitting.Add(enemy, timer);
        }

        private void RemoveEnemy(GameObject enemy)
        {
            _ = this.enemiesHitting.Remove(enemy);
        }
    }
}
