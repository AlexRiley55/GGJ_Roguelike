using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordScores : MonoBehaviour {
    public GameObject highScoreObject;
    public GameObject scoreObject;

    public Text highScoreText;
    public Text scoreText;

    static RecordScores recordScores;

    public static RecordScores getRecordScores() {
        return recordScores;
    }

    // Start is called before the first frame update
    void Start() {
        recordScores = gameObject.GetComponent(typeof(RecordScores)) as RecordScores;

        highScoreText = highScoreObject.GetComponent(typeof(Text)) as Text;
        scoreText = scoreObject.GetComponent(typeof(Text)) as Text;
    }

    public void setScore(int score) {
        scoreText.text = score.ToString(); ;
    }

    public void setHighScore(int score) {
        highScoreText.text = score.ToString(); ;
    }
}
