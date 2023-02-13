using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player enters a trigger with a DeathZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredDispenseZone"></typeparam>
    public class PlayerEnteredDispenseZone : Simulation.Event<PlayerEnteredDispenseZone>
    {
        public DispenseZone dispensezone;
        public int gunType;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;

            if(gunType == 1)
            {
                player.gun1.enabled = true;
                player.gun2.enabled = false;
                Debug.Log("Gun 1");
            }
            else if (gunType == 2)
            {
                player.gun1.enabled = false;
                player.gun2.enabled = true;
                Debug.Log("Gun 2");
            }

        }
    }
}