using UnityEngine;
using Scripts;

namespace Scripts
{
	public class InteractChangeState : InteractableObjectItemNeeded
    {
        public GameObject[] ChangeStateOf;
        public Material ApplyOnChange;
        public ParticleSystem brokenParticles;

        [HideInInspector] public bool Consumed;

        private bool _Changed;

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

        protected override void interactSucces(ActivePlayer player, GameObject playerItem)
        {
            if (Consumed)
            {
                GameManager.Instance.showAfterInteractText(player, "I already fixed it, the elevator should work now.");
            }
            else
            {
                Consumed = true;
                GameManager.Instance.showAfterInteractText(player, "Great, I think it's fixed! Maybe the dog elevator works now.");
                neededItem = null;
                GameManager.Instance.Human.GetComponentInChildren<PlayerInteract>().destroyHoldingObject();
                brokenParticles.Stop();
            }
        }
	}
}