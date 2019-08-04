using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    public string conversationName;
    public AudioClip dialogueClip;
    public RuntimeAnimatorController animator;
    public List<string> lines;


    public List<string> GetLines()
    {
        return lines;
    }

    public string GetName()
    {
        return conversationName;
    }

    public AudioClip GetClip()
    {
        return dialogueClip;
    }

    public RuntimeAnimatorController GetAnimator()
    {
        return animator;
    }




}
