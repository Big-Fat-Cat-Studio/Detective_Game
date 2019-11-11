using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEditor;

namespace Scripts
{
    public class ClueController : MonoBehaviour
    {
        private GameObject _auraPrefab;
        private ParticleSystem[] _particleSystems;
        private Bounds objectBounds;
        private bool active;

        // Mesh materials
        public Material Clues;

        // Clue struct

        private struct ClueMaterials
        {
            public Material InitMaterial;
            public Material ClueMaterial;
        }

        private ClueMaterials currentObj;

        // Start is called before the first frame update
        void Start()
        {
            _auraPrefab = (GameObject)Instantiate(Resources.Load("ClueAura"));
            _particleSystems = _auraPrefab.GetComponentsInChildren<ParticleSystem>();
            objectBounds = gameObject.GetComponent<MeshRenderer>().bounds;

            toggleParticles(false, objectBounds.size);
            ClueInitializer(); // Clues are of layer 9

        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.ActivePlayer != ActivePlayer.Grandpa && active)
            {
                toggleParticles(false, Vector3.zero);
                GameObject.Find("PlayerCamera").GetComponent<PostProcessingBehaviour>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().material = currentObj.InitMaterial;

            }

            if (_auraPrefab == null || GameManager.Instance.ActivePlayer != ActivePlayer.Grandpa) return;

            if (Input.GetKeyDown(KeyCode.Space) && !active)
            {
                toggleParticles(true, Vector3.zero);
                GameObject.Find("PlayerCamera").GetComponent<PostProcessingBehaviour>().enabled = true;

                // Vision is enabled, apply clue mesh.
                gameObject.GetComponent<MeshRenderer>().material = currentObj.ClueMaterial;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && active)
            {
                toggleParticles(false, Vector3.zero);
                GameObject.Find("PlayerCamera").GetComponent<PostProcessingBehaviour>().enabled = false;

                // Vision disabled, switch back to old mesh.
                gameObject.GetComponent<MeshRenderer>().material = currentObj.InitMaterial;

            }
        }

        void toggleParticles(bool toggle, Vector3 measurement)
        {
            foreach (ParticleSystem system in _particleSystems)
            {
                if (measurement.x != 0 && system.gameObject.name == "lines")
                {
                    GameObject grg = system.gameObject;

                    float scaled_y = (float)(gameObject.transform.position.y - (measurement.y / 2));
                    _auraPrefab.transform.position = new Vector3(gameObject.transform.position.x, scaled_y, gameObject.transform.position.z);
                }

                ParticleSystem.EmissionModule particleEmission = system.emission;
                particleEmission.enabled = toggle;
                active = toggle;
            }
        }

        void ClueInitializer()
        {
            currentObj = new ClueMaterials
            {
                InitMaterial = gameObject.GetComponent<MeshRenderer>().material,
                ClueMaterial = Clues
            };
        }
    }
}
