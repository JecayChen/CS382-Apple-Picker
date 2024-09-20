using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour{
    // Lowest bound object Apple can
    public static float bottomY = -20f;
    void Update(){
        // Apple object deletes itself after falling below lowest bound
        if(transform.position.y < bottomY){
            Destroy(this.gameObject);
        }
        
    }
}
