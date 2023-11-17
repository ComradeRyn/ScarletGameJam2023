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
        hitBox = this.gameObject.transform.GetChild(0).gameObject;
        player = GameObject.Find("Player").GetComponent<playerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hitBox.transform.position);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            player.setCanJump(true);
            Kill();
        }

    }

    public void Kill()
    {
        hitBox.GetComponent<BoxCollider2D>().enabled = false;
        Enemy.GetComponent<BoxCollider2D>().enabled = false;
        Enemy.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Respawn()
    {
        Enemy.GetComponent<BoxCollider2D>().enabled = true;
        Enemy.GetComponent<SpriteRenderer>().enabled = true;
        hitBox.GetComponent<BoxCollider2D>().enabled = true;
    }
}
