using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    private GameObject player;
    private PlayerSam playerScript;

    public bool isGadgetFound = false;

    private GameObject dialogueBox;
    private DialogueManager dialogueManager;
    public Dialogue dialogue;

    public Dialogue pickupNotFoundDialogue;

    //For speedrun mode
    public static bool speedRunMode = false;

    public static float totalTime = 0.0f;
    public float currentLvlTime = 0.0f;

    public Text timerText;
    public Text levelTimerText;

    public void loadNextLevel()
    {
        if (isGadgetFound)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            //Display message saying that gadget is not found or something
        }
    }
    public void loadLevel(int level)
    {
        if (isGadgetFound)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            //Display message saying that gadget is not found or something
        }
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerSam>();
        dialogueBox = GameObject.FindGameObjectWithTag("DialogueBox");
        dialogueManager = FindObjectOfType<DialogueManager>();
        Time.timeScale = 1;
        if (level == 1)
            totalTime = 0f;

        //For speedrun mode
        if (speedRunMode)
        {
            //Disable pickups
            GameObject pickup = GameObject.FindWithTag("Pickup");
            pickup.SetActive(false);

            //Disable dialogs
            GameObject[] dialogs = GameObject.FindGameObjectsWithTag("Dialogue");
            for(int i = 0; i < dialogs.Length; i++)
            {
                dialogs[i].SetActive(false);
            }
            GameObject[] dialogBoxes = GameObject.FindGameObjectsWithTag("DialogueBox");
            for (int i = 0; i < dialogBoxes.Length; i++)
            {
                dialogBoxes[i].SetActive(false);
            }


            //Enable all abilities
            playerScript.hasBoots = true;
            playerScript.hasShield = true;
            playerScript.hasEMP = true;
            playerScript.hasHazmat = true;
            playerScript.hasRecall = true;
            playerScript.hasPortalGun = true;

            isGadgetFound = true;

           

        }
        else
        {
            GameObject[] timers = GameObject.FindGameObjectsWithTag("Timer");
            for (int i = 0; i < timers.Length; i++)
            {
                timers[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        //Check if player is dead
        if (playerScript.health <= 0)
        {
            int curretnSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(curretnSceneIndex, LoadSceneMode.Single);
        }

        updateTimers();
    }

    private void updateTimers()
    {
        totalTime += Time.deltaTime;
        currentLvlTime += Time.deltaTime;


        //Update global timer
        float minutes = Mathf.Floor(totalTime / 60);
        float seconds = Mathf.RoundToInt(totalTime % 60);

        string minustesStr = "";
        string secondsStr = "";

        if (minutes < 10)
        {
            minustesStr = "0" + minutes.ToString();
        }
        else
        {
            minustesStr = minutes.ToString();
        }
        if (seconds < 10)
        {
            secondsStr = "0" + Mathf.RoundToInt(seconds).ToString();
        }
        else
        {
            secondsStr = Mathf.RoundToInt(seconds).ToString();
        }

        timerText.text = "Total Time: "+ minustesStr + " : " + secondsStr;

        //Update level timer
        minutes = Mathf.Floor(currentLvlTime / 60);
        seconds = Mathf.RoundToInt(currentLvlTime % 60);

        minustesStr = "";
        secondsStr = "";

        if (minutes < 10)
        {
            minustesStr = "0" + minutes.ToString();
        }
        else
        {
            minustesStr = minutes.ToString();
        }
        if (seconds < 10)
        {
            secondsStr = "0" + Mathf.RoundToInt(seconds).ToString();
        }
        else
        {
            secondsStr = Mathf.RoundToInt(seconds).ToString();
        }

        levelTimerText.text = "Current Level Time: " + minustesStr + " : " + secondsStr;
    }

    public void findGadget()
    {
        isGadgetFound = true;
    }


    //DO LEVEL START / END DIALOG STORY STUFF
}