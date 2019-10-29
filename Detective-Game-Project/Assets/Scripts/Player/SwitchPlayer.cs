using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    private enum ActivePlayer
    {
        Grandpa,
        Kid
    }

    public GameObject grandpa;
    public GameObject kid;

    private ActivePlayer active_player;
    // Start is called before the first frame update
    private void Start()
    {
        grandpa = GameObject.FindGameObjectWithTag("Grandpa");
        kid = GameObject.FindGameObjectWithTag("Kid");
        grandpa.GetComponent<GrandpaPlayer>().is_active_player = true;
        active_player = ActivePlayer.Grandpa;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(active_player == ActivePlayer.Grandpa)
            {
                grandpa.GetComponent<GrandpaPlayer>().is_active_player = false;
                kid.GetComponent<KidPlayer>().is_active_player = true;
                active_player = ActivePlayer.Kid;
            }
            else if(active_player == ActivePlayer.Kid)
            {
                kid.GetComponent<KidPlayer>().is_active_player = false;
                grandpa.GetComponent<GrandpaPlayer>().is_active_player = true;
                active_player = ActivePlayer.Grandpa;
            }
        }
    }
}
