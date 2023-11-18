using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        this.hitBox.GetComponent<BoxCollider2D>().enabled = false;
        this.Enemy.GetComponent<BoxCollider2D>().enabled = false;
        this.Enemy.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Respawn()
    {
        this.Enemy.GetComponent<BoxCollider2D>().enabled = true;
        this.Enemy.GetComponent<SpriteRenderer>().enabled = true;
        this.hitBox.GetComponent<BoxCollider2D>().enabled = true;
    }
}
