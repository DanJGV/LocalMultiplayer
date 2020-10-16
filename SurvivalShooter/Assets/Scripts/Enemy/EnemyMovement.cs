using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    Transform player2;
    PlayerHealth playerHealth;
    PlayerHealth player2Health;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    float rangePlayer1;
    float rangePlayer2;
    public bool mp;
    GameObject spawn;
    GameObject playerA;
    GameObject playerB;
    public bool playerFound = false;
    void Awake ()
    {
        spawn = GameObject.Find("Player2Spawner");
        player = GameObject.Find ("Player 1").transform;
        playerA = GameObject.Find("Player 1");
        playerHealth = player.GetComponent <PlayerHealth> ();
        
        enemyHealth = GetComponent <EnemyHealth> ();
        
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
       
    }


    void Update ()
    {
        mp = spawn.GetComponent<spawner>().multiplayer;
        if (mp == false)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            playerB = GameObject.Find("Player 2");
            player2 = GameObject.Find("Player 2").transform;
          
            if (enemyHealth.currentHealth > 0)
            {
                rangePlayer1 = Vector3.Distance(transform.position, player.position);
                rangePlayer2 = Vector3.Distance(transform.position, player2.position);
                if (rangePlayer2 > rangePlayer1)
                {
                    nav.SetDestination(player.position);
                }
                else
                {
                    nav.SetDestination(player2.position);
                }

                if(playerA.GetComponent<PlayerHealth>().isDead == true)
                {
                    nav.SetDestination(player2.position);
                }
                if (playerB.GetComponent<PlayerHealth>().isDead == true)
                {
                    nav.SetDestination(player.position);
                }

            }
            else
            {
                nav.enabled = false;
            }
        }
    }

    void findPlayer()
    {
        if(playerFound == false)
        {
            
            playerFound = true;
        }
    }
}
