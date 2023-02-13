using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class RangedEnemyController : MonoBehaviour
    {
        public PatrolPath path;
        public AudioClip ouch;
        //public BoxCollider2D detectionbox;
        public Transform startingpoint;
        public GameObject bulletprefab;

        internal PatrolPath.Mover mover;
        internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        SpriteRenderer spriteRenderer;

        public Bounds Bounds => _collider.bounds;

        private bool fired;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<CapsuleCollider2D>(); 
            _audio = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            fired = false;
        }


        void OnCollisionEnter2D(Collision2D collision1)
        {


            Debug.Log("CapsuleCollider");
            // do stuff only for the capsule collider
            var player = collision1.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                var ev = Schedule<PlayerRangedEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
            }
            else if (collision1.gameObject.tag == "Bullet")
            {
                Debug.Log("RE Bullet");
                var eve = Schedule<PlayerRangedEnemyCollision>();
                eve.enemy = this;
                // Destroy(collision1.gameObject);
            }

            

        }


        void Update()
        {
            //if (path != null)
            //{
            //    if (mover == null) mover = path.CreateMover(control.maxSpeed * 0.5f);
            //    control.move.x = Mathf.Clamp(mover.Position.x - transform.position.x, -1, 1);
            //}



            GameObject player = GameObject.FindGameObjectWithTag("Player");
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if(distance <= 7 && !fired)
            {
                //Debug.Log("Player spotted");
                StartCoroutine(FireHomingMissile());
            }
        }


        IEnumerator FireHomingMissile()
        {
            fired = true;
            Instantiate(bulletprefab, startingpoint.position, startingpoint.rotation);
            yield return new WaitForSeconds(2.5f);
            fired = false;
        }



    }
}