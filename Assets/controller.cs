using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using Image = UnityEngine.UI.Image;

public class controller : MonoBehaviour
{

    public Color desiredColor=new Color(229f / 255f, 184f / 255f, 11f / 255f);
    public Button quitButton;
    public Button exitButtonWin;
    public AudioSource audioDetected;
    public AudioSource audioWin;
    //public GameObject audioDetected;
    public Button collectButton;
    public Text scoreText;
    public Text hintText;
    public static int remainingTreasures=7;
    public GameObject[] targets;
    public int counter=0;
    private bool isDetectionPaused = false;
    public Button startButton;
    public Text instructions;
    public string[] hints=new string[]{"He is a young footballer", 
                                        "it is a high place on earth", 
                                        "it is hard/solid and has many colors",
                                        "one of the popular games",
                                        "running down the wing",
                                        "we find them in forests",
                                        "they are yellow"};


    // Start is called before the first frame update
    public void StartGameButtonOnClick(){
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(true);
        exitButtonWin.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
        audioDetected.Stop();
        audioWin.Stop();
        hintText.text=hints[counter];
        collectButton.gameObject.SetActive(false);
        int score=7-remainingTreasures;
        scoreText.text = "Score: "+ score+"\n"+"Remaining Targets: "+remainingTreasures;
       
    }
    void Start()
    {
        audioDetected.Stop();
        audioWin.Stop();
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        exitButtonWin.gameObject.SetActive(false);
        collectButton.gameObject.SetActive(false);
        instructions.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonOnClick(){

        
        targets[counter].SetActive(false);
        collectButton.gameObject.SetActive(false);
        remainingTreasures--;
        int score=7-remainingTreasures;
        scoreText.text = "Score: "+ score+"\n"+"Remaining Targets: "+remainingTreasures;
        if (remainingTreasures==0){
        
        if (audioWin != null)
        {
            audioWin.Stop(); // Stop any previous audio playback
            audioWin.Play(); // Play the audio
        }
        hintText.text = "All targets collected!";
        //StartCoroutine(CloseGameAfterDelay(4f));
        exitButtonWin.gameObject.SetActive(true);
        StartCoroutine(PauseDetection());
        }
        else{
        if (audioDetected != null)
        {
            audioDetected.Stop(); // Stop any previous audio playback
            audioDetected.Play(); // Play the audio
        }
        hintText.text=hints[++counter];
        StartCoroutine(PauseDetection());}
    }

    public void quickButtonClicked(){
        #if UNITY_EDITOR
        // Exit play mode in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Close the application in a built game (unchanged)
        Application.Quit();
        #endif

        //yield return new WaitForSeconds(1);
        //UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit(); // Close the game
    }

    public void exitButtonClicked(){
        #if UNITY_EDITOR
        // Exit play mode in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Close the application in a built game (unchanged)
        Application.Quit();
        #endif

        //yield return new WaitForSeconds(1);
        //UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit(); // Close the game
    }

    private IEnumerator PauseDetection()
    {
        isDetectionPaused = true;

        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        isDetectionPaused = false;
    }

    public void detected(GameObject detectedTarget){
        if (!isDetectionPaused && targets[counter]==detectedTarget){
        collectButton.GetComponent<Image>().color = desiredColor;
        collectButton.gameObject.SetActive(true);
        hintText.text="";}
        else if (targets[counter]!=detectedTarget)
        {
            StartCoroutine(HideObjectAfterDelay(detectedTarget, 2f)); // Hide the incorrect target after 2 seconds
        }
    }

    private IEnumerator HideObjectAfterDelay(GameObject target, float delay)
    {
        yield return new WaitForSeconds(delay);
        target.SetActive(false); // Hide the target
    }
}
