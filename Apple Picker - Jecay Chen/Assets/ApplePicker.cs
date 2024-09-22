using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start(){
        basketList = new List<GameObject>();
        // Idea: Summon N number of baskets on top of each other as lives at game start
        for(int i=0; i < numBaskets; i++){
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i); //Baskets with Y space apart
            tBasketGO.transform.position = pos; 
            basketList.Add(tBasketGO); // Tracks/Lists Basket objects
        }
    }

    public void AppleMissed(){
        // Destroy all falling Apple objects
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("GoodApple");
        foreach(GameObject tempGo in appleArray){
            Destroy(tempGo);
        }
        appleArray = GameObject.FindGameObjectsWithTag("BadApple");
        foreach(GameObject tempGo in appleArray){
            Destroy(tempGo);
        }

        // Destroy 1 Basket object (lives)
        // Get index of last Basket object (top)
        int basketIndex = basketList.Count - 1;
        // Reference Basket object at index
        GameObject basketGO = basketList[basketIndex];
        // Remove Basket object from list and destroy GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // If no Basket objects left (lives), restart game
        if(basketList.Count == 0){
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
