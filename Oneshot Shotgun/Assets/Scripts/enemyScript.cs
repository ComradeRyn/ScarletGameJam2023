using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject hitBox;
    public playerScript player;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = this.gameObject;
        hitBox = GameObject.Find("hitBox");
        player = GameObject.Find("Player").GetComponent<playerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            player.setCanJump(true);
            Destroy(this.gameObject);
        }

    }
}
