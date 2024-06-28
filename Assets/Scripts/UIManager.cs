using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform _frameHolder;
    [SerializeField] private GameObject _UIStrikeMessage;
    [SerializeField] private GameObject _UISpareMessage;
    [SerializeField] private GameObject _UIGameOver;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private ParticleSystem _strikeEffect;
    [SerializeField] private Canvas _mobileCanvas;

    private FrameUI[] _frames;

    // Start is called before the first frame update
    void Start()
    {
        ResetFrameUIs();
        HideStrike();
        HideSpare();
        _UIGameOver.SetActive(false);
        _strikeEffect.gameObject.SetActive(false);
        _mobileCanvas.gameObject.SetActive(false);

#if UNITY_ANDROID
        _mobileCanvas.gameObject.SetActive(true);
#endif
    }

    public void ResetFrameUIs()
    {
        _frames = new FrameUI[_frameHolder.childCount];

        for (int i=0; i < _frameHolder.childCount; i++)
        {
            _frames[i] = _frameHolder.GetChild(i).GetComponent<FrameUI>();
            _frames[i].SetFrame(i + 1);
        }
    }

    public void SetFrameValues(int frame, int throwNumber, int score)
    {
        _frames[frame - 1].UpdateScore(throwNumber, score);
    }

    public void SetFrameTotal(int frame, int score)
    {
        _frames[frame - 1].UpdateTotal(score);
    }

    public void ShowStrike()
    {
        _UIStrikeMessage.SetActive(true);
        _soundManager.PlaySound("strike");
        _strikeEffect.gameObject.SetActive(true);
        Invoke("HideStrike", 2.0f);
    }

    private void HideStrike()
    {
        _UIStrikeMessage.SetActive(false);
        _strikeEffect.gameObject.SetActive(false);
    }

    public void ShowSpare()
    {
        _UISpareMessage.SetActive(true);
        Invoke("HideSpare", 2.0f);
    }

    private void HideSpare()
    {
        _UISpareMessage.SetActive(false);
    }

    public void ShowGameOver(int total)
    {
        _UIGameOver.SetActive(true);
        _scoreText.text = total.ToString();
    }
}
