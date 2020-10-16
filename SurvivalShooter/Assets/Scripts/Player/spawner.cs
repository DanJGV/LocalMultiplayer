using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject player;
 
    //public Transform location;
    public bool multiplayer = false;
    public Camera cam1;
    public GameObject cam2;
    public GameObject slider;
    public GameObject heart;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && multiplayer == false)
        {
            player.SetActive(true);
            //objectClone = Instantiate(player, location.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            //objectClone.name = "Player 2";
            cam1.rect = new Rect(0, 0, 0.5f, 1);
            cam2.SetActive(true);
            slider.SetActive(true);
            heart.SetActive(true);

            multiplayer = true;
        }
    }
}
