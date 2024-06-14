using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private GameManager _gameManager;
    public int _totalScore;
    private int[] _frames = new int[10];
    private bool _isSpare = false;
    private bool _isStrike = false;

    public int currentFrame; //{ get; private set; }
    public int currentThrow; //{ get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        ResetScore();
    }

    public int CalculateTotalScore()
    {
        _totalScore = 0;

        foreach (int frame in _frames)
        {
            _totalScore += frame;
        }

        return _totalScore;
    }

    public void SetFrameScore(int score)
    {
        //Ball 1
        if (currentThrow == 1)
        {
            _frames[currentFrame - 1] += score;

            // Parallel check for spare
            if (_isSpare)
            {
                _frames[currentFrame - 2] += score;
                _isSpare = false;
            }

            if (score == 10)
            {
                if (currentFrame == 10)
                {
                    currentThrow++; // Wait for ball 2
                } else
                {
                    _isStrike = true;
                    currentFrame++; // Move to next frame as full score obtained
                }

                // Reset pins
                _gameManager.ResetAllPins();
            } else
            {
                currentThrow++; //wait for Ball 2
            }

            return;
        }

        //Ball 2
        if (currentThrow == 2)
        {
            _frames[currentFrame - 1] += score;

            if (_isStrike)
            {
                _frames[currentFrame - 2] += _frames[currentFrame - 1];
                _isStrike = false;
            }

            if (_frames[currentFrame - 1] == 10) // Is total frame score 10?
            {
                if (currentFrame == 10)
                {
                    currentThrow++; // Wait for ball 3
                } else
                {
                    _isSpare = true; // Because we are on the 2nd ball, this is where a spare is awarded. Spares are calculated on ball 1 (see above).
                    currentFrame++;
                    currentThrow = 1;
                }
            } else
            {
                if (currentFrame == 10)
                {
                    currentThrow = 0;
                    currentFrame = 0;
                } else
                {
                    currentFrame++;
                    currentThrow = 1;
                }
            }

            //Reset pins
            _gameManager.ResetAllPins();
            return;
        }

        //Ball 3
        if (currentThrow == 3 && currentFrame == 10)
        {
            _frames[currentFrame - 1] += score;
            currentFrame = 0;
            currentThrow = 0;
            return;
        }
    }

    private void ResetScore()
    {
        _totalScore = 0;
        currentFrame = 1;
        currentThrow = 1;
        _frames = new int[10];
    }
}
