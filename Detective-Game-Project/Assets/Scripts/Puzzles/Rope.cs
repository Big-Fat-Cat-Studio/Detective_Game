using UnityEngine;
using System;

namespace Scripts
{
    public class Rope : MonoBehaviour, IInteractable
    {
        public GameObject Player;

        void Start()
        {

        }

        void Update()
        {
            Helper.InteractGeneral(this.gameObject, Player, 2, new Tuple<Action, Action>(InRange, OutRange));

        }

        public void InRange()
        {
            // Check if player holds button X
                // While holding lock the player's movement/rotation
                // 
        }

        public void OutRange()
        {

        }
    }
}

