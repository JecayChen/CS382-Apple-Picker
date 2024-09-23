using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour{
    [Header("Dynamic")]

    public static bool gameOver = false;
    public int score;

    private Text uiText;

    void Awake(){
        score = setScore();
    }
    void Start(){
        uiText = GetComponent<Text>();
    }

    void Update(){
        uiText.text = "Score: " + score.ToString("#,0"); 
    }

    public static int setScore(){
        if(PlayerPrefs.HasKey("Score") && gameOver){
            gameOver = false;
            return PlayerPrefs.GetInt("Score");
        }else{
            return 0;
        }
    }
}
    
