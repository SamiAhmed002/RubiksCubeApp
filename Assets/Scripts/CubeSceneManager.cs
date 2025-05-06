using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public static class StageManager {
    public static string stage;
}

public class CubeSceneManager : MonoBehaviour
{
    public GameObject leftPanel;
    public GameObject rightPanel;
    public GameObject[] leftPanels;
    public GameObject[] rightPanels;
    public GameObject leftHighlight;
    public GameObject rightHighlight;
    public GameObject prevButton;
    public GameObject nextButton;
    public GameObject target;
    public GameObject quad;
    public GameObject demonstration;
    public TMP_Text demoText;

    int page;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWithDelay());
    }

    IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second

        leftPanel.SetActive(true);
        rightPanel.SetActive(true);

        Automate automate = FindAnyObjectByType<Automate>();

        if (StageManager.stage == "WED") {
            demonstration.SetActive(true);
            demoText.text = "Shuffling";
            leftPanels[0].SetActive(true);
            rightPanels[0].SetActive(true);
            page = 0;
            Automate.moveList.AddRange(new List<string> { "R", "D2", "U2", "F'", "U2", "B2", "L2", "B", "U", "B", "F'", "R'", "U'", "F", "R'", "D2", "B2", "R"});
            StartCoroutine(DemonstrateWED());
        }
        else if (StageManager.stage == "WCO") {
            demonstration.SetActive(true);
            demoText.text = "Shuffling";
            leftPanels[3].SetActive(true);
            rightPanels[3].SetActive(true);
            page = 3;
            Automate.moveList.AddRange(new List<string> { "L2", "U", "F'", "D'", "B2", "L2", "D'", "B2", "R2", "B'", "R2", "D2", "F2", "R'", "F2", "U2", "R"});
            StartCoroutine(DemonstrateWCO());
        }
        else if (StageManager.stage == "SEC") {
            demonstration.SetActive(true);
            demoText.text = "Shuffling";
            leftPanels[4].SetActive(true);
            rightPanels[4].SetActive(true);
            page = 4;
            Automate.moveList.AddRange(new List<string> { "L'", "U", "L", "U", "F", "U'", "F'" });
            StartCoroutine(DemonstrateSEC());
        }
        else if (StageManager.stage == "YED") {
            demonstration.SetActive(true);
            demoText.text = "Shuffling";
            leftPanels[6].SetActive(true);
            rightPanels[6].SetActive(true);
            page = 6;
            Automate.moveList.AddRange(new List<string> { "R'", "U2", "R", "U2", "R", "B2", "R'", "B2", "U2", "L'", "B", "L", "B'"});
            StartCoroutine(DemonstrateYED());
        }
        else if (StageManager.stage == "MED") {
            demonstration.SetActive(true);
            demoText.text = "Shuffling";
            leftPanels[7].SetActive(true);
            rightPanels[7].SetActive(true);
            page = 7;
            Automate.moveList.AddRange(new List<string> { "L'", "U", "L'", "F2", "R", "B2", "R", "D'", "L2", "B2", "R", "F2", "R"});
            StartCoroutine(DemonstrateMED());
        }
        else if (StageManager.stage == "YCO") {
            demonstration.SetActive(true);
            demoText.text = "Shuffling";
            leftPanels[8].SetActive(true);
            rightPanels[8].SetActive(true);
            page = 8;
            Automate.moveList.AddRange(new List<string> { "R'", "F'", "L", "F", "R", "F'", "L", "F'", "R2", "F", "L2", "F'", "R2", "F2"});
            StartCoroutine(DemonstrateYCO());
        }
        else if (StageManager.stage == "FIN") {
            demonstration.SetActive(true);
            demoText.text = "Shuffling";
            leftPanels[9].SetActive(true);
            rightPanels[9].SetActive(true);
            page = 9;
            Automate.moveList.AddRange(new List<string> { "U2", "R", "U2", "R'", "F2", "L", "F'", "R'", "F2", "L'", "F2", "R", "F'"});
            StartCoroutine(DemonstrateFIN());
        }
        else {
            leftPanels[0].SetActive(true);
            rightPanels[0].SetActive(true);
            page = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu() {
        Automate automate = FindAnyObjectByType<Automate>();
        CubeState cubeState = FindAnyObjectByType<CubeState>();
        if (!CubeState.autoRotating) {
            SceneManager.LoadScene("Menu");
        }
    }

    public void SecondLayerPrevButton() {
        if (page > 0) {
            leftPanels[page].SetActive(false);
            rightPanels[page].SetActive(false);
            page -= 1;
            leftPanels[page].SetActive(true);
            rightPanels[page].SetActive(true);
        }    
    }

    public void SecondLayerNextButton() {
        if (page < 10) {
            leftPanels[page].SetActive(false);
            rightPanels[page].SetActive(false);
            page += 1;
            leftPanels[page].SetActive(true);
            rightPanels[page].SetActive(true);
        }
    }

    IEnumerator DemonstrateWED() {
        yield return new WaitForSeconds(8f);

        quad.GetComponent<Renderer>().material.color = Color.blue;

        demoText.text = "Demonstration";

        // Demonstration of step
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-275, 120, 0);
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;    
        yield return new WaitForSeconds(2.5f);
        target.transform.Rotate(0, 90, 0, Space.World);
        yield return new WaitForSeconds(2f);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(2f);
        target.transform.Rotate(0, 90, 0, Space.World);
        yield return new WaitForSeconds(2f);
        rightHighlight.SetActive(false);
        leftHighlight.SetActive(true);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, 30, 0);
        yield return new WaitForSeconds(1f);
        Automate.moveList.Add("B2");
        yield return new WaitForSeconds(2f);
        target.transform.Rotate(0, 180, 0, Space.World);
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(275, 120, 0);
        yield return new WaitForSeconds(2f);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(1f);
        target.transform.Rotate(0, 90, 0, Space.World);
        yield return new WaitForSeconds(1f);
        rightHighlight.SetActive(false);
        leftHighlight.SetActive(true);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, 30, 0);
        yield return new WaitForSeconds(1f);
        Automate.moveList.Add("R2");
        yield return new WaitForSeconds(2f);
        SecondLayerNextButton();
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, 100, 0);
        yield return new WaitForSeconds(2f);
        target.transform.Rotate(180, 0, 0, Space.World);
        yield return new WaitForSeconds(2f);
        leftHighlight.SetActive(true);
        rightHighlight.SetActive(false);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30, 0);
        Automate.moveList.Add("R");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("D'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("F");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("D");
        yield return new WaitForSeconds(1f);
        target.transform.Rotate(180, 0, 0, Space.World);
        SecondLayerNextButton();
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, 50, 0);
        yield return new WaitForSeconds(2f);
        target.transform.Rotate(0, 180, 0, Space.World);
        yield return new WaitForSeconds(2f);
        target.transform.Rotate(180, 0, 0, Space.World);
        yield return new WaitForSeconds(2f);
        leftHighlight.SetActive(true);
        rightHighlight.SetActive(false);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-275, 30, 0);
        Automate.moveList.Add("B'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, 30f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(275, 30f, 0);
        Automate.moveList.Add("B");
        yield return new WaitForSeconds(1f);
        target.transform.Rotate(180, 0, 0, Space.World);
        SecondLayerPrevButton();
        SecondLayerPrevButton();
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(275, 120, 0);
        yield return new WaitForSeconds(2f);
        leftHighlight.SetActive(true);
        rightHighlight.SetActive(false);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, 30, 0);
        Automate.moveList.Add("L2");
        yield return new WaitForSeconds(2f);
        SecondLayerNextButton();
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, 100, 0);
        yield return new WaitForSeconds(2f);
        target.transform.Rotate(180, 0, 0, Space.World);
        yield return new WaitForSeconds(2f);
        leftHighlight.SetActive(true);
        rightHighlight.SetActive(false);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30, 0);
        Automate.moveList.Add("L");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("D'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("B");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("D");
        yield return new WaitForSeconds(1f);
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, -170, 0);
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;    
        yield return new WaitForSeconds(2.5f);
        rightHighlight.SetActive(false);

        // Solve + reset of step
        demoText.text = "Resetting";
        SolveCube SolveCube = FindAnyObjectByType<SolveCube>();
        SolveCube.Solve();
        quad.GetComponent<Renderer>().material.color = Color.black;
        Automate.moveList.AddRange(new List<string> { "R", "D2", "U2", "F'", "U2", "B2", "L2", "B", "U", "B", "F'", "R'", "U'", "F", "R'", "D2", "B2", "R" });
        yield return new WaitForSeconds(16.5f);
        demonstration.SetActive(false);
    }

    IEnumerator DemonstrateWCO() {
        yield return new WaitForSeconds(8f);

        quad.GetComponent<Renderer>().material.color = Color.blue;

        demoText.text = "Demonstration";

        // Demonstration of step
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, 70, 0);
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;    
        yield return new WaitForSeconds(2.5f);
        leftHighlight.SetActive(true);
        rightHighlight.SetActive(false);    
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("R");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("R'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("R");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("R'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("R");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("R'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("R");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("R'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("R");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("R'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(2f);
        target.transform.Rotate(0, -90, 0, Space.World);
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);    
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(340, 70f, 0);
        yield return new WaitForSeconds(2f);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(2f);
        leftHighlight.SetActive(true);
        rightHighlight.SetActive(false);    
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("F");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("F'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(1f);
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);    
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(340, 70f, 0);
        target.transform.Rotate(0, -180, 0, Space.World);
        yield return new WaitForSeconds(2f);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(2f);
        leftHighlight.SetActive(true);
        rightHighlight.SetActive(false);    
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("B");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("B'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(2f);
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);    
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(340, 70f, 0);
        target.transform.Rotate(0, 90, 0, Space.World);
        yield return new WaitForSeconds(2f);
        Automate.moveList.Add("U2");
        yield return new WaitForSeconds(2f);
        leftHighlight.SetActive(true);
        rightHighlight.SetActive(false);    
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("L");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("L'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(1f);
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, -185, 0);
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;    
        yield return new WaitForSeconds(2.5f);
        rightHighlight.SetActive(false);

        // Solve + reset of step
        demoText.text = "Resetting";
        SolveCube SolveCube = FindAnyObjectByType<SolveCube>();
        SolveCube.Solve();
        quad.GetComponent<Renderer>().material.color = Color.black;
        Automate.moveList.AddRange(new List<string> { "L2", "U", "F'", "D'", "B2", "L2", "D'", "B2", "R2", "B'", "R2", "D2", "F2", "R'", "F2", "U2", "R" });
        yield return new WaitForSeconds(17.5f);
        demonstration.SetActive(false);
    }

    IEnumerator DemonstrateSEC() {

        yield return new WaitForSeconds(2.5f);

        quad.GetComponent<Renderer>().material.color = Color.blue;

        demoText.text = "Demonstration";

        // Demonstration of step
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, 100, 0);
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;    
        yield return new WaitForSeconds(2.5f);
        target.transform.Rotate(0, -90, 0, Space.World);
        yield return new WaitForSeconds(2f);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(2f);
        rightHighlight.SetActive(false);
        leftHighlight.SetActive(true);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 152.5f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 152.5f, 0);
        Automate.moveList.Add("F");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 152.5f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 152.5f, 0);
        Automate.moveList.Add("F'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, -88, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, -88, 0);
        Automate.moveList.Add("L'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, -88, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, -88, 0);
        Automate.moveList.Add("L");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, -170, 0);
        yield return new WaitForSeconds(3f);
        rightHighlight.SetActive(false);

        // Solve + reset of step
        demoText.text = "Resetting";
        SolveCube SolveCube = FindAnyObjectByType<SolveCube>();
        SolveCube.Solve();
        quad.GetComponent<Renderer>().material.color = Color.black;
        Automate.moveList.AddRange(new List<string> { "L'", "U", "L", "U", "F", "U'", "F'" });
        yield return new WaitForSeconds(11f);
        demonstration.SetActive(false);
    }

    IEnumerator DemonstrateYED() {

        yield return new WaitForSeconds(5f);

        quad.GetComponent<Renderer>().material.color = Color.blue;

        demoText.text = "Demonstration";

        // Demonstration of step
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-325, 110, 0);
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;    
        yield return new WaitForSeconds(2.5f);
        Automate.moveList.Add("U2");
        yield return new WaitForSeconds(2f);
        rightHighlight.SetActive(false);
        leftHighlight.SetActive(true);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 152.5f, 0);
        Automate.moveList.Add("F");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 152.5f, 0);
        Automate.moveList.Add("R");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 152.5f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 152.5f, 0);
        Automate.moveList.Add("R'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, -88, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, -88, 0);
        Automate.moveList.Add("F'");
        yield return new WaitForSeconds(3f);
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(325, 110, 0);
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(2.5f);
        rightHighlight.SetActive(false);
        leftHighlight.SetActive(true);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 152.5f, 0);
        Automate.moveList.Add("F");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 152.5f, 0);
        Automate.moveList.Add("R");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 152.5f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 152.5f, 0);
        Automate.moveList.Add("R'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, -88, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, -88, 0);
        Automate.moveList.Add("F'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, -180, 0);
        yield return new WaitForSeconds(3f);
        rightHighlight.SetActive(false);

        // Solve + reset of step
        demoText.text = "Resetting";
        SolveCube SolveCube = FindAnyObjectByType<SolveCube>();
        SolveCube.Solve();
        quad.GetComponent<Renderer>().material.color = Color.black;
        Automate.moveList.AddRange(new List<string> { "R'", "U2", "R", "U2", "R", "B2", "R'", "B2", "U2", "L'", "B", "L", "B'" });
        yield return new WaitForSeconds(13.5f);
        demonstration.SetActive(false);
        
    }

    IEnumerator DemonstrateMED() {
        yield return new WaitForSeconds(6f);

        quad.GetComponent<Renderer>().material.color = Color.blue;

        demoText.text = "Demonstration";

        // Demonstration of step
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(360, 110, 0);
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;    
        yield return new WaitForSeconds(2.5f);
        target.transform.Rotate(0, 180, 0, Space.World);
        yield return new WaitForSeconds(2f);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(2f);
        rightHighlight.SetActive(false);

        leftHighlight.SetActive(true);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 150f, 0);
        Automate.moveList.Add("R");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 150f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 150f, 0);
        Automate.moveList.Add("R'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 150f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, -90f, 0);
        Automate.moveList.Add("R");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, -90f, 0);
        Automate.moveList.Add("U2");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, -90f, 0);
        Automate.moveList.Add("R'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, -90f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);

        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, -180, 0);
        yield return new WaitForSeconds(3f);
        rightHighlight.SetActive(false);

        // Solve + reset of step
        demoText.text = "Resetting";
        SolveCube SolveCube = FindAnyObjectByType<SolveCube>();
        SolveCube.Solve();
        quad.GetComponent<Renderer>().material.color = Color.black;
        Automate.moveList.AddRange(new List<string> { "L'", "U", "L'", "F2", "R", "B2", "R", "D'", "L2", "B2", "R", "F2", "R" });
        yield return new WaitForSeconds(14f);
        demonstration.SetActive(false);
    }

    IEnumerator DemonstrateYCO() {
        yield return new WaitForSeconds(6f);

        quad.GetComponent<Renderer>().material.color = Color.blue;

        demoText.text = "Demonstration";

        // Demonstration of step
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(360, 110, 0);
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;    
        yield return new WaitForSeconds(2.5f);
        target.transform.Rotate(0, 180, 0, Space.World);
        yield return new WaitForSeconds(2f);
        rightHighlight.SetActive(false);

        leftHighlight.SetActive(true);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 150f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 150f, 0);
        Automate.moveList.Add("L");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 150f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 150f, 0);
        Automate.moveList.Add("R'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, -90f, 0);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, -90f, 0);
        Automate.moveList.Add("L'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, -90f, 0);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, -90f, 0);
        Automate.moveList.Add("R");
        yield return new WaitForSeconds(0.5f);

        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-180, -180, 0);
        yield return new WaitForSeconds(3f);
        target.transform.Rotate(0, 180, 0, Space.World);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(180, -180, 0);
        yield return new WaitForSeconds(3f);
        rightHighlight.SetActive(false);

        // Solve + reset of step
        demoText.text = "Resetting";
        SolveCube SolveCube = FindAnyObjectByType<SolveCube>();
        SolveCube.Solve();
        target.transform.Rotate(0, 180, 0, Space.World);
        quad.GetComponent<Renderer>().material.color = Color.black;
        Automate.moveList.AddRange(new List<string> { "R'", "F'", "L", "F", "R", "F'", "L", "F'", "R2", "F", "L2", "F'", "R2", "F2" });
        yield return new WaitForSeconds(13f);
        demonstration.SetActive(false);
    }

    IEnumerator DemonstrateFIN() {
        yield return new WaitForSeconds(6f);

        quad.GetComponent<Renderer>().material.color = Color.blue;

        demoText.text = "Demonstration";

        // Demonstration of step
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, 110, 0);
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;    
        yield return new WaitForSeconds(2.5f);
        target.transform.Rotate(-180, 0, 0, Space.World);
        yield return new WaitForSeconds(2f);
        rightHighlight.SetActive(false);

        leftHighlight.SetActive(true);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("L");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("D");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("L'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("D'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("L");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("D");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("L'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("D'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("L");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("D");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("L'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("D'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("L");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("D");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("L'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("D'");
        yield return new WaitForSeconds(1f);
        SecondLayerNextButton();
        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, 80, 0);
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rightHighlight.GetComponent<Image>().color = Color.green;    
        yield return new WaitForSeconds(2.5f);
        Automate.moveList.Add("U'");
        yield return new WaitForSeconds(3f);
        rightHighlight.SetActive(false);
        leftHighlight.SetActive(true);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("L");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("D");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("L'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("D'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-375, 30f, 0);
        Automate.moveList.Add("L");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(-125, 30f, 0);
        Automate.moveList.Add("D");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(125, 30f, 0);
        Automate.moveList.Add("L'");
        yield return new WaitForSeconds(0.5f);
        leftHighlight.GetComponent<RectTransform>().localPosition = new Vector3(375, 30f, 0);
        Automate.moveList.Add("D'");
        yield return new WaitForSeconds(0.5f);

        leftHighlight.SetActive(false);
        rightHighlight.SetActive(true);
        rightHighlight.GetComponent<RectTransform>().localPosition = new Vector3(0, -180, 0);
        yield return new WaitForSeconds(2f);
        Automate.moveList.Add("U");
        yield return new WaitForSeconds(3f);
        rightHighlight.SetActive(false);

        // Solve + reset of step
        demoText.text = "Resetting";
        SecondLayerPrevButton();
        SolveCube SolveCube = FindAnyObjectByType<SolveCube>();
        SolveCube.Solve();
        target.transform.Rotate(180, 180, 0, Space.World);
        quad.GetComponent<Renderer>().material.color = Color.black;
        Automate.moveList.AddRange(new List<string> { "U2", "R", "U2", "R'", "F2", "L", "F'", "R'", "F2", "L'", "F2", "R", "F'" });
        yield return new WaitForSeconds(13f);
        demonstration.SetActive(false);
    }

    IEnumerator WaitTwoSeconds()
    {
        yield return new WaitForSeconds(2f);
    }

}
