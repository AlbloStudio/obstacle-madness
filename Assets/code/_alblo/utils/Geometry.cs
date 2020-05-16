//-----------------------------------------------------------------------
// <copyright file="Geometry.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using UnityEngine;

namespace Alblo.Utils
{
    public static class Geometry
    {
        public static Vector2 GetRandomPointInArea(BoxCollider2D area)
        {
            Vector2 center = area.bounds.center;
            Vector2 size = area.bounds.size;

            return center + new Vector2((Random.value - 0.5f) * size.x, (Random.value - 0.5f) * size.y);
        }
    }
}
