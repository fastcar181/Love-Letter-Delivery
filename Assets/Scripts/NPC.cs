using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    public float wordSpeed;
    public bool playerIsClose;

    private void Start()
    {
        dialoguePanel.SetActive(false); // Default hide the dialogue panel
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is close enough and presses E on the NPC, the dialogue will begin
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if(!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                index = 0;
                typingCoroutine = StartCoroutine(Typing());
            }
        }
        // Continue the dialogue
        if(dialoguePanel.activeInHierarchy && Input.anyKeyDown)
        {
            // If button is pressed mid dialogue, stop typing it
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = dialogue[index];
                isTyping = false;
            }
            // If dialogue is finished, move on to the next one
            else
            {
                NextLine();
            }
        }
    }
    
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    // Typing effect
    IEnumerator Typing()
    {
        isTyping = true;
        dialogueText.text = "";
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        isTyping = false;
    }

    public void NextLine()
    {
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            typingCoroutine = StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    // These functions set the boolean that checks if a player is close enough
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
