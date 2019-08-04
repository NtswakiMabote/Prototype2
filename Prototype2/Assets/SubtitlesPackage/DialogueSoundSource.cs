using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSoundSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDialogue(AudioClip newClip, RuntimeAnimatorController animator)
    {
        this.GetComponent<AudioSource>().clip = newClip;
        GameObject.Find("Subtitles").GetComponent<Animator>().runtimeAnimatorController = animator;
        GameObject.Find("Subtitles").GetComponent<Animator>().enabled = true;
        this.GetComponent<AudioSource>().Play();
    }
}
