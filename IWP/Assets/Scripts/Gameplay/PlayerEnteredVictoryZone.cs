using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a VictoryZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredVictoryZone"></typeparam>
    /// 
    //public 
    public class PlayerEnteredVictoryZone : Simulation.Event<PlayerEnteredVictoryZone>
    {
        public VictoryZone victoryZone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            model.player.controlEnabled = false;
            model.player.move.x = 0;
            model.player.animator.SetTrigger("victory");
            //EditorApplication.Exit(0);
            Application.Quit();
            //SceneManager.LoadScene("Level2");
        }
    }
}