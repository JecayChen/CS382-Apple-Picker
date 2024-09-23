using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour{
    static private Text _UI_TEXT;
    static private int _SCORE = 1000;

    private Text txtCom; // Reference for this GO Text component

    void Awake(){
        _UI_TEXT = GetComponent<Text>();

        // Check if PlayerPref Highscore exists and read it
        if(PlayerPrefs.HasKey("HighScore")){
            SCORE = PlayerPrefs.GetInt("HighScore");
        }

        // Assign new high score to HighScore
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE{
        get{return _SCORE;}
        private set{
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", SCORE);
            if(_UI_TEXT != null){
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry){
        if(scoreToTry <= SCORE) // If current score does not beat high score, do nothing and escape
            return;
        SCORE = scoreToTry;
    }

    // To reset PlayerPrefs HighScore
    [Tooltip("Check this box to reset the Highscore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos(){
        if(resetHighScoreNow){
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 0);
            Debug.LogWarning("PlayerPrefs HighScore reset to 0");
        }
    }
}
