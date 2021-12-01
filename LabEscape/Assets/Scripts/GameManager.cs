using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    public void loadNextLevel()
    {
        if(isGadgetFound)
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
    }

    private void Update()
    {
        //Check if player is dead
        if(playerScript.health <= 0)
        {
            int curretnSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(curretnSceneIndex, LoadSceneMode.Single);
        }
    }


    //DO LEVEL START / END DIALOG STORY STUFF
}
