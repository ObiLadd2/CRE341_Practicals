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
    

    public int score = 0;
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
        ScoreText.text =   "POINTS: " + score.ToString();
        //HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
    }
   

    public void AddPoints()
    {
        score += 100;
        ScoreText.text = score.ToString() + ": POINTS";
      //if(highscore < score)
      //{
      //    PlayerPrefs.SetInt("highscore", score);
      //}

    }
    public void DeletePoints()
    {
        score -= 100;
        ScoreText.text = score.ToString() + ": POINTS";
    }

    
}
