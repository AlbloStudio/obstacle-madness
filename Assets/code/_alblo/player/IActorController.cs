//-----------------------------------------------------------------------
// <copyright file="IActorController.cs" company="alblo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using Alblo.Utils;
using UnityEngine;

namespace Alblo.Actors.Player
{
    public interface IActorController
    {
        Vector2 MovementDirection { get; }
        Direction LookingAt { get; }
        Direction ShootingDirection { get; }
        bool IsShooting { get; }
    }
}
