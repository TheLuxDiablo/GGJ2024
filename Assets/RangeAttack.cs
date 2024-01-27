using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
             {
             Instantiate(projectile, shotPoint.position, transform.rotation);
             timeBtwShots = startTimeBtwShots;
             }
        }
        else 
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
