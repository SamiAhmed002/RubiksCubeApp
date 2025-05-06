using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject learnMenu;

    // Start is called before the first frame update
    void Start()
    {
        loadMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Switch between menus
    public void loadMainMenu() {
        mainMenu.SetActive(true);
        learnMenu.SetActive(false);
    }

    public void loadLearnMenu() {
        mainMenu.SetActive(false);
        learnMenu.SetActive(true);
    }


    // Load cube scene and start based on option chosen
    public void WhiteEdges() {
        StageManager.stage = "WED";
        SceneManager.LoadScene("SampleScene");
    }

    public void WhiteCorners() {
        StageManager.stage = "WCO";
        SceneManager.LoadScene("SampleScene");
    }

    public void SecondLayer() {
        StageManager.stage = "SEC";
        SceneManager.LoadScene("SampleScene");
    }

    public void YellowEdges() {
        StageManager.stage = "YED";
        SceneManager.LoadScene("SampleScene");
    }

    public void MatchEdges() {
        StageManager.stage = "MED";
        SceneManager.LoadScene("SampleScene");
    }

    public void YellowCorners() {
        StageManager.stage = "YCO";
        SceneManager.LoadScene("SampleScene");
    }

    public void FinalStep() {
        StageManager.stage = "FIN";
        SceneManager.LoadScene("SampleScene");
    }

    // Free play option
    public void LoadFreePlay() {
        StageManager.stage = "FRE";
        SceneManager.LoadScene("SampleScene");
    }
}
