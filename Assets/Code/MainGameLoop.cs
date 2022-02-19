using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameLoop : MonoBehaviour
{
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
            GameManager.SetCursor(LockMode.Unlock);
        else
            GameManager.SetCursor(LockMode.Lock);
    }

    void Update()
    {
        
    }
}
