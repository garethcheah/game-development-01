using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGamePlaying = false;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ScoreManager _scoreManager;
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

    public int CalculateFallenPins()
    {
        int count = 0;

        foreach (Pin pin in pins)
        {
            if (pin.isFallen && pin.gameObject.activeSelf)
            {
                count++;
                pin.gameObject.SetActive(false);
            }
        }

        Debug.Log("Number of pins hit: " + count);

        return count;
    }

    public void StartThrow()
    {
        _playerController.StartAim();
    }

    public void ResetAllPins()
    {
        foreach (Pin pin in pins)
        {
            pin.ResetPin();
        }
    }

    public void SetNextThrow()
    {
        Invoke("NextThrow", 3.0f);
    }

    private void NextThrow()
    {
        if (_scoreManager.currentFrame == 0)
        {
            Debug.Log("Total score: " + _scoreManager.CalculateTotalScore().ToString());
        } else
        {
            _scoreManager.SetFrameScore(CalculateFallenPins());
            _scoreManager.CalculateTotalScore();
            StartThrow();
        }
    }
}
