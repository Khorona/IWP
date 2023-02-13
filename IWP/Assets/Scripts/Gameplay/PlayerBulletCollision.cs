using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="PlayerbulletCollision"></typeparam>
    public class PlayerBulletCollision : Simulation.Event<PlayerBulletCollision>
    {
        //public EnemyController enemy;
        public PlayerController player;
        public Rigidbody2D rb;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {

            var playerHealth = player.GetComponent<Health>();

                playerHealth.PlayerDecrement();
                player.controlEnabled = false;
                player.move.x = 0;
                player.animator.SetTrigger("hurtflip");
                //player.GetComponent<SpriteRenderer>().flipX = true;
                if (player.health.IsAlive)
                {

                    if (player.dir == 1)
                    {

                        //player.Bounce(7);
                        player.Bounce(new Vector2(-1, 3));
                        player.move.x = -0.25f;
                        //player.Bounce(7);
                        Simulation.Schedule<EnablePlayerInput>(1f);
                        Debug.Log("bounce left");
                    }
                    else
                    {
                        //player.Bounce(7);
                        player.Bounce(new Vector2(1, 3));
                        player.move.x = 0.25f;
                        //player.Bounce(7);
                        Simulation.Schedule<EnablePlayerInput>(1f);
                        Debug.Log("bounce right");
                    }
                }

            
        }
    }
}