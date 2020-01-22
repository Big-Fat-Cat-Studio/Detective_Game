using UnityEngine;
using Scripts;

namespace Scripts
{
	public class InteractChangeState : InteractableObjectItemNeeded
    {
        public GameObject[] ChangeStateOf;
        public Material ApplyOnChange;
        public ParticleSystem brokenParticles;
        public string textFixed;

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
            if (!Consumed)
            {
                Consumed = true;
                interactable = false;
                GameManager.Instance.showAfterInteractText(player, textFixed);
                neededItem = null;
                GameManager.Instance.Human.GetComponentInChildren<PlayerInteract>().destroyHoldingObject();
                brokenParticles.Stop();
            }
        }
	}
}
