using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public AudioSource TypeSound;
    public Text dialogueText;
    Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        //TypeSound = GetComponent<AudioSource>();
    }

    public void startDialogue(Dialogue dialogue){
        sentences.Clear();

        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if ( sentences.Count == 0){
            EndDialogue();
            return;
        }
       
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

     IEnumerator TypeSentence (string sentence){
        // TypeSound.Play();

            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray()){
                dialogueText.text += letter;
                yield return new WaitForSeconds(.05f);
            }
           //  TypeSound.Stop();

        }

    public void EndDialogue(){
        GameObject dialogueBox = GameObject.Find("DialogBox");
        dialogueBox.SetActive(false);
    }
}
