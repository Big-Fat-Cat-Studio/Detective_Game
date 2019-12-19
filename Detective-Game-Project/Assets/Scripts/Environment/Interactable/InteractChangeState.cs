using UnityEngine;
using Scripts;

namespace Scripts
{
	public class InteractChangeState : InteractableObject
    {
        public string afterInteractMessage;
        public GameObject neededItem;

        public GameObject[] ChangeStateOf;
        public Material ApplyOnChange;

        [HideInInspector] public bool Consumed;

        private bool _Changed;


		void Start()
		{
			interactableType = InteractableType.STATECHANGER;
		}

        private void Update()
        {
            if (Consumed && !_Changed)
            {
                foreach (GameObject sub in ChangeStateOf)
                    sub.GetComponent<MeshRenderer>().material = ApplyOnChange;
                _Changed = true;
                GetComponent<ObjectState>().State = InteractState.ACTIVATED;
            }
        }

        public void interact(GameObject playerItem)
		{
            if (!Consumed)
            {
                if (ReferenceEquals(playerItem, null))
                {
                    GameManager.Instance.showInteractText("Maybe I need to find a wrench to fix this.", ActivePlayer.Human);
                    return;
                }

                if (ReferenceEquals(playerItem, neededItem) ||
                    playerItem.name.Substring(0, playerItem.name.Length - 7) == neededItem.name)
                {
                    Consumed = true;
                    playerItem.SetActive(false);
                    Destroy(playerItem);
                }
                else
                {
                    GameManager.Instance.showAfterInteractText(ActivePlayer.Human, "Great, I think it's fixed! Maybe the dog elevator works now.");
                }
            } else
            {
                GameManager.Instance.showInteractText("I already fixed it, perhaps the dog elevator works now.", ActivePlayer.Human);
            }
        }
	}
}