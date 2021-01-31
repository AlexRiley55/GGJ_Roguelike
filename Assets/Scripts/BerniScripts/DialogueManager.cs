using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI sentenceText;
    public Text yesText;
    public Text noText;

    public string[] sentence; //we can have a replace * for item type that player is trying to exchange 
    public string[] yesPhrase;
    public string[] noPhrase;

    private void OnEnable()
    {
        sentenceText.text = GenerateSentence();
        yesText.text = GenerateYes();
        noText.text = GenerateNo();
    }

    public void OptionYes() //swap item
    {
        
    }

    public void OptionNo() //deny item
    {
        
    }

    public void DialogueSlideAway()
    {
        animator.Play("DialogueSlideAway");        
    }

    private string GenerateSentence()
    {
        string _sentence = "";

        int ran = Random.Range(0, sentence.Length);
        _sentence = sentence[ran];

        return _sentence;
    }

    private string GenerateYes()
    {
        string _sentence = "";

        int ran = Random.Range(0, yesPhrase.Length);
        _sentence = yesPhrase[ran];

        return _sentence;
    }

    private string GenerateNo()
    {
        string _sentence = "";

        int ran = Random.Range(0, noPhrase.Length);
        _sentence = noPhrase[ran];

        return _sentence;
    }

}
