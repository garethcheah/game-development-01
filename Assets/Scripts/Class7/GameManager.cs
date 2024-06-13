using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _numberOfPinsHit = 0;

    [SerializeField] private PlayerController _playerController;

    /// <summary>
    /// Increments count every time the ball hits a pin
    /// </summary>
    public void IncrementPinsHitByBall()
    {
        _numberOfPinsHit++;
        Debug.Log("Number of pins hit: " + _numberOfPinsHit);
    }

    public void StartThrow()
    {
        _playerController.StartAim();
    }
}
