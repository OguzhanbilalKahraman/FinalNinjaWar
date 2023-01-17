using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class menu : MonoBehaviour
{


    float top_score;
    void Start(){
        top_score = PlayerPrefs.GetFloat("topScore");
        Debug.Log("TOP SCORE " + top_score);
        
    }

    private void Update()
    {
        top_score = PlayerPrefs.GetFloat("topScore");
        Debug.Log("TOP SCORE " + top_score);
    }
    public void ContinueGame()
    {//save game

        if (top_score<11)
        {
            SceneManager.LoadScene("firstStage");
        }
        else if (top_score>10)
        {
            SceneManager.LoadScene("secondStage");
        }
    }


    public void NewPlayButton()
    {
        SceneManager.LoadScene("firstStage");

    }




}
