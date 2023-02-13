using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController player;

    public Text bulletCount,Lives;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Lives.text = "Lives:" + player.health.currentHP;

        if(player.gun1.enabled == true)
        {
            bulletCount.text = player.gun1.currentAmmo + " / " + player.gun1.maxAmmo;
        }
        else if(player.gun2.enabled == true)
        {
            bulletCount.text = player.gun2.currentAmmo + " / " + player.gun2.maxAmmo;
        }

    }
}
