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
    private int canJump = 0;

    [SerializeField] private float SPEED;
    [SerializeField] private float RECOIL;

    private float mousePositionX;
    private float mousePositionY;

    private float playerPositionX;
    private float playerPositionY;

    private float difX;
    private float difY;

    private float angle;

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
            canJump = 1;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && canJump > 0) //controls the first part of the jump
        {
            jumping = true;
            canJump--;
        }

        if (!jumping) { //curently bugged. Shit aint working because of complication with the current leftright movement
        float yVel = rb.velocity.y;
        dirX = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(dirX * SPEED, yVel);
        }

        if (jumping) //Controls the jumping
        {
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

        mousePositionX = mouseWorldPos.x;
        mousePositionY = mouseWorldPos.y;

        playerPositionX = rb.transform.position.x;
        playerPositionY = rb.transform.position.y;

        difX = mousePositionX - playerPositionX;
        difY = mousePositionY - playerPositionY;

        angle = Mathf.Atan(difY / difX);

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
