using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    Vector3 origin = new Vector3(); //0,0,0
    Vector3 playerSpawn = new Vector3(6,2.6f,0);

    public int highScore = 0;
    public int score = 0;

    GameObject[] levelSegments;
    Vector3 nextSegmentStart;

    Queue<GameObject> loadedFrames = new Queue<GameObject>();

    PlayerController playerController;
    public GameObject playerObject;
    public GameObject virtualCam;

    static GameManager gameManager;

    public static GameManager getGame() {
        return gameManager;
    }

    // Start is called before the first frame update
    void Start() {
        gameManager = gameObject.GetComponent(typeof(GameManager)) as GameManager;
        nextSegmentStart = origin;

        instanciateSpawn();
        instanciatePlayer();

        levelSegments = Resources.LoadAll<GameObject>("Prefabs/LevelSegments") as GameObject[];
        Debug.Log("Loaded: " + levelSegments.Length  + "Segments");
    }

    // Update is called once per frame
    void Update() {
        //playerController = PlayerController.getPlayer();

        if (nextSegmentStart.x - playerObject.transform.position.x < 50f) { //TODO: delete old segments from the front? 
            generateSegment();
        }
    }

    void generateSegment () {
        int randIndex = Random.Range(0, levelSegments.Length);
        Debug.Log("Generated Segment: " + randIndex);
        GameObject prefabToInstanciate = levelSegments[randIndex];
        GameObject loadedFrame = Instantiate(prefabToInstanciate, nextSegmentStart, Quaternion.identity);
        loadedFrames.Enqueue(loadedFrame);

        //move the next spawn up by the length of the segment we just spawned
        nextSegmentStart.x += (prefabToInstanciate.GetComponent(typeof(LevelSegment)) as LevelSegment).length;
        freeOldFrames();
    }

    public void addScore() {
        score++;
        if (score > highScore) {
            highScore++;
        }
    }

    public void restart() {
        GameObject _player = playerObject;//playerController.gameObject;
        CharacterController cc = playerObject.GetComponent(typeof(CharacterController)) as CharacterController;
        cc.enabled = false;
        _player.transform.position = playerSpawn;
        cc.enabled = true;
        playerController.reset();

        foreach (GameObject frame in loadedFrames) {
            Destroy(frame);
        }

        loadedFrames.Clear();

        nextSegmentStart = origin;
        instanciateSpawn();

        score = 0;
    }

    void instanciateSpawn() {
        GameObject spawnPrefab = Resources.Load<GameObject>("Prefabs/Spawn") as GameObject;
        GameObject spawn = Instantiate(spawnPrefab, origin, Quaternion.identity);
        loadedFrames.Enqueue(spawn);
        //move the next spawn up by the length of the segment we just spawned
        nextSegmentStart.x += (spawnPrefab.GetComponent(typeof(LevelSegment)) as LevelSegment).length;
    }

    void instanciatePlayer() {
        GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Player") as GameObject;
        GameObject player = Instantiate(playerPrefab, playerSpawn, Quaternion.identity);
        playerObject = player;
        virtualCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = playerObject.transform;

        player.name = "Player";
    }

    void freeOldFrames() {
        while (loadedFrames.Count > 5) {
            GameObject removedFrame = loadedFrames.Dequeue();
            removedFrame.GetComponent<ParallaxBackground>().enabled = false;
            Destroy(removedFrame);
            //TODO: move the milky blackness
        }
    }
}
