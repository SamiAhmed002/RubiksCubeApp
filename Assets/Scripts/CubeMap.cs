using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    CubeState cubeState;

    public Transform front;
    public Transform back;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set() {
        cubeState = FindFirstObjectByType<CubeState>();

        // Update the cube map with each of the cube's faces 1 at a time
        UpdateMap(cubeState.front, front);
        UpdateMap(cubeState.back, back);
        UpdateMap(cubeState.up, up);
        UpdateMap(cubeState.down, down);
        UpdateMap(cubeState.left, left);
        UpdateMap(cubeState.right, right);
        
    }

    void UpdateMap(List<GameObject> face, Transform side) {
        int i = 0;
        // Update the colour of the corresponding cube map square based on the colour of the face being read
        foreach (Transform map in side) {
            if (face[i].name[0] == 'F') {
                map.GetComponent<Image>().color = Color.green;
            }
            if (face[i].name[0] == 'B') {
                map.GetComponent<Image>().color = Color.blue;
            }
            if (face[i].name[0] == 'U') {
                map.GetComponent<Image>().color = Color.yellow;
            }
            if (face[i].name[0] == 'D') {
                map.GetComponent<Image>().color = Color.white;
            }
            if (face[i].name[0] == 'L') {
                map.GetComponent<Image>().color = Color.red;
            }
            if (face[i].name[0] == 'R') {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }
            i++;
        }
    }
}
