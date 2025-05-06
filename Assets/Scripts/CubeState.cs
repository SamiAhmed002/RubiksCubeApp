using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeState : MonoBehaviour
{
    public List<GameObject> up = new List<GameObject>();
    public List<GameObject> down = new List<GameObject>();
    public List<GameObject> left = new List<GameObject>();
    public List<GameObject> right = new List<GameObject>();
    public List<GameObject> front = new List<GameObject>();
    public List<GameObject> back = new List<GameObject>();

    public static bool autoRotating = false;
    public static bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp(List<GameObject> cubeSide) {
        // Attach each face's parent to centre piece's parent
        foreach (GameObject face in cubeSide) {
            if (face != cubeSide[4]) {
                face.transform.parent.transform.parent = cubeSide[4].transform.parent;
            }
        }
    }

    public void PutDown(List<GameObject> littleCubes, Transform pivot) {
        // Unparent each of the smaller cubes
        foreach (GameObject littleCube in littleCubes) {
            if (littleCube != littleCubes[4]) {
                littleCube.transform.parent.transform.parent = pivot;
            }
        }
    }

    string GetSideAsString(List<GameObject> side) {
        string sideAsString = "";
        foreach (GameObject face in side) {
            sideAsString += face.name[0].ToString();
        }
        return sideAsString;
    }

    public string GetStateAsString() {
        string stateAsString = "";
        stateAsString += GetSideAsString(up);
        stateAsString += GetSideAsString(right);
        stateAsString += GetSideAsString(front);
        stateAsString += GetSideAsString(down);
        stateAsString += GetSideAsString(left);
        stateAsString += GetSideAsString(back);
        return stateAsString;
    }

}
