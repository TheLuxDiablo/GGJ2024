using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelegraphSpawner : MonoBehaviour
{
    public GameObject telegraphPrefab;
    public Transform player;
    public float speed;

    //Private variables
    private float MOVING_SPEED = 10;
    private float distance;
    private float timer;
    private float CDtimer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 4){
            //Gets ready to attack the player
            timer = 0;
            SpawnTelegraphAtt();

            /*          1/27/2024: NEED TO FIX THE MOVING SPEED OF THE BAN HAMMER, WHEN IT ATTACKS, IT MUST STOP AND AFTER COOLDOWN 
                        RESUME THE SPEED OF THE MOVING HAMMER ALWAYS FOLLOWING THE PLAYER*/
            CDtimer += Time.deltaTime;
            if (CDtimer > 2){
                CDtimer = 0;
                speed = MOVING_SPEED;
            }
            
            //Timing the attack
        }
        else{
            //Checking the distance between player
            //distance = Vector2.Distance(transform.position, player.transform.position);
            //Vector2 direction = player.transform.position - transform.position;
            Vector2 playerXPos = new Vector2(player.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, playerXPos, speed * Time.deltaTime);
        }
    }

    void SpawnTelegraphAtt()
    {
        speed = 0;
        Vector3 spawnPos = new Vector3(transform.position.x, 0, 0);
        Instantiate(telegraphPrefab, spawnPos, Quaternion.identity);
    }
}
