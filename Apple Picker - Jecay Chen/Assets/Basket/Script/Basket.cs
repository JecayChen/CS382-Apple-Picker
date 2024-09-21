using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour{
    void Start(){

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
        if(collidedWith.CompareTag("Apple")){
            Destroy(collidedWith);
        }
    }
}
