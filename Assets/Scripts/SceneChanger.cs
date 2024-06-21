using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int buildIndexToLoad = 1;

    public void ChangeScene()
    {
        SceneManager.LoadScene(buildIndexToLoad);
    }
}
