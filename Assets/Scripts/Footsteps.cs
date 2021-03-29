using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(GroundDetector))]
public class Footsteps : MonoBehaviour
{
    private GroundDetector myGroundDetector = null;

    void Start()
    {
        myFloorDetector = GetComponent<FloorDetector>();
        myAudioSource = gameObject.AddComponent<AudioSource>();
        myGroundDetector = GetComponent<GroundDetector>();
        myPlayer = GameObject.FindWithTag("Player");
        myLastPlayerPosition = myPlayer.transform.position;
    }

    void Update()
    {
        FloorType floorType = myFloorDetector.DetectFloorType(myPlayer.transform.position);

        if ((myLastPlayerPosition - myPlayer.transform.position).sqrMagnitude > Mathf.Epsilon &&
            myGroundDetector.Grounded)
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

    private void ResetTimer()
    {
        Timer = 1f;
    }

    private Vector3 myLastPlayerPosition;
    private GameObject myPlayer = null;
    private FloorDetector myFloorDetector;
    private AudioSource myAudioSource;
    private float Timer = 1f;
}
