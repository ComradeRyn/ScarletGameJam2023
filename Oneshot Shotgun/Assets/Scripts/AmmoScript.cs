using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public playerScript player;
    private GameObject ammoBox;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<playerScript>();
        ammoBox = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.setCanJump(true);
            Kill();
        }

    }

    public void Kill()
    {
        ammoBox.GetComponent<BoxCollider2D>().enabled = false;
        ammoBox.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Respawn()
    {
        ammoBox.GetComponent<BoxCollider2D>().enabled = true;
        ammoBox.GetComponent<SpriteRenderer>().enabled = true;
    }
}
