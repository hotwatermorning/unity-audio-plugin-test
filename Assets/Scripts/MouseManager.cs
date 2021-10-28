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
 
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
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

        // if (Input.GetMouseButton(0)) {
        //     var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //     var raycastHitList = Physics.RaycastAll(ray).ToList();
        //     if (raycastHitList.Any()) {
        //         var distance = Vector3.Distance(mainCamera.transform.position, raycastHitList.First().point);
        //         var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
 
        //         currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        //         currentPosition.y = 0;
        //     }
        // }
    }
}
