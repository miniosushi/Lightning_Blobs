using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    static public string addPoints = "n";
    // variable to clarify the size of the blob
    static public int blobNumber = 0;
    private Text uiText;
    
    void Start() {
        uiText = GetComponent<Text>();
    }

    void Update() {
        addScore();
        uiText.text = score.ToString("#,0");
    }

    void addScore(){
        if(addPoints == "y"){
            // score will depend on the size of the combining 
            // blobs. Larger blobs = higher score
            score += ((blobNumber + 1) * 100);
            addPoints = "n";
        }
    }
}