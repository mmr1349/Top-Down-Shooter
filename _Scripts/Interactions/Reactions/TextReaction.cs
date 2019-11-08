using System.Collections;
using System.Collections.Generic;
using Interactions.Reactions;
using TMPro;
using UI;
using UnityEngine;

namespace Interactions.Reactions
{
    [CreateAssetMenu(fileName = "New Text reaction", menuName = "ScriptableObjects/Reactions/Text Reaction")]
    public class TextReaction : Reaction
    {
        [SerializeField] private List<string> sentences = new List<string>();
        private TextMeshProUGUI textMesh;
        //private ReactionManager reactionManager;
    
        //private TextManager textManager;
        private int index = 0;

        protected override void SpecificInit()
        {
            index = 0;
            //reactionManager = FindObjectOfType<ReactionManager>();
        }

        protected override void ImmediateReaction()
        {
            textMesh = reactionObjectInstance.GetComponentInChildren<TextMeshProUGUI>();
            //textManager.SetText(sentences[index]);
            Debug.Log(sentences[index]);
            textMesh.SetText(sentences[index]);
            index++;
        }

        public override bool NextStep()
        {
            if (index < sentences.Count)
            {
                Debug.Log(sentences[index]);
                textMesh.SetText(sentences[index]);
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

}