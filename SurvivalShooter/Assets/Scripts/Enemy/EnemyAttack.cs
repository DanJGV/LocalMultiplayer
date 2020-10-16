using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    GameObject player2;
    GameObject spawn;
    PlayerHealth playerHealth;
    PlayerHealth player2Health;
    EnemyHealth enemyHealth;
    bool playerInRange;
    bool player2InRange;
    float timer;
    bool mp;

    void Awake ()
    {
        
        player = GameObject.Find ("Player 1");
        spawn = GameObject.Find("Player2Spawner");
        playerHealth = player.GetComponent <PlayerHealth> ();
       
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
        mp = spawn.GetComponent<spawner>().multiplayer;
       
        
       
        

    }
    

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
        if (other.gameObject == player2)
        {
            player2InRange = true;
        }

    }

    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
        if (other.gameObject == player2)
        {
            player2InRange = false;
        }
    }

   


    void Update ()
    {

        if (mp == false)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {
                Attack();
            }
            if (playerHealth.currentHealth <= 0)
            {
                anim.SetTrigger("PlayerDead");
            }
        }
        else
        {
            player2 = GameObject.Find("Player 2");
            player2Health = player2.GetComponent<PlayerHealth>();

            timer += Time.deltaTime;

            if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {
                Attack();
            }
            if (timer >= timeBetweenAttacks && player2InRange && enemyHealth.currentHealth > 0)
            {
                Attack2();
            }

            if (playerHealth.currentHealth <= 0)
            {
                anim.SetTrigger("PlayerDead");
            }

            if (player2Health.currentHealth <= 0)
            {
                anim.SetTrigger("PlayerDead");
            }
        }

    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }

    }
    void Attack2()
    {
        timer = 0f;
        if (player2Health.currentHealth > 0)
        {
            player2Health.TakeDamage(attackDamage);
        }
    }
}
