using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class SpeechManager : MonoBehaviour
{

    public Text captions;
    public GameObject player;
    private TextAsset Script;
    private float displayTime = 0f;
    private Queue<Sentence> sentences = new Queue<Sentence>();
    private Sentence currentSentence;
    private GameObject NPC;

    public void TriggeredSpeech(GameObject NPC, int speechNumber)
    {
        NarrationList narrations = JsonUtility.FromJson<NarrationList>(Script.text);
        this.NPC = NPC;
        Reset();
        var nr = narrations.narrations
            .Where(n => NPC.name == n.name)
            .FirstOrDefault(n => n.speechNr == speechNumber);

        if (nr == null)
        {
            return;
        }

        nr.sentences.ForEach(s => sentences.Enqueue(s));
    }

    public void StopCaptions()
    {
        captions.text = "";
    }

    public void Reset()
    {
        displayTime = 0;
        captions.text = "";
        currentSentence = null;
        sentences = new Queue<Sentence>();
    }
    void Start()
    {
        Script = Resources.Load("SpeechScript") as TextAsset;
    }

    void Update()
    {
        if (!sentences.Any() && currentSentence == null)
        {
            displayTime = 0;
            captions.text = "";
            return;
        }

        if (currentSentence == null)
        {
            currentSentence = sentences.Dequeue();
        }

        if (NPC != null && Vector3.Distance(player.transform.position, NPC.transform.position) >= 20f)
        {
            captions.text = "";
        }
        else
        {
            captions.text = currentSentence.text;
        }

        displayTime += Time.deltaTime;

        if (displayTime >= currentSentence.end - currentSentence.start)
        {
            displayTime = 0;
            currentSentence = null;
        }

    }
}




