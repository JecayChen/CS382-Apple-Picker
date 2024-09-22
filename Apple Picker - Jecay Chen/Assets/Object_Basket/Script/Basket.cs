using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour{

    public ScoreCounter scoreCounter;
    void Start(){
        // Find GameObject ScoreCounter in Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        // Get ScoreCounter script component of scoreGo
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update(){
        // Get current mouse screen coordinates
        Vector3 mousePos2D = Input.mousePosition;

        // Sets mouse Z axis to the negative distance of Z value of the camera (main game location is at Z=0)
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the the onscreen mouse position to the 3D game space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the X pos of the basket to the X pos of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll){

        // Name/Type of object detection
        GameObject collidedWith = coll.gameObject;
        // Delete object if GoodApple
        if(collidedWith.CompareTag("GoodApple")){
            Destroy(collidedWith);

            // Increase score
            scoreCounter.score += 100; 
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }else if(collidedWith.CompareTag("BadApple")){ // Check for BadApple
            Destroy(collidedWith);

            // Get refererence to ApplePicker component in Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            // Call public AppleMissed() of apScript
            apScript.AppleMissed();
        }
    }
}
