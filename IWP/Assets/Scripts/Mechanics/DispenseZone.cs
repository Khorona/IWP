using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{

    public class DispenseZone : MonoBehaviour
    {

        public int guntype;

        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredDispenseZone>();
                ev.dispensezone = this;
                ev.gunType = guntype;
            }
        }
    }
}
