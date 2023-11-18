using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    private playerScript player;
    private GameObject enemies;
    private GameObject ammoBoxes;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<playerScript>();
        enemies = GameObject.Find("Enemies");
        ammoBoxes = GameObject.Find("ammoBoxes");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.getRespawnEnemy() && player.getCanJump())
        {
            for(int i = 0; i < enemies.transform.childCount; i++)
            {
                enemies.transform.GetChild(i).GetComponent<EnemyScript>().Respawn();
            }
        }

        if (player.getRespawnAmmo() && player.getCanJump())
        {
            for (int i = 0; i < ammoBoxes.transform.childCount; i++)
            {
                ammoBoxes.transform.GetChild(i).GetComponent<AmmoScript>().Respawn();
            }
        }
    }
}
