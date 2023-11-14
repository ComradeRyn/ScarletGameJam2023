using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        bulletPrefab = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
