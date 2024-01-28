using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelegraphSpawner : MonoBehaviour
{    
    public Rigidbody2D rb;
    public GameObject telegraphPrefab;
    public GameObject BanPrefab;
    public Transform player;
    public float speed;

    //Private variables
    //private float MOVING_SPEED = 10;
    private float distance;
    private float timer;
    private float attTimer;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 4){
            //Gets ready to attack the player
            timer = 0;
            SpawnTelegraphAtt();
        }
        else{
            //speed = MOVING_SPEED;
            Vector2 playerXPos = new Vector2(player.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, playerXPos, speed * Time.deltaTime);
        }
        
    }

    void SpawnTelegraphAtt()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, -2, 0);
        Instantiate(telegraphPrefab, spawnPos, Quaternion.identity);
        Instantiate(BanPrefab, spawnPos, Quaternion.identity);
        //Method to Bring down Hammer
        //downHammer();
    }

    void downHammer()
    { 
        Vector3 downPos = new Vector3(transform.position.x, player.position.y, 0);

    }
}
