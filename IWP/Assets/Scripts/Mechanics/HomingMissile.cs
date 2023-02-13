using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;

public class HomingMissile : MonoBehaviour
{

    public float speed = 5f;
    public float rotatespeed = 200f;
    public Rigidbody2D rb;
    public float bulletdir;
    Transform target;
    private Platformer.Mechanics.PlayerController pController;
    private Platformer.Mechanics.EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        pController = FindObjectOfType<Platformer.Mechanics.PlayerController>();
        bulletdir = pController.dir;
        rb.velocity = transform.right * speed * bulletdir;

    }


    // Update is called once per frame
    void Update()
    {
        target = FindClosestEnemy().transform;
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            rb.angularVelocity = -rotateAmount * rotatespeed;
            rb.velocity = transform.right * speed;
        }
        else if (target == null)
        {
            transform.position += transform.right * Time.deltaTime * speed * bulletdir;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(gameObject);
            var enemy = collision.gameObject.GetComponent<EnemyController>();
            var enemy2 = collision.gameObject.GetComponent<RangedEnemyController>();
            if (enemy != null)
            {
                var ev = Schedule<BulletEnemyCollision>();
                ev.enemy = enemy;
            }
            else if(enemy2 != null)
            {
                var ev = Schedule<BulletRangedEnemyCollision>();
                ev.enemy = enemy2;
            }
            else
            {
                Destroy(collision.gameObject);
            }

        }
        else if (collision.gameObject.tag == "Level")
        {

            Destroy(gameObject);

        }
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

}
