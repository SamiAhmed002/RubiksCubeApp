using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Automate : MonoBehaviour
{
    public static List<string> moveList = new List<string>() {};
    private readonly List<string> allMoves = new List<string>() {"F", "B", "U", "D", "L", "R", "F'", "B'", "U'", "D'", "L'", "R'", "F2", "B2", "U2", "D2", "L2", "R2"};
    private CubeState cubeState;
    private ReadCube readCube;
    public GameObject demonstration;
    public TMP_Text demoText;
    private bool shuffle;

    // Start is called before the first frame update
    void Start()
    {
        cubeState = FindFirstObjectByType<CubeState>();
        readCube = FindFirstObjectByType<ReadCube>();
    }

    // Update is called once per frame
    void Update()
    {
        // Perform the first queued move if there is one
        if (moveList.Count > 0 && !CubeState.autoRotating && CubeState.started) {
            Turn(moveList[0]);
            moveList.Remove(moveList[0]);

            if (moveList.Count == 0 && shuffle) {
                demonstration.SetActive(false);
                shuffle = false;
            }
        }
    }

    public void Shuffle() {
        List<string> moves = new List<string>();
        int length = Random.Range(20, 30);
        demonstration.SetActive(true);
        shuffle = true;
        demoText.text = "Shuffling";
        // Assemble a random list of moves to shuffle the cube
        for (int i = 0; i < length; i++) {
            int randomMove = Random.Range(0, allMoves.Count);
            moves.Add(allMoves[randomMove]);
        }
        moveList = moves;
    }

    void Turn(string move) {
        readCube.ReadState();
        CubeState.autoRotating = true;

        // Rotate the appropriate face based on the move passed to the method
        if (move == "F") {
            RotateSide(cubeState.front, -90);
        }
        if (move == "F'") {
            RotateSide(cubeState.front, 90);
        }
        if (move == "F2") {
            RotateSide(cubeState.front, -180);
        }
        if (move == "B") {
            RotateSide(cubeState.back, -90);
        }
        if (move == "B'") {
            RotateSide(cubeState.back, 90);
        }
        if (move == "B2") {
            RotateSide(cubeState.back, -180);
        }
        if (move == "U") {
            RotateSide(cubeState.up, -90);
        }
        if (move == "U'") {
            RotateSide(cubeState.up, 90);
        }
        if (move == "U2") {
            RotateSide(cubeState.up, -180);
        }
        if (move == "D") {
            RotateSide(cubeState.down, -90);
        }
        if (move == "D'") {
            RotateSide(cubeState.down, 90);
        }
        if (move == "D2") {
            RotateSide(cubeState.down, -180);
        }
        if (move == "L") {
            RotateSide(cubeState.left, -90);
        }
        if (move == "L'") {
            RotateSide(cubeState.left, 90);
        }
        if (move == "L2") {
            RotateSide(cubeState.left, -180);
        }
        if (move == "R") {
            RotateSide(cubeState.right, -90);
        }
        if (move == "R'") {
            RotateSide(cubeState.right, 90);
        }
        if (move == "R2") {
            RotateSide(cubeState.right, -180);
        }
    }

    void RotateSide(List<GameObject> side, float angle) {
        // Rotate the face around its centre piece
        PivotRotation pr = side[4].transform.parent.GetComponent<PivotRotation>();
        pr.StartAutoRotate(side, angle);
    }
}
