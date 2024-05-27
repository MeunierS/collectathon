using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLabel : MonoBehaviour
{
    public GameUI gameUI;
    public TMP_Text scoreLabel;
    int lastScore;
    // Start is called before the first frame update
    void OnEnable()
    {
        gameUI.onPickUp.AddListener(UpdateScore);
    }
    void OnDisable(){
        gameUI.onPickUp.RemoveListener(UpdateScore);
    }

    // Update is called once per frame
    void UpdateScore(int value)
    {
        if (lastScore != value){
            scoreLabel.SetText($"You have collected {value} token out of 10 !");
            lastScore = value;
        }
    }
}
