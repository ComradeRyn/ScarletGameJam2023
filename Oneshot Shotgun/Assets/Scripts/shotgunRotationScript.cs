using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class shotgunRotationScript : MonoBehaviour
{
    public Collider2D piviot;
    // Start is called before the first frame update
    void Start()
    {
        piviot = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        piviot.transform.eulerAngles = new Vector3(0f, 0f, getAngle() - 22);
    }
    private float getAngle() //gets the angle that the player will be launched at
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float difX = mouseWorldPos.x - piviot.transform.position.x;
        float difY = mouseWorldPos.y - piviot.transform.position.y;

        float angle = Mathf.Atan(difY / difX);

        if (difX < 0 && difY > 0)
        {
            angle += Mathf.PI;
        }
        else if (difX < 0 && difY < 0)
        {
            angle += Mathf.PI;
        }

        return angle * 180/Mathf.PI;
    }
}
