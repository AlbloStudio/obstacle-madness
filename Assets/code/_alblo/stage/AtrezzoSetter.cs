//-----------------------------------------------------------------------
// <copyright file="AtrezzoSetter.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AtrezzoSetter : MonoBehaviour
{
    [Tooltip("Decor models to pick from")]
    [SerializeField]
    private SpriteRenderer[] decorModels;

    [Tooltip("Amount of decor to set on stage")]
    [SerializeField]
    private float unitsToSet = 10;

    private void Awake()
    {
        BoxCollider2D area = this.GetComponent<BoxCollider2D>();

        for (int i = 0; i < this.unitsToSet; i++)
        {
            int modelIndex = Random.Range(0, this.decorModels.Length);
            SpriteRenderer decorModelToUse = this.decorModels[modelIndex];

            Vector2 location = Geometry.GetRandomPointInArea(area);

            _ = Instantiate(decorModelToUse, location, Quaternion.identity, this.transform);
        }
    }
}
