//-----------------------------------------------------------------------
// <copyright file="PlayerLife.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Alblo.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alblo.Actors.Player
{
    public class PlayerLife : MonoBehaviour
    {
        private readonly Dictionary<GameObject, float> enemiesHitting = new Dictionary<GameObject, float>();

        [Tooltip("hits before dying")]
        [SerializeField]
        private int hits = 3;

        [Tooltip("Time while enemies are hitting you to lose 1 life")]
        [SerializeField]
        private float hitFrequency = 3;

        private void Update()
        {
            this.HandleEnemiesHitting();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(TagsAndLayers.Enemy))
            {
                if (!this.enemiesHitting.ContainsKey(collision.gameObject))
                {
                    this.enemiesHitting.Add(collision.gameObject, this.hitFrequency);
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(TagsAndLayers.Enemy))
            {
                if (this.enemiesHitting.ContainsKey(collision.gameObject))
                {
                    _ = this.enemiesHitting.Remove(collision.gameObject);
                }
            }
        }

        private void HandleEnemiesHitting()
        {
            var enemiesHittingNewValues = new Dictionary<GameObject, float>();

            foreach (KeyValuePair<GameObject, float> enemyHitting in this.enemiesHitting)
            {
                float newTime = enemyHitting.Value + Time.deltaTime;

                if (newTime >= this.hitFrequency)
                {
                    newTime = 0;

                    this.hits--;
                    if (this.hits <= 0)
                    {
                        SceneManager.LoadScene(0);
                    }
                }

                enemiesHittingNewValues.Add(enemyHitting.Key, newTime);
            }

            foreach (KeyValuePair<GameObject, float> enemyHittingNewValue in enemiesHittingNewValues)
            {
                this.enemiesHitting[enemyHittingNewValue.Key] = enemyHittingNewValue.Value;
            }
        }
    }
}
