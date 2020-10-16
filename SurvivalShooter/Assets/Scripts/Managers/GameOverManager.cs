using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerHealth playerHealth2;
	public float restartDelay = 5f;
    public GameObject spawn;
    public bool mp;

    Animator anim;
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
        
    }


    void Update()
    {
        mp = spawn.GetComponent<spawner>().multiplayer;
       if (mp == false)
        {
            if (playerHealth.currentHealth <= 0)
            {
                anim.SetTrigger("GameOver");

                restartTimer += Time.deltaTime;

                if (restartTimer >= restartDelay)
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        }
        else
        {

            if (playerHealth.currentHealth <= 0 && playerHealth2.currentHealth <= 0)
            {
                anim.SetTrigger("GameOver");

                restartTimer += Time.deltaTime;

                if (restartTimer >= restartDelay)
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        }
    }
    
}
