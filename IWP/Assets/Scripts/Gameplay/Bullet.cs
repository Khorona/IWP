using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public float bulletdir;
    private Platformer.Mechanics.PlayerController pController;
    private Platformer.Mechanics.EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {

        pController = FindObjectOfType<Platformer.Mechanics.PlayerController>();
        bulletdir = pController.dir;
        //rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed * bulletdir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {

            Destroy(gameObject);
            var enemy = collision.gameObject.GetComponent<EnemyController>();
            if(enemy  != null)
            {
                var ev = Schedule<BulletEnemyCollision>();
                ev.enemy = enemy;
            }
            else
            {
                Destroy(collision.gameObject);
            }
            //var health = collision.GetComponent<Health>();
            //if (health != null)
            //{
            //    health.Decrement();
            //    if (!health.IsAlive)
            //    {
            //        Destroy(collision.gameObject);


            //    }
            //}
            //else
            //{
            //    Destroy(collision.gameObject);
            //}
        }
        else if (collision.gameObject.tag == "Level")
        {

            Destroy(gameObject);

        }
    }
}
