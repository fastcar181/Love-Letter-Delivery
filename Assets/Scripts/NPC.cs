using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject DialoguePanel;
    public Text DialogueText;
    public string[] Dialogue;
    private int Index;
    private bool IsTyping = false;
    private Coroutine TypingCoroutine;

    public float WordSpeed;
    public bool IsClose;

    public GameObject ChoicePanel;
    public Button GiveItemInHand;
    public Button Exit;

    public HotbarManager Hotbar;
    public string NPCID {  get; private set; }

    private void Start()
    {
        NPCID ??= GlobalHelper.generateUniqueID(gameObject);
        DialoguePanel.SetActive(false); // Default hide the dialogue panel
        ChoicePanel.SetActive(false);
        Hotbar = FindAnyObjectByType<HotbarManager>();
        GiveItemInHand.onClick.AddListener(GiveItem);
        Exit.onClick.AddListener(ExitDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is close enough and presses E on the NPC, the dialogue will begin
        if(Input.GetKeyDown(KeyCode.E) && IsClose)
        {
            if(!DialoguePanel.activeInHierarchy)
            {
                DialoguePanel.SetActive(true);
                Index = 0;
                TypingCoroutine = StartCoroutine(Typing());
            }
        }
        // Continue the dialogue
        if(DialoguePanel.activeInHierarchy && Input.anyKeyDown)
        {
            // If button is pressed mid dialogue, stop typing it
            if (IsTyping)
            {
                StopCoroutine(TypingCoroutine);
                DialogueText.text = Dialogue[Index];
                IsTyping = false;
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
        DialogueText.text = "";
        Index = 0;
        DialoguePanel.SetActive(false);
        ChoicePanel.SetActive(false);
    }

    // Typing effect
    IEnumerator Typing()
    {
        IsTyping = true;
        DialogueText.text = "";
        foreach(char letter in Dialogue[Index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(WordSpeed);
        }
        IsTyping = false;
    }

    public void NextLine()
    {
        if(Index < Dialogue.Length - 1)
        {
            Index++;
            DialogueText.text = "";
            TypingCoroutine = StartCoroutine(Typing());
        }
        else
        {
            ShowChoices();
        }
    }

    private void ShowChoices()
    {
        ChoicePanel.SetActive(true);
    }

    private void GiveItem()
    {
        print("gave item");
        int selected = Hotbar.GetSelectedIndex();
        if(selected == -1)
        {
            print("no item selected!!!");
        }
        else
        {
            Sprite item = Hotbar.hotbarSlots[selected].sprite;
            Hotbar.hotbarSlots[selected].sprite = null;
            Hotbar.items[selected] = null;
        }
        ExitDialogue();
    }
    private void ExitDialogue()
    {
        zeroText();
    }
    // These functions set the boolean that checks if a player is close enough
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsClose = false;
            if(DialogueText == null)
            {
                zeroText();
            }
        }
    }

}
