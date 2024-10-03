using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
public class SpeechWatch : MonoBehaviour
{
    Animator animator;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string,Action> actions = new Dictionary<string,Action>();
    public static string lastRecognizedPhrase = "g+";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        actions.Add("g+", TriggerAnimation);
        actions.Add("g minus", TriggerAnimation);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log("You said: " + speech.text);
        if (speech.text != lastRecognizedPhrase && actions.ContainsKey(speech.text))
        {
            actions[speech.text].Invoke();
            lastRecognizedPhrase = speech.text;
        }
        else
        {
            Debug.LogWarning("Command not recognized or already executed: " + speech.text);
        }
    }
    private void TriggerAnimation()
    {
        animator.SetTrigger("Switch");
    }
}
