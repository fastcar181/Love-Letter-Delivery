using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Letter
{
    private string NPCName; // The NPC who this letter belongs to
    private bool delivered; // Whether this letter was delivered or not
    private string hints; // Each letter contains hints as to who it belongs to

    public Letter(string NPCName, string hints)
    {
        this.NPCName = NPCName;
        this.hints = hints;
        delivered = false;
    }


    public string GetNPCName()
    {
        return NPCName;
    }

    public bool IsDelivered()
    {
        return delivered;
    }

    public string GetHints()
    {
        return hints;
    }

    public void SetDelivered()
    {
        delivered = true;
    }



}
