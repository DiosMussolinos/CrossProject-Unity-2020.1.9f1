//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Linq;
//using TMPro;

//public static class NarrationManager
//{
//    public static TextMeshPro captions;
//    static TextAsset Script = Resources.Load("SpeechScript") as TextAsset;  
//    static NarrationList narrations = JsonUtility.FromJson<NarrationList>(Script.text);
    

//    // detect which NPC's speech is triggered <- function TriggerSpeech(NPC)
//    // decode txt file: detect which npc is speaking, where is start, break and end
//    // make adaptable for randomizing unique strings
//    // define time between showing parts of a string
//    // play audio
//    // use lable to display subtitles in a box

//    static public void TrigggeredSpeech(GameObject NPC, int speechNumber)
//    {
//        var name = narrations.narrations.Where(n => NPC.name == n.name);
//        int sentenceNumber = 0;
//        float displayTime = 0f;

//        foreach (var nr in name)
//        {
//            if(nr.speechNr == speechNumber)
//            {
//                captions.text = nr.sentences[sentenceNumber].text;
//                displayTime += Time.time;
//                if(displayTime >= nr.sentences[sentenceNumber+1].time - nr.sentences[sentenceNumber].time)
//                {
//                    sentenceNumber += 1;
//                    if(sentenceNumber >= nr.sentences.Count-1) // ! might be removed depending on how the dialogues will be redesigned.
//                    {
//                        captions.text = "";
//                    }
//                }  
                
//            }
//        }
        
        
//    }


//}
//public class Sentence
//{
//    public int time { get; set; }
//    public string text { get; set; }
//}

//public class Narration
//{
//    public string name { get; set; }
//    public int speechNr { get; set; }
//    public List<Sentence> sentences { get; set; }
//}

//[System.Serializable]
//public class NarrationList
//{
//    public List<Narration> narrations { get; set; }
//}


