using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;
    
    
    public TextMeshProUGUI ScoreText;
    //public TextMeshProUGUI HighScoreText;
    

    public int score;
  // public int highscore = 0;
    // Start is called before the first frame update
    private void Awake()
    {
       instance = this;
    }
    void Start()
    {
      // PlayerPrefs.SetInt("highscore",0);
        //highscore = PlayerPrefs.GetInt("highscore", 0);
        ScoreText.text = score.ToString() + ": POINTS";
        //HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
    }
    private void Update()
    {
        if (score <= 0) 
        { 
        score = 0;
        }
        ScoreText.text = score.ToString() + ": POINTS";
    }

    public void AddPoints(int gainPoints)
    {
        score += gainPoints;
        ScoreText.text = score.ToString() + ": POINTS";
     
    }
    public void DeletePoints(int cost)
    {
        score -= cost;
        ScoreText.text = score.ToString() + ": POINTS";
    }

    
}
