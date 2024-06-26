using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGamePlaying = false;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private UIManager _uiManager;
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
        Invoke("NextThrow", 3.0f); // 3-second delay before next throw
    }

    private void NextThrow()
    {
        int fallenPins = CalculateFallenPins();

        _scoreManager.SetFrameScore(fallenPins);

        if (_scoreManager.currentFrame == 0)
        {
            _uiManager.ShowGameOver(_scoreManager.CalculateTotalScore());
        }

        int frameTotal = 0;

        // Calculate frame totals for UI
        for (int i = 0; i < _scoreManager.currentFrame - 1; i++)
        {
            frameTotal += _scoreManager.GetFrameScore()[i];
            _uiManager.SetFrameTotal(i + 1, frameTotal);
        }

        StartThrow();
    }
}
