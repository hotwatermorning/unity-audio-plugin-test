using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicalKeyBehavior : MonoBehaviour
{
    [SerializeField] Color keyColor = new Color(0, 0, 0);
    [SerializeField] string keyboardMapping = "";

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] string mixerParameterName = "";

    private bool isMousePushed = false;
    private bool isComputerKeyPushed = false;
    private bool isNoteOnTriggered = false;
    private GameObject body = null;

    public void MousePushOn()
    {
        isMousePushed = true;
    }

    public void MousePushOff()
    {
        isMousePushed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.color = keyColor;
    }

    // Update is called once per frame
    void Update()
    {
        isComputerKeyPushed = Input.GetKey(keyboardMapping);

        bool isPushedAny = (isComputerKeyPushed || isMousePushed);

        if (isPushedAny && isNoteOnTriggered == false) {

            this.transform.RotateAround(
                this.transform.position,
                Vector3.left,
                4.0f
                );
            isNoteOnTriggered = true;
            audioMixer.SetFloat(mixerParameterName, 1.0f);
        } else if(isPushedAny == false && isNoteOnTriggered) {
            this.transform.RotateAround(
                this.transform.position,
                Vector3.left,
                -4.0f
                );
            isNoteOnTriggered = false;
            audioMixer.SetFloat(mixerParameterName, 0.0f);
        }
    }
}
