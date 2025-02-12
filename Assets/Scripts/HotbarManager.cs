using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    public Image[] hotbarSlots;
    public Sprite[] items;
    private int selected = -1;
    bool itemEquipped = false;
    bool readingLetter = false;
    void Start()
    {
        InitHotbar();
        UpdateHotbarUI();
    }

    void Update()
    {
        HandleInput();
    }

    public void InitHotbar()
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            hotbarSlots[i].sprite = items[i];
            hotbarSlots[i].color = Color.white;
        }
    }

    public int GetSelectedIndex()
    {
        return selected;
    }

    void HandleInput()
    {
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
        // If player presses right click and is not currently reading a letter
        if (Input.GetMouseButtonDown(1) && itemEquipped && !readingLetter)
        {
            readingLetter = true;
            print("now we open the letter");
            ReadLetter();
        }
        // Check if user pressed ESC to leave the letter
        if (readingLetter && Input.GetKeyDown(KeyCode.Escape))
        {
            readingLetter = false;
            print("now we closed the letter!");
        }
    }

    void UpdateHotbarUI()
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
        print("in readletter function");
        print("give the three hints that belong to the letters... maybe a popup on the right will say");
        print("if at any point ");
    }
}
