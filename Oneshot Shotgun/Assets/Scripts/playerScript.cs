using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public Rigidbody2D rb; //varaible hell
    public GameObject respawnPoint;
    
    private float dirX = 0f;
    private bool mousePressed;
    private bool jumping = false;
    private bool canJump = true;
    private bool returnedToGround = true;

    [SerializeField] private float SPEED;
    [SerializeField] private float RECOIL;

    [SerializeField] private int JUMPDELAY;
    private int jumpDelayTime;



    // Start is called before the first frame update
    void Start()
    {
        jumpDelayTime = JUMPDELAY;
        respawnPoint = GameObject.Find("RespawnPoint");
        rb = GetComponent<Rigidbody2D>(); //gets the rb and collider of player
        respawn();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !mousePressed)
        {
            mousePressed = true;
            jumpDelayTime = 0;
        }
        if (jumpDelayTime < JUMPDELAY)
        {
            jumpDelayTime++;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if ((collision.gameObject.tag == "Floor" || collision.gameObject.tag == "HitBox") && !canJump && jumpDelayTime == JUMPDELAY) //resets jumps
        {
            canJump = true;
            returnedToGround = true;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            respawn();
            returnedToGround = true;
        }
    }

    void FixedUpdate()
    {
        float yVel = rb.velocity.y;
        float XVel = rb.velocity.x;

        if(mousePressed && canJump) //controls the first part of the jump
        {
            mousePressed = false;
            jumping = true;
            canJump = false;
            returnedToGround = false;
        }

        if (canJump && !mousePressed) {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * SPEED, yVel);
        }

        if (jumping && !canJump) //Controls the jumping
        {
            jumping = false;
            rb.velocity = new Vector2(XVel, yVel);
            var usingAngle = getAngle();
            var usingX = RECOIL * Mathf.Cos(usingAngle); //Trig stuff I'm super proud of
            var usingY = RECOIL * Mathf.Sin(usingAngle);
            rb.AddForce(new Vector2(usingX, usingY), ForceMode2D.Impulse); 

        }
    }
    private float getAngle() //gets the angle that the player will be launched at
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float difX = mouseWorldPos.x - rb.transform.position.x;
        float difY = mouseWorldPos.y - rb.transform.position.y;

        float angle = Mathf.Atan(difY / difX);

        if (difX < 0 && difY > 0)
        {
            angle += Mathf.PI;
        }
        else if (difX < 0 && difY < 0)
        {
            angle += Mathf.PI;
        }

        return angle += Mathf.PI;
    }

    public float getShootAngle() //called in seperate class
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float difX = mouseWorldPos.x - rb.transform.position.x;
        float difY = mouseWorldPos.y - rb.transform.position.y;

        float angle = Mathf.Atan(difY / difX);

        if (difX < 0 && difY > 0)
        {
            angle += Mathf.PI;
        }
        else if (difX < 0 && difY < 0)
        {
            angle += Mathf.PI;
        }

        return angle;
    }

    public bool getCanJump()
    {
        return canJump;
    }

    public bool getMousePressed()
    {
        return mousePressed;
    }

    public void setCanJump(bool x)
    {
        canJump = x;
    }

    public void respawn()
    {
        rb.transform.position = respawnPoint.transform.position;
    }

    public bool getReturnedToGround()
    {
        return returnedToGround;
    }
}
