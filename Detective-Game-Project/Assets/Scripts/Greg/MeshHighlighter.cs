using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class MeshHighlighter : MonoBehaviour
    {
        private Shader defaultShader;
        private Shader highlightShader;
        private Renderer rend;
        private bool active;

        // Start is called before the first frame update
        void Start()
        {
            rend = GetComponent<Renderer>();
            active = false;
            defaultShader = rend.material.shader;
            highlightShader = Shader.Find("Shader Graphs/glow");
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.ActivePlayer != ActivePlayer.Human && active)
            {
                toggleClues("off");
            }
            
            if (highlightShader == null || GameManager.Instance.ActivePlayer != ActivePlayer.Human) return;

            if (Input.GetKeyDown(KeyCode.Space) && !active)
            {
                toggleClues("on");
            }
            else if (Input.GetKeyDown(KeyCode.Space) && active)
            {
                toggleClues("off");
            }
        }

        // Toggle the highlighting effect on the object
        void toggleClues(string toggle)
        {
            if(rend.material.shader == defaultShader && toggle == "on")
            {
                rend.material.shader = highlightShader;
                active = true;
            }
            else
            {
                rend.material.shader = defaultShader;
                active = false;
            }
        }
    }
}
