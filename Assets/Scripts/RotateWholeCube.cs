using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    Vector3 previousMousePosition;
    Vector3 mouseDelta;

    public GameObject target;
    float speed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
        Drag();
    }

    void Drag() {
        if (Input.GetMouseButton(1)) {
            mouseDelta = Input.mousePosition - previousMousePosition;
            mouseDelta *= 0.1f;
            transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
        }
        else {
            if (transform.rotation != target.transform.rotation) {
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        }
        previousMousePosition = Input.mousePosition;
    }

    void Swipe() {
        // Track initial mouse position when left click is held down
        if (Input.GetMouseButtonDown(1)) {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        // Track final mouse position when left click is released
        if (Input.GetMouseButtonUp(1)) {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();
            
            // Rotate the cube based on the swipe performed by the user
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                target.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                target.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (currentSwipe.y > 0 && currentSwipe.x < 0f) {
                target.transform.Rotate(90, 0, 0, Space.World);
            }
            else if (currentSwipe.y > 0 && currentSwipe.x > 0f) {
                target.transform.Rotate(0, 0, -90, Space.World);
            }
            else if (currentSwipe.y < 0 && currentSwipe.x < 0f) {
                target.transform.Rotate(0, 0, 90, Space.World);
            }
            else if (currentSwipe.y < 0 && currentSwipe.x > 0f) {
                target.transform.Rotate(-90, 0, 0, Space.World);
            }
        }
    }
}
