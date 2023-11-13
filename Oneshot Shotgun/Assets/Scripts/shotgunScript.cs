using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class shotgunScript : MonoBehaviour
{

    private float mousePositionX;
    private float mousePositionY;

    private float playerPositionX;
    private float playerPositionY;

    private float difX;
    private float difY;

    private float angle;

    public GameObject mySprite;
    // Start is called before the first frame update
    void Start()
    {
      //  mySprite = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      //  mousePositionX = Input.mousePosition.x;
     //   mousePositionY = Input.mousePosition.y;

      //  playerPositionX = mySprite.transform.position.x;
     //   playerPositionY = mySprite.transform.position.y;

      //  difX = mousePositionX - playerPositionX;
      //  difY = mousePositionY - playerPositionY;

      //  angle = Mathf.Atan(difY / difX);

       // mySprite.transform.Rotate(new Vector3(0, 0, angle), new Space());

    }
}
