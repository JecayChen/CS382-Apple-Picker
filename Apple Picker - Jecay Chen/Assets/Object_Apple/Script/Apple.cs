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

            // Get refererence to ApplePicker component in Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            // Call public AppleMissed() of apScript
            if(this.gameObject.CompareTag("BadApple")){

            }else if(this.gameObject.CompareTag("GoodApple")){
                apScript.AppleMissed();
            }
        }
        
    }
}
