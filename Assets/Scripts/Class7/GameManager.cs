using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGamePlaying = false;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Pin[] pins;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        _isGamePlaying = true;
        StartThrow();
    }

    /// <summary>
    /// Increments count every time the ball hits a pin
    /// </summary>
    public void CalculateFallenPins()
    {
        int count = 0;

        foreach (Pin pin in pins)
        {
            if (pin.isFallen)
            {
                count++;
            }
        }

        Debug.Log("Number of pins hit: " + count);
    }

    public void StartThrow()
    {
        CalculateFallenPins();
        _playerController.StartAim();
    }
}
