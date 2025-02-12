using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    public Image[] hotbarSlots;
    public Sprite[] items;
    private int selected = -1;
    bool itemEquipped = false;

    void Start()
    {
        InitHotbar();
        UpdateHotbarUI();
    }

    void Update()
    {
        HandleInput();
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

    public void InitHotbar()
    {
        for (int i=0; i<hotbarSlots.Length; i++)
        {
            hotbarSlots[i].sprite = items[i];
            hotbarSlots[i].color = Color.white;
        }
    }

    public int GetSelectedIndex()
    {
        return selected;
    }
}
