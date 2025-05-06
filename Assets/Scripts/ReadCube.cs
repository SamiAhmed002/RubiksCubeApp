using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCube : MonoBehaviour
{
    public Transform tUp;
    public Transform tDown;
    public Transform tLeft;
    public Transform tRight;
    public Transform tFront;
    public Transform tBack;



    private List<GameObject> rayUp = new List<GameObject>();
    private List<GameObject> rayDown = new List<GameObject>();
    private List<GameObject> rayLeft = new List<GameObject>();
    private List<GameObject> rayRight = new List<GameObject>();
    private List<GameObject> rayFront = new List<GameObject>();
    private List<GameObject> rayBack = new List<GameObject>();
    

    private int layerMask = 1 << 8;
    CubeState cubeState;
    CubeMap cubeMap;
    public GameObject emptyGO;

    // Start is called before the first frame update
    void Start()
    {
        SetRayTransform();

        cubeState = FindFirstObjectByType<CubeState>();
        cubeMap = FindFirstObjectByType<CubeMap>();

        ReadState();
        CubeState.started = true;

                 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReadState() {
        cubeState = FindFirstObjectByType<CubeState>();
        cubeMap = FindFirstObjectByType<CubeMap>();

        // Set state of each position in each side to read colour of each
        cubeState.up = ReadFace(rayUp, tUp);
        cubeState.down = ReadFace(rayDown, tDown);
        cubeState.left = ReadFace(rayLeft, tLeft);
        cubeState.right = ReadFace(rayRight, tRight);
        cubeState.front = ReadFace(rayFront, tFront);
        cubeState.back = ReadFace(rayBack, tBack);

        cubeMap.Set();
    }

    void SetRayTransform() {
        // Build the ray lists for each of the cube's faces
        rayUp = Rays(tUp, new Vector3(90, 90, 0));
        rayDown = Rays(tDown, new Vector3(270, 90, 0));
        rayLeft = Rays(tLeft, new Vector3(0, 180, 0));
        rayRight = Rays(tRight, new Vector3(0, 0, 0));
        rayFront = Rays(tFront, new Vector3(0, 90, 0));
        rayBack = Rays(tBack, new Vector3(0, 270, 0));
        
    }

    List<GameObject> Rays(Transform rayTransform, Vector3 direction) {
        int rayCount = 0;
        List<GameObject> rays = new List<GameObject>();

        // Build a 3x3 ray grid with ray[0] being top left and ray[8] being bottom right
        for (int y = 1; y > -2; y--) {
            for (int x = -1; x < 2; x++) {
                Vector3 startPos = new Vector3(rayTransform.localPosition.x + x, rayTransform.localPosition.y + y, rayTransform.localPosition.z);
                GameObject rayStart = Instantiate(emptyGO, startPos, Quaternion.identity, rayTransform);
                rayStart.name = rayCount.ToString();
                rays.Add(rayStart);
                rayCount++;
            }
        }
        rayTransform.localRotation = Quaternion.Euler(direction);
        return rays;
    }

    public List<GameObject> ReadFace(List<GameObject> rayStarts, Transform rayTransform) {

        List<GameObject> facesHit = new List<GameObject>();

        foreach (GameObject rayStart in rayStarts) { 

            Vector3 ray = rayStart.transform.position;
            RaycastHit hit;        

            // If ray intersects one of the objects in layerMask
            if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, layerMask)) {
                Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);
                facesHit.Add(hit.collider.gameObject);
            }
            else {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }
    
        
        return facesHit;
    }
}
