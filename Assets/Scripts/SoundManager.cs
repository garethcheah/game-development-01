using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _sourceBall, _sourceUI;
    [SerializeField] private AudioClip _clipRolling, _clipStrike;

    public void PlaySound(string soundClip)
    {
        switch (soundClip)
        {
            case "throw":
                _sourceBall.PlayOneShot(_clipRolling);
                break;
            case "strike":
                _sourceUI.PlayOneShot(_clipStrike);
                break;
        }
    }
}
