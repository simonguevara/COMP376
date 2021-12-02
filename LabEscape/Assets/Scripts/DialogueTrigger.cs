using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private CircleCollider2D collider;
    private SpriteRenderer sprite;
    [SerializeField] GameObject dialogueBox;

    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        /*dialogueBox = GameObject.FindWithTag("DialogueBox");
        if (GameObject.FindWithTag("DialogueBox") == null)
            Debug.Log("Can find dialogue box");
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "Player")
        {
            triggerDialogue();
        }
    }



    public void triggerDialogue(){

        Debug.Log("dialogueBox set to true");
        dialogueBox.SetActive(true);
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);

        if (collider != null)
            collider.enabled = false;
        if (sprite != null)
            sprite.enabled = false;
    }
}
