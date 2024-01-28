using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanPrefabScript : MonoBehaviour
{

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1){
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var healthComponent = other.gameObject.GetComponent<Health>();
            if (healthComponent != null) 
            {
                healthComponent.TakeDamage(1);
            }
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}
