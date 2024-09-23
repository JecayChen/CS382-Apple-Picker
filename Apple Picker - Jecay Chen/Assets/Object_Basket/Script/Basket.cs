using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour{

    public ScoreCounter scoreCounter; //Creates a blank reference to ScoreCounter script;
    public AppleTree appleTreeComp; //Creates a blank reference to AppleTree script;
    public RoundCounter roundCounter; //Creates a blank reference to AppleTree script;

    public static int _POINT_WORTH = 50;

    void Start(){
        // Find GameObject ScoreCounter in Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get ScoreCounter script component of scoreGo
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();

        // Find GameObject AppleTree in Scene Hierachy
        GameObject appleTreeGO = GameObject.Find("Tree_AppleTree");
        // Get Apple Tree script component of AppleTree
        appleTreeComp = appleTreeGO.GetComponent<AppleTree>();

        // Find GameObject RoundCounter in Scene Hierarchy
        GameObject roundGO = GameObject.Find("RoundCounter");
        // Get RoundCounter script component of roundGo
        roundCounter = roundGO.GetComponent<RoundCounter>();
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
        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

        // Name/Type of object detection
        GameObject collidedWith = coll.gameObject;
        // Delete object if GoodApple
        if(collidedWith.CompareTag("GoodApple")){
            Destroy(collidedWith);

            // Increase score
            scoreCounter.score += _POINT_WORTH;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }else if(collidedWith.CompareTag("BadApple")){ // Check for BadApple
            Destroy(collidedWith);

            // Get refererence to ApplePicker component in Main Camera
            //ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            // Call public AppleMissed() of apScript
            apScript.AppleMissed();
        }
        
        switch(scoreCounter.score){
            case 1000:
                _POINT_WORTH = 200;
                appleTreeComp.speed = 30f;
                appleTreeComp.appleDelayMin = .4f;
                appleTreeComp.appleDelayMax = .6f;
                appleTreeComp.badAppleChance = .07f;
                apScript.changeScale(3.33f);
                roundCounter.round = 2;
                break;

            case 10000:
                _POINT_WORTH = 900;
                appleTreeComp.speed = 40f;
                appleTreeComp.appleDelayMin = .3f;
                appleTreeComp.appleDelayMax = .45f;
                appleTreeComp.badAppleChance = .09f;
                apScript.changeScale(2.67f);
                roundCounter.round = 3;
                break;
            
            case 100000:
                _POINT_WORTH = 1000;
                appleTreeComp.speed = 50f;
                appleTreeComp.appleDelayMin = .2f;
                appleTreeComp.appleDelayMax = .3f;
                appleTreeComp.badAppleChance = .1f;
                apScript.changeScale(2f);
                roundCounter.round = 4;
                break;
        }
        
    }
}
