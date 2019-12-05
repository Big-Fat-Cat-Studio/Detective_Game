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
            GameManager.Instance.addCluesToList(this);
        }

        // Update is called once per frame
        void Update()
        {
            return;
            if (!GameManager.Instance.checkIfPlayerIsActive(ActivePlayer.Animal) && active)
            {
                toggleClues();
            }
        }

        // Toggle the highlighting effect on the object
        public void toggleClues()
        {
            if(active)
            {
                rend.material.shader = defaultShader;
                active = false;
            }
            else
            {
                rend.material.shader = highlightShader;
                active = true;
            }
        }
    }
}
