using UnityEngine;
using System;
using System.Collections;

namespace Scripts
{
    public class Rope : InteractableObject
    {
        public GameObject Ladder;
        public float LadderMoveRange, RopeMoveRange = 0.5f;
        public float MoveTime = 2f;

        private bool pulling;
        private bool RopeActive;
        private Vector3 RopeStartPos, RopeEndPos;
        private Vector3 LadderStartPos, LadderEndPos;

        void Start()
        {
            interactableType = InteractableType.HoldButton;

            RopeStartPos = gameObject.transform.position;
            RopeEndPos = new Vector3(RopeStartPos.x, RopeStartPos.y - RopeMoveRange, RopeStartPos.z);

            LadderStartPos = Ladder.transform.position;
            LadderEndPos = new Vector3(LadderStartPos.x, LadderStartPos.y - LadderMoveRange, LadderStartPos.z);
        }

        void Update()
        {
            StartCoroutine(Move(gameObject, new Tuple<Vector3, Vector3>(RopeStartPos, RopeEndPos), MoveTime, CallBack));
            StartCoroutine(Move(Ladder, new Tuple<Vector3, Vector3>(LadderStartPos, LadderEndPos), MoveTime, () => { }));
        }

        public override void interact(ActivePlayer player)
        {
            pulling = !pulling;
        }

        public void CallBack()
        {
            RopeActive = !RopeActive;
        }

        private IEnumerator Move(GameObject ob, Tuple<Vector3, Vector3> pos, float time, Action c)
        {
            if (pulling)
            { 
                ob.transform.position = Vector3.Lerp(ob.transform.position, pos.Item2, Time.deltaTime);
                Ladder.GetComponent<Collider>().isTrigger = false;
                yield return null;
            }
            else
            { 
                ob.transform.position = Vector3.Lerp(ob.transform.position, pos.Item1, Time.deltaTime);
                time -= Time.deltaTime;
                Ladder.GetComponent<Collider>().isTrigger = true;
                yield return null;
            }
            c();
        }
    }
}

