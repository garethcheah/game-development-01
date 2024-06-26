using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtFrame, _txtThrow1, _txtThrow2, _txtThrow3, _txtTotal;
    [SerializeField] private bool _isFinalFrame;

    private int _frameScore = 0;

    public void UpdateScore(int throwNumber, int score)
    {
        if (!_isFinalFrame)
        {
            if (throwNumber == 1)
            {
                if (score == 10)
                {
                    _txtThrow1.text = "";
                    _txtThrow2.text = "X";
                }
                else
                {
                    _txtThrow1.text = score.ToString();
                    _frameScore += score;
                }
            }
            else if (throwNumber == 2)
            {
                _frameScore += score;

                if (_frameScore == 10)
                {
                    _txtThrow2.text = "/";
                }
                else
                {
                    _txtThrow2.text = score.ToString();
                }
            }
        }
        else // Is final frame
        {
            if (throwNumber == 1)
            {
                if (score == 10)
                {
                    _txtThrow1.text = "X";
                }
                else
                {
                    _txtThrow1.text = score.ToString();
                    _frameScore += score;
                }
            }
            else if (throwNumber == 2)
            {
                _frameScore += score;

                if (_frameScore == 10)
                {
                    _txtThrow2.text = "/";
                }
                else
                {
                    _txtThrow2.text = score == 10 ? "X" : score.ToString();
                }
            }
            else if (throwNumber == 3)
            {
                _txtThrow3.text = score == 10 ? "X" : score.ToString();
            }
        }
    }

    public void UpdateTotal(int total)
    {
        _txtTotal.text = total.ToString();
    }

    public void SetFrame(int frame)
    {
        _txtFrame.text = frame.ToString();
        _txtThrow1.text = "";
        _txtThrow2.text = "";
        _txtTotal.text = "";

        if (_isFinalFrame)
        {
            _txtThrow3.text = "";
        }
    }
}
