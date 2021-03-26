using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    void Start()
    {
        myFloorDetector = gameObject.GetComponent<FloorDetector>();
        myAudioSource = gameObject.AddComponent<AudioSource>();
        myPlayer = GameObject.FindWithTag("Player");
        myLastPlayerPosition = myPlayer.transform.position;
    }

    void Update()
    {
        FloorType floorType = myFloorDetector.DetectFloorType(myPlayer.transform.position);

        print(myPlayer.GetComponent<CharacterController>().isGrounded);
        if ((myLastPlayerPosition - myPlayer.transform.position).sqrMagnitude > Mathf.Epsilon /*&&
            myPlayer.GetComponent<CharacterController>().isGrounded*/)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            ResetTimer();
        }

        if (Timer < 0f)
        {
            myAudioSource.PlayOneShot(myFloorDetector.GetAudio(floorType), 0.4f);
            ResetTimer();
        }

        myLastPlayerPosition = myPlayer.transform.position;
    }

    void ResetTimer()
    {
        Timer = 1f;
    }

    private Vector3 myLastPlayerPosition;
    private GameObject myPlayer = null;
    private FloorDetector myFloorDetector;
    private AudioSource myAudioSource;
    private float Timer = 1f;
}
