using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    public GameObject victoryFlag;

    private void Start() 
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            Instantiate(victoryFlag, new Vector3(20, -1, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
