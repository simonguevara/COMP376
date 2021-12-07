using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinalSceneManager : MonoBehaviour
{

    public Text dialogueText;
    Queue<string> sentences;

    private AudioSource audioSource;
    public AudioClip typingClip;

    [SerializeField] GameObject pointLight;

    [SerializeField] GameObject particles;

    [SerializeField] GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        audioSource = GetComponent<AudioSource>();
    }

    public void startDialogue(Dialogue dialogue){
        sentences.Clear();
        //Time.timeScale = 0;
        audioSource.enabled = true;
        audioSource.PlayOneShot(typingClip);
        pointLight.SetActive(true);
        particles.SetActive(true);
        block.SetActive(true);
         Invoke("EndCoroutine", 4f);
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
                yield return null;
            }
           //  TypeSound.Stop();

        }

    public void EndDialogue(){
        GameObject dialogueBox = GameObject.Find("DialogBox");
        //dialogueBox.SetActive(false);
        //Time.timeScale = 1;
        audioSource.Play();
        pointLight.SetActive(true);
        particles.SetActive(true);
        block.SetActive(true);
        
    }

    

    public void EndCoroutine()
    {
            //yield on a new YieldInstruction that waits for 5 seconds.
        GameManager.speedRunMode = true;
       // GameManager.speedrunMode = true;
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
}
