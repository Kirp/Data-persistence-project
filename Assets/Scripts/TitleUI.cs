using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{

    public Text HighScoreNameText;
    public Text HighScoreScoreText;

    public InputField userNameIF;

    public void PlayerWantsToGame()
    {
        //Debug.Log(userNameIF.text);
        if(userNameIF.text == "")
        {
            userNameIF.text = "Player1";
        }

        ScoreKeeper.Instance.CurrentName = userNameIF.text;

        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        UpdateHighScoreList();
    }

    public void UpdateHighScoreList() {
        HighScoreNameText.text = ScoreKeeper.Instance.HighScorer;
        HighScoreScoreText.text = ""+ScoreKeeper.Instance.HighScorerScore;
    }


}
