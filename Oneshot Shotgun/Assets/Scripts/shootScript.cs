using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject launchPoint;
    private string localPath;

    private playerScript playerStuff;

    [SerializeField] private float BULLETSPEED;
    // Start is called before the first frame update
    void Start()
    {
        playerStuff = GameObject.Find("Player").GetComponent<playerScript>();
        launchPoint = this.gameObject;

       // localPath = "Assets/Prefabs/bullet.prefab";
       // localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

      //  PrefabUtility.SaveAsPrefabAssetAndConnect(bulletPrefab, localPath, InteractionMode.UserAction);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var canJump = playerStuff.getCanJump();
        if (canJump && playerStuff.getMousePressed())
        {
            var usingX = BULLETSPEED * Mathf.Cos(playerStuff.getShootAngle()); //Trig stuff I'm super proud of
            var usingY = BULLETSPEED * Mathf.Sin(playerStuff.getShootAngle());
            GameObject newBullet1 = Instantiate(bulletPrefab, new Vector3(launchPoint.transform.position.x, launchPoint.transform.position.y, 0), Quaternion.identity);
            newBullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(usingX, usingY);

        }
    }
}
