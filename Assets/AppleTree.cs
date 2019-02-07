using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Set in Inspector")]

    public GameObject applePrefab;

    public float speed = 15f;

    public float leftAndRightEdge = 23f;

    public float chanceToChangeDirections = .02f;

    public float secondsBetweenAppleDrops = 1f;


    // Use this for initialization
    void Start() {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update() {
        //defines the Vector3 pos to be the current positon of the AppleTree
        Vector3 pos = transform.position;
        //increases x component of pos by speed * Time.deltaTime
        pos.x += speed * Time.deltaTime;
        //assigns modified pos back to transform.postion so that AppleTree will move
        transform.position = pos;


        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move left
        }
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
