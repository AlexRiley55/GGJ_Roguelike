using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int score = 0;

    GameObject[] levelSegments;
    Vector3 nextSegmentStart = new Vector3();

    PlayerController playerController;

    static GameManager gameManager;

    public static GameManager getGame() {
        return gameManager;
    }

    // Start is called before the first frame update
    void Start() {
        gameManager = gameObject.GetComponent(typeof(GameManager)) as GameManager;

        levelSegments = Resources.LoadAll<GameObject>("Prefabs/LevelSegments") as GameObject[];
        Debug.Log("Loaded: " + levelSegments.Length  + "Segments");

        for (int i = 0; i < 1; i++) {
            generateSegment();
        }
    }

    // Update is called once per frame
    void Update() {
        playerController = PlayerController.getPlayer();

        if (nextSegmentStart.x - playerController.gameObject.transform.position.x < 50f) { //TODO: delete old segments from the front? 
            generateSegment();
        }
    }

    void generateSegment () {
        int randIndex = Random.Range(0, levelSegments.Length);
        Debug.Log("Generated Segment: " + randIndex);
        GameObject prefabToInstanciate = levelSegments[randIndex];
        Instantiate(prefabToInstanciate, nextSegmentStart, Quaternion.identity);

        //move the next spawn up by the length of the segment we just spawned
        nextSegmentStart.x += (prefabToInstanciate.GetComponent(typeof(LevelSegment)) as LevelSegment).length;
    }
}
