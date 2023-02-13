using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Model;
using Platformer.Core;
using Platformer.Mechanics;

public class RPG : MonoBehaviour
{

    public Transform startingpoint;
    public GameObject bulletprefab;
    public GameObject player;

    //public float fireRate = 0;
    //public float Damage = 5;
    public int maxAmmo;
    public int currentAmmo;

    // Start is called before the first frame update
    void Awake()
    {
        currentAmmo = maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {
        //if(flipped = false && player.GetComponent<SpriteRenderer>().flipX == true)
        //{
        //    startingpoint.transform.Rotate(0.0f, 180.0f, 0.0f);
        //    flipped = true;
        //}
        //else if(flipped == true && player.GetComponent<SpriteRenderer>().flipX == false)
        //{
        //    startingpoint.transform.Rotate(0.0f, 180.0f, 0.0f);
        //    flipped = false;

        //}

        if(player.GetComponent<PlayerController>().controlEnabled)
        {
            if (currentAmmo > 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    currentAmmo -= 1;
                    Shoot();
                }
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                Reload();
            }

        }

    }

    void Shoot()
    {

        Instantiate(bulletprefab, startingpoint.position, startingpoint.rotation);
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
    }
}
