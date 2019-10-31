using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ClueController : MonoBehaviour
{
    private GameObject _auraPrefab;
    private ParticleSystem[] _particleSystems;
    private Bounds objectBounds;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        _auraPrefab = (GameObject)Instantiate(Resources.Load("ClueAura"));
        _particleSystems = _auraPrefab.GetComponentsInChildren<ParticleSystem>();
        objectBounds = gameObject.GetComponent<MeshRenderer>().bounds;

        toggleParticles(false, objectBounds.size);
    }

    // Update is called once per frame
    void Update()
    {
        if (_auraPrefab == null) return;

        if (Input.GetKeyDown("space") && !active)
        {
            toggleParticles(true, Vector3.zero);
            GameObject.Find("PlayerCamera").GetComponent<PostProcessingBehaviour>().enabled = true;
        }
        else if (Input.GetKeyDown("space") && active)
        {
            toggleParticles(false, Vector3.zero);
            GameObject.Find("PlayerCamera").GetComponent<PostProcessingBehaviour>().enabled = false;
        }
    }

    void toggleParticles(bool toggle, Vector3 measurement)
    {
        foreach(ParticleSystem system in _particleSystems)
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
}
