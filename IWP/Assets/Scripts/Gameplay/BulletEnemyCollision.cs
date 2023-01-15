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
    public class BulletEnemyCollision : Simulation.Event<BulletEnemyCollision>
    {
        public EnemyController enemy;

        public override void Execute()
        {

            var enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.Decrement();
                if (!enemyHealth.IsAlive)
                {
                    Schedule<EnemyDeath>().enemy = enemy;
                }

            }
            else
            {
                Schedule<EnemyDeath>().enemy = enemy;
            }
            

        }
    }
}