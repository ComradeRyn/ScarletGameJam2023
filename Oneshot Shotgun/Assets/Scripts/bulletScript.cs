using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bulletScript : MonoBehaviour
{
    public CircleCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "HitBox")
        {
            collision.gameObject.transform.parent.GetComponent<EnemyScript>().Kill();
        }
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
  
    }

}
