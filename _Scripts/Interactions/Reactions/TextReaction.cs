using System.Collections;
using System.Collections.Generic;
using Interactions.Reactions;
using TMPro;
using UI;
using UnityEngine;
[CreateAssetMenu(fileName = "New Text reaction", menuName = "Scriptable Objects/Reactions")]
public class TextReaction : Reaction
{
    [SerializeField] private List<string> sentences = new List<string>();
    private TextManager textManager;
    
    //private TextManager textManager;
    private int index = 0;

    protected override void SpecificInit()
    {
        index = 0;
        textManager = FindObjectOfType<TextManager>();
    }

    protected override void ImmediateReaction()
    {
        textManager.SetText(sentences[index]);
        index++;
    }

    public override bool NextStep()
    {
        if (index < sentences.Count)
        {
            textManager.SetText(sentences[index]);
            index++;
            return true;
        }

        isRunning = false;
        return false;
        
    }
/*public IEnumerator startInteraction(TextMeshProUGUI textArea)
    {
        isRunning = true;
        for (var i = 0; i < sentences.Count; i++)
        {
            textArea.text = sentences[i];
            yield return new WaitForSeconds(3f);
        }

        isRunning = false;
    }
*/    
    
    
}
