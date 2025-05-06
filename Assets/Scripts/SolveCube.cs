using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kociemba;

public class SolveCube : MonoBehaviour
{

    public ReadCube readCube;
    public CubeState cubeState;
    private bool init = true;
    
    // Start is called before the first frame update
    void Start()
    {
        readCube = FindFirstObjectByType<ReadCube>();
        cubeState = FindFirstObjectByType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeState.started && init) {
            init = false;
            Solve();
        }
    }

    public void Solve() {
        readCube.ReadState();

        string moveString = cubeState.GetStateAsString();
        print(moveString);

        string info = "";

        string solution = Search.solution(moveString, out info);

        List<string> solutionList = StringToList(solution);

        Automate.moveList = solutionList;

        print(info);
        
    }

    List<string> StringToList(string solution) {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }
}
