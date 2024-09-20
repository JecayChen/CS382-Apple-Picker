using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour{
    [Header("Inscribed")]

    // Prefab for tree to instantiate Apples object
    public GameObject applePrefab;

    // Speed of movement for the AppleTree object (left and right)
    public float speed = 1f;

    // Bounds of where object AppleTree can move (left and right bound)
    public float leftAndRightEdge = 10f;

    // Chance that object AppleTree will switch directions (left and right)
    public float changeDirChance = .1f;

    // Seconds between instantiation of object Apple
    public float appleDropDelay = 1f;

    void Start(){
        // Start dropping object Apple
        Invoke("DropApple", 2f);
    }

    void Update(){
        // Object moves
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing direction after hitting Bound and randomly
        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed); // Move right after hitting left bound
        }else if(pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed); // Move left after hitting right bound
        //}else if(Random.value < changeDirChance){
        //    speed *= -1; // Randomly change direction
        }
    }
    
    void FixedUpdate(){
        // Random direction changes are now time-based instead of framerate based
        if(Random.value < changeDirChance){
            speed *= -1; // Randomly change direction
        }
    }

    void DropApple(){
        GameObject apple = Instantiate<GameObject>(applePrefab);
        Vector3 pos = transform.position;

        if(Random.value >= .5){
            pos.x += (Random.value * 2f);
            apple.transform.position = pos;
        }else{
            pos.x -= (Random.value * 2f);
            apple.transform.position = pos;
        }
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }
}
