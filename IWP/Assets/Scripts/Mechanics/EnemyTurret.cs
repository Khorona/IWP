using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public Transform startingpoint;
    public GameObject bulletprefab;
    public float firerate = 5.0f;
    public float timetofire = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timetofire > 0)
        {
            timetofire -= Time.deltaTime;
        }
        else
        {
            Shoot();
            timetofire = firerate;
        }

    }

    void Shoot()
    {
        while (FindPlayer() != null)
        {
            Instantiate(bulletprefab, startingpoint.position, startingpoint.rotation);
            var nextFire = Time.time + 1;
        }
    }

    public GameObject FindPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = 40.0f;
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
