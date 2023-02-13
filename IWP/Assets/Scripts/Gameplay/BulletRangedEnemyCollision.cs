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
    public class BulletRangedEnemyCollision : Simulation.Event<BulletRangedEnemyCollision>
    {
        public RangedEnemyController enemy;

        public override void Execute()
        {

            var enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                Debug.Log("RE HD");
                enemyHealth.Decrement();
                if (!enemyHealth.IsAlive)
                {
                    Debug.Log("RE DIE");
                    Schedule<RangedEnemyDeath>().enemy = enemy;
                }

            }
            else
            {
                Debug.Log("RE WRONG");
                Schedule<RangedEnemyDeath>().enemy = enemy;
            }
            

        }
    }
}