//-----------------------------------------------------------------------
// <copyright file="Direction.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using UnityEngine;

namespace Alblo.Utils
{
    public enum Facings
    {
        Front = 0,
        Back = 1,
        Left = 2,
        Right = 3,
        None = 4,
    }

    public class Direction
    {
        public static Direction None => new Direction();

        public Facings Facing { get; private set; } = Facings.None;
        public bool IsHorizontal => this.Facing == Facings.Left || this.Facing == Facings.Right;
        public bool IsVertical => this.Facing == Facings.Back || this.Facing == Facings.Front;
        public bool IsNegative => this.Facing == Facings.Left || this.Facing == Facings.Front;
        public bool IsPositive => this.Facing == Facings.Right || this.Facing == Facings.Back;
        public int GetSign => this.IsNegative ? -1 : this.IsPositive ? 1 : 0;
        public bool IsNone => this.Facing == Facings.None;

        public static Direction FromVector2(Vector2 vector)
        {
            var direction = new Direction
            {
                Facing = Facings.None
            };

            Facings directionIfHorizontal = vector.x < 0 ? Facings.Left : Facings.Right;
            Facings directionIfVertical = vector.y > 0 ? Facings.Back : Facings.Front;

            bool shouldBeHorizontal = vector.x != 0 && Math.Abs(vector.x) >= Math.Abs(vector.y);

            direction.Facing = shouldBeHorizontal ? directionIfHorizontal : directionIfVertical;

            return direction;
        }

        public Vector2 GetAsVector2(float scale = 1.0f)
        {
            float signedScale = scale * this.GetSign;
            return this.IsHorizontal ? new Vector2(signedScale, 0f) : this.IsVertical ? new Vector2(0f, signedScale) : Vector2.zero;
        }
    }
}
