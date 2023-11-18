using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    private playerScript player;
    private GameObject enemies;
    private GameObject ammo;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<playerScript>();
        enemies = GameObject.Find("Enemies");
        ammo = GameObject.Find("ammo");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.getReturnedToGround() && player.getCanJump())
        {
            for(int i = 0; i < enemies.transform.childCount; i++)
            {
                enemies.transform.GetChild(i).GetComponent<EnemyScript>().Respawn();
            }
        }
    }
}
