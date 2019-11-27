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
            if (!GameManager.Instance.checkIfPlayerIsActive(ActivePlayer.Animal) && active)
            {
                toggleClues(false);
            }
            
            if (highlightShader == null || !GameManager.Instance.checkIfPlayerIsActive(ActivePlayer.Animal)) return;

            if (GameManager.Instance.getButtonPressForPlayer(ActivePlayer.Animal, "Special", ButtonPress.Down) && !active)
            {
                toggleClues(true);
            }
            else if (GameManager.Instance.getButtonPressForPlayer(ActivePlayer.Animal, "Special", ButtonPress.Down) && active)
            {
                toggleClues(false);
            }
        }

        // Toggle the highlighting effect on the object
        void toggleClues(bool toggle)
        {
            if(rend.material.shader == defaultShader && toggle)
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
