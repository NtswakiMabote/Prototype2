using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Subtitles : MonoBehaviour
{
    private List<string> _currLines;
    private int _index;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = "";
        _index = 0;

        if (SceneManager.GetActiveScene().name.Contains("OpeningScene"))
        {
            PlayConversation("Opening Conversation");
        }

        //_currConversation = GameObject.Find("ConversationHolder").GetComponent<Conversation>().GetLines();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    PlayConversation("Harry Potter");
        //}
    }

    public void NextLine()
    {
        this.GetComponent<Text>().text = _currLines[_index];
        if (_index < _currLines.Count-1)
        {
            _index++;
        }
    }

    public void SetCurrConversation(List<string> newConvo)
    {
        _currLines = newConvo;
    }

    public void Empty()
    {
        this.GetComponent<Text>().text = "";
    }

    public void PlayConversation(string name)
    {

        Conversation currentConversation = GetConversationByName(name);
        _currLines = currentConversation.GetLines();

        GameObject.Find("DialogueSoundSource").GetComponent<DialogueSoundSource>().PlayDialogue(currentConversation.GetClip(), currentConversation.GetAnimator());
    }

    public Conversation GetConversationByName(string name)
    {
        Conversation[] conversations = GameObject.Find("ConversationHolder").GetComponents<Conversation>();

        Conversation returnConvo = null;

        foreach (Conversation c in conversations)
        {
            if (c.GetName().ToUpper().Contains(name.ToUpper()))
            {
                returnConvo = c;
            }
        }

        return returnConvo;
    }

    public void EnableAllInteractableObjects()
    {
        //Debug.Log("SHOULD ENABLE ALL OBJECTS!!");
    }

    //public void DisableAllInteractableObjects()
    //{
    //    InteractableObject.DisableAllInteractableObjects();
    //    Debug.Log("SHOULD DISABLE ALL OBJECTS!!");
    //}

    public void UnenableAllInteractableObjects()
    {
        Debug.Log("SHOULD DISABLE ALL OBJECTS!!");
    }

    public void FadeInQuote()
    {
        GameObject.Find("QuoteCanvas").transform.GetChild(0).GetComponent<TextFader>().FadeIn();
        GameObject.Find("QuoteCanvas").transform.GetChild(1).GetComponent<TextFader>().FadeIn();
    }

    public void FadeScene()
    {
        GameObject.Find("FadeCanvas").GetComponent<TransitionFade>().NextScene();
    }
}
