using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Linq;

public class MouseManager : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 currentPosition = Vector3.zero;

    [SerializeField] AudioMixer audioMixer;
    List<GameObject> keys = new List<GameObject>();
 
    void Start()
    {
        mainCamera = Camera.main;

        keys.Add(GameObject.Find("KeyC"));
        keys.Add(GameObject.Find("KeyD"));
        keys.Add(GameObject.Find("KeyE"));
        keys.Add(GameObject.Find("KeyF"));
        keys.Add(GameObject.Find("KeyG"));
        keys.Add(GameObject.Find("KeyA"));
        keys.Add(GameObject.Find("KeyB"));
    }

    // Update is called once per frame
    void Update()
    {
        GameObject found = null;
        if (Input.GetMouseButton(0)) {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                found = hit.collider.gameObject;
            }
        }

        foreach(GameObject key in keys) {
            if(found && found.transform.IsChildOf(key.transform)) {
                key.GetComponent<MusicalKeyBehavior>().MousePushOn();
            } else {
                key.GetComponent<MusicalKeyBehavior>().MousePushOff();
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            float value = 0.0f;
            audioMixer.GetFloat("reverb", out value);
            value -= 0.02f;
            if(value < 0) { value = 0; }

            audioMixer.SetFloat("reverb", value);
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            float value = 0.0f;
            audioMixer.GetFloat("reverb", out value);
            value += 0.02f;
            if(value > 1.0f) { value = 1.0f; }

            audioMixer.SetFloat("reverb", value);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            float value = 0.0f;
            audioMixer.GetFloat("gain", out value);
            value -= 0.02f;
            if(value < 0) { value = 0; }

            audioMixer.SetFloat("gain", value);
        } else if(Input.GetKey(KeyCode.UpArrow)) {
            float value = 0.0f;
            audioMixer.GetFloat("gain", out value);
            value += 0.02f;
            if(value > 1.0f) { value = 1.0f; }

            audioMixer.SetFloat("gain", value);
        }
    }
}
