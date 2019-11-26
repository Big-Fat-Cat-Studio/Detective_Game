using UnityEngine;
using System;
using System.Collections;

namespace Scripts
{
    public class Rope : MonoBehaviour, IInteractable
    {
        public GameObject Player, Ladder;
        public float LadderMoveRange, RopeMoveRange = 0.5f;
        public int MoveTime;

        private bool RopeActive;
        private Vector3 RopeStartPos, RopeEndPos;
        private Vector3 LadderStartPos, LadderEndPos;

        void Start()
        {
            RopeStartPos = gameObject.transform.position;
            RopeEndPos = new Vector3(RopeStartPos.x, RopeStartPos.y - RopeMoveRange, RopeStartPos.z);

            LadderStartPos = Ladder.transform.position;
            LadderEndPos = new Vector3(LadderStartPos.x, LadderStartPos.y - LadderMoveRange, LadderStartPos.z);
        }

        void Update()
        {
            Helper.InteractGeneral(this.gameObject, Player, 2, new Tuple<Action, Action>(InRange, OutRange));

        }

        public void InRange()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                StartCoroutine(Move(gameObject, new Tuple<Vector3, Vector3>(RopeStartPos, RopeEndPos), 2f, () => { RopeActive = !RopeActive; }));
                StartCoroutine(Move(Ladder, new Tuple<Vector3, Vector3>(LadderStartPos, LadderEndPos), 2f, () => { return; }));
            }
        }

        public void OutRange() { }


        private IEnumerator Move(GameObject ob, Tuple<Vector3, Vector3> pos, float time, Action c)
        {
            while (time > 0.0f)
            {
                ob.transform.position = (!RopeActive) ?
                    Vector3.Lerp(ob.transform.position, pos.Item2, Time.deltaTime) :
                    Vector3.Lerp(ob.transform.position, pos.Item1, Time.deltaTime);
                time -= Time.deltaTime;
                yield return null;
            }
            c();
        }
    }
}

