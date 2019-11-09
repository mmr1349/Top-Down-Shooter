using Events.EventObjects;
using Interactions;
using Interactions.Reactions;
using UnityEngine;

namespace UI
{
    
    public class ReactionManager : MonoBehaviour
    {
        private static ReactionManager instance;
        [SerializeField] private GameObject reactionDisplayArea;
        [SerializeField] private VoidEventObject allowMovement;
        private bool currentlyInteracting;
        private Reaction currentReaction;
        private ReactionCollection currentReactionCollection;
        

        void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
            else
            {
                Debug.LogWarning("Too many Text Managers");
                Destroy(this.gameObject);
            }
        }
    
        // Start is called before the first frame update
        void Start()
        {
            reactionDisplayArea.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            
            if(currentlyInteracting)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    ContinueReaction();
                }
            }
        }

        public void ContinueReaction()
        {
            if (!currentReaction.NextStep())
            {
                if (!currentReactionCollection.TryNextReaction())
                {
                    Debug.Log("Free to go");
                    currentReaction = null;
                    currentReactionCollection = null;
                    currentlyInteracting = false;
                    reactionDisplayArea.gameObject.SetActive(false);
                    Destroy(reactionDisplayArea.transform.GetChild(0).gameObject);
                    allowMovement.Raise();
                }
                else
                {
                    currentReaction = currentReactionCollection.GetNextReaction();
                    Destroy(reactionDisplayArea.transform.GetChild(0).gameObject);
                    var reactionInstance = Instantiate(currentReaction.getReactionObject(), reactionDisplayArea.transform);
                    currentReaction.React(reactionInstance);
                }
            }
        }

        public void TriggerReaction(ReactionCollection reactionCollection)
        {
            if (!currentlyInteracting)
            {
                reactionDisplayArea.SetActive(true);   
                currentlyInteracting = true;
                currentReactionCollection = reactionCollection;
                currentReaction = reactionCollection.GetNextReaction();
                var reactionInstance = Instantiate(currentReaction.getReactionObject(), reactionDisplayArea.transform);
                currentReaction.React(reactionInstance);
            }
            else
            {
                Debug.LogError("Can't run multiple reactions at once");
            }
        }

        public void SetText(string text)
        {
            reactionDisplayArea.gameObject.SetActive(true);
            //reactionDisplayArea.text = text;
        }
    }

}