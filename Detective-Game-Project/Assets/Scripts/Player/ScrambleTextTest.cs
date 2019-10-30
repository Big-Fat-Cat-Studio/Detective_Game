using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScrambleTextTest : MonoBehaviour
{
    private string original_text;
    private string scrambled_text;
    // Start is called before the first frame update
    private void Start()
    {
        original_text = this.gameObject.GetComponent<Text>().text;
        scrambled_text = TextScrambler(original_text);
    }
    // Update is called once per frame
    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("GameManager").GetComponent<SwitchPlayer>().active_player == SwitchPlayer.ActivePlayer.Grandpa)
        {
            this.gameObject.GetComponent<Text>().text = original_text;
        }
        else if(GameObject.FindGameObjectWithTag("GameManager").GetComponent<SwitchPlayer>().active_player == SwitchPlayer.ActivePlayer.Kid)
        {
            this.gameObject.GetComponent<Text>().text = scrambled_text;
        }
    }
    private string TextScrambler(string text_to_scrmble)
    {
        string result = "";
        char[] temp = this.original_text.ToCharArray();
        char[] to_fill = new char[temp.Length];
        for(int letter_index = 0; letter_index < temp.Length; letter_index++)
        {
            int nletter = (int)temp[letter_index];
            int change = Random.Range(-5, 5);
            int new_letter = nletter + change;
            if(new_letter > 127)
            {
                to_fill[letter_index] = (char)nletter;
            }
            else
            {
                to_fill[letter_index] = (char)new_letter;
            }
        }
        result = new string(to_fill);
        print(to_fill[4]);
        return result;
    }
}