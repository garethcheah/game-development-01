using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detects when ball enters the Ball Return collider
    private void OnTriggerEnter(Collider other)
    {
        // Set bool back to false to allow another bowling ball to instantiate
        playerController.isReleased = false;
    }
}
