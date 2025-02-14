using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{   
    // Inventory
    public Image[] hotbarSlots;
    public Sprite[] items;
    private int selected = -1;
    private bool itemEquipped = false;

    // Letter-related stuff
    private bool IsReading = false;
    public Letter[] letters = new Letter[6];
    public GameObject HintsPanel;
    public Text HintsText;

    void Start()
    {
        HintsPanel.SetActive(false);
        InitLetters();
        InitHotbar();
        UpdateHotbarUI();
    }

    void Update()
    {
        HandleInput();
    }

    // Starts the player's hotbar with all 6 items
    public void InitHotbar()
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            hotbarSlots[i].sprite = items[i];
            hotbarSlots[i].color = Color.white;
        }
    }

    // Creates the letter objects, stores them in order then calls the shuffle method

    public void InitLetters()
    {
        letters[0] = new Letter("NPC 1", "This person likes spending time outside, has a fiery personality, and has youthful energy."); // Bowl cut
        letters[1] = new Letter("NPC 2", "This person is a free-spirit, has a bit of an edge to them, and enjoys nature."); // The adventurer
        letters[2] = new Letter("NPC 3",  "This person is gentle, independent, but doesn't like flowers."); // Young girl
        letters[3] = new Letter("NPC 4",  "This person seems to know everything, is well-loved, and adores roses."); // Old man
        letters[4] = new Letter("NPC 5",  "This person has many stories to tell, loves the rain, and has a sensitive nose."); // Old lady
        letters[5] = new Letter("NPC 6", "This person is highly intelligent, determined, and has old knowledge."); // Suspicious man
        Shuffle(letters);
    }

    // Shuffles the array of letters
    private void Shuffle(Letter[] letters)
    {
        // Knuth shuffle algorithm
        for (int i=0; i<letters.Length; i++)
        {
            Letter temp = letters[i];
            int r = Random.Range(i, letters.Length);
            letters[i] = letters[r];
            letters[r] = temp;
        }
    }

    public int GetSelectedIndex()
    {
        return selected;
    }

    void HandleInput()
    {
        // Check if user pressed ESC to leave the letter
        if (IsReading && Input.GetKeyDown(KeyCode.Escape))
        {
            IsReading = false;
            HintsText.text = "";
            HintsPanel.SetActive(false);
            PlayerMovement.SetMove(true);
        }
        // Ignore all other inputs besides ESC when reading the letter
        if (IsReading)
        {
            return;
        }
        // If player presses right click and is not currently reading a letter
        if (Input.GetMouseButtonDown(1) && itemEquipped && !IsReading)
        {
            IsReading = true;
            ReadLetter();
            PlayerMovement.SetMove(false); // When reading a letter, player cannot move
        }
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                if (selected == i)
                {
                    selected = -1; // Unselect item
                    itemEquipped = false;
                }
                else
                {
                    selected = i;
                    itemEquipped = true;
                }
                UpdateHotbarUI();
            }
        }
    }

    public void UpdateHotbarUI()
    {
        for (int i=0; i<hotbarSlots.Length; i++)
        {
            hotbarSlots[i].color = (i == selected) ? Color.gray : Color.white;
        }
        if (selected == -1)
        {
            for (int j=0; j<hotbarSlots.Length; j++)
            {
                hotbarSlots[j].color = Color.white;
            }
        }
    }

    public void ReadLetter()
    {
        if(selected >= 0 && selected <= letters.Length - 1) { 
            HintsPanel.SetActive(true);
            HintsText.text = letters[selected].GetHints(); // Set the text component to the respective hint
         }
    }
}
