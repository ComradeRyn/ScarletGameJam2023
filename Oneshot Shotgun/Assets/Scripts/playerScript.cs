using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public Rigidbody2D rb; //varaible hell
    public BoxCollider2D collider;
    private float dirX = 0f;
    private bool leftPressed;
    private bool rightPressed;
    private bool mousePressed;
    private bool jumping = false;
    private bool canJump = false;

    [SerializeField] private float SPEED;
    [SerializeField] private float RECOIL;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //gets the rb and collider of player
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        leftPressed = Input.GetKeyDown("a"); //useless, dones't do anything at the moment
        rightPressed = Input.GetKeyDown("d");

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Floor") //resets jumps
        {
            canJump = true;
        }
    }

    void FixedUpdate()
    {
        float yVel = rb.velocity.y;
        float XVel = rb.velocity.x;

        if (Input.GetMouseButton(0) && canJump) //controls the first part of the jump
        {
            jumping = true;
            canJump = false;
        }

        if (canJump) { //curently bugged. Shit aint working because of complication with the current leftright movement
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * SPEED, yVel);
        }

        if (jumping && !canJump) //Controls the jumping
        {
            rb.velocity = new Vector2(XVel, yVel);
            var usingAngle = getAngle();
            var usingX = RECOIL * Mathf.Cos(usingAngle); //Trig stuff I'm super proud of
            var usingY = RECOIL * Mathf.Sin(usingAngle);
            jumping = false;
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
}
