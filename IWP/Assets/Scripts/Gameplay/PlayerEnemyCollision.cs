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
    /// <typeparam name="EnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
        public EnemyController enemy;
        public PlayerController player;
        public Rigidbody2D rb;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var willHurtEnemy = player.Bounds.center.y >= enemy.Bounds.max.y;
            var playerHealth = player.GetComponent<Health>();

            if (willHurtEnemy)
            {
                var enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Decrement();
                    if (!enemyHealth.IsAlive)
                    {
                        Schedule<EnemyDeath>().enemy = enemy;
                        player.Bounce(2);
                    }
                    else
                    {
                        player.Bounce(7);
                    }
                }
                else
                {
                    Schedule<EnemyDeath>().enemy = enemy;
                    player.Bounce(2);
                }
            }
            else
            {

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
                //else
                //{
                //    Schedule<PlayerDeath>();
                //}

            }
        }
    }
}