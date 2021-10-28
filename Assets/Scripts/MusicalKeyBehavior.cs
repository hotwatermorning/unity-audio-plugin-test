using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalKeyBehavior : MonoBehaviour
{
    [SerializeField] Color keyColor = new Color(0, 0, 0);
    [SerializeField] string keyboardMapping = "";

    private bool isPushed = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.color = keyColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyboardMapping) && isPushed == false) {
            this.transform.RotateAround(
                this.transform.position,
                Vector3.left,
                4.0f
                );
            isPushed = true;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        } else if(Input.GetKey(keyboardMapping) == false && isPushed) {
            this.transform.RotateAround(
                this.transform.position,
                Vector3.left,
                -4.0f
                );
            isPushed = false;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Stop();
        }
    }
}
