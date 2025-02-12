using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Letter
{
    private string NPCName; // The NPC who this letter belongs to
    private int SlotNum; // The index of the letter in the hotbar
    private bool delivered; // Whether this letter was delivered or not
    private string[] hints; // Each letter contains three hints as to who it belongs to

    public Letter(string NPCName, int SlotNum, string[] hints)
    {
        this.NPCName = NPCName;
        this.SlotNum = SlotNum;
        this.hints = hints;
        delivered = false;
    }


    public string getNPCName()
    {
        return NPCName;
    }

    public int getSlotNum()
    {
        return SlotNum;
    }

    public bool isDelivered()
    {
        return delivered;
    }

    public string[] getHints()
    {
        return hints;
    }

    public void setDelivered()
    {
        delivered = true;
    }

}
