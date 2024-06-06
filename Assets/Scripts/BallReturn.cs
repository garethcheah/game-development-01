using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
    private static string tagPlayerController = "PlayerController";

    [SerializeField]
    private PlayerController playerController;

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
        // Check if object that caused the trigger is a ball (PlayerController)
        if (other.gameObject.transform.parent.tag == tagPlayerController)
        {
            // Set bool back to false to allow another bowling ball to instantiate
            playerController.isReleased = false;
        }
    }
}
