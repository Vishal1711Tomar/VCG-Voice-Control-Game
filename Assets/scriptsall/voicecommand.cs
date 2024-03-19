using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class voicecommand : MonoBehaviour
{
    public string[] keyword = new string[] { "Jump", "Left", "right" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    KeywordRecognizer recognizer;
    public PlayerController player;
    
    void Start()
    {
        recognizer = new KeywordRecognizer(keyword, confidence);
        recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
        recognizer.Start(); 
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        player.Movement(args.text);
      
        Debug.Log(args.text);
    }
    private void OnApplicationQuit()
    {
        if(recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
    public void Quit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
