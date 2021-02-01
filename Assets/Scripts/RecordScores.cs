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

    void Awake() {
        recordScores = gameObject.GetComponent(typeof(RecordScores)) as RecordScores;
    }
    
    // Start is called before the first frame update
    void Start() {
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
