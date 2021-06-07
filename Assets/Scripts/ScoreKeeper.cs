using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance;

    public string CurrentName;
    public string HighScorer;
    public int HighScorerScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScoreData();
    }

    public void EnterCurrentName(string name)
    {
        CurrentName = name;
    }
    


    [System.Serializable]
    class HighScoreData
    {
        public string highScorer;
        public int highScorerScore;
    }

    public void SaveHighScoreData()
    {
        HighScoreData data = new HighScoreData();
        data.highScorer = HighScorer;
        data.highScorerScore = HighScorerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath+"/highscore.json", json);

    }



    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            //load it up
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            HighScorer = data.highScorer;
            HighScorerScore = data.highScorerScore;

        }else
        {
            //load dummy data
            HighScorer = "Player1";
            HighScorerScore = 0;
        }
    }

}
