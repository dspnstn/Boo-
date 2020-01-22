using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private Scene currentScene;
    private int index;
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        index = currentScene.buildIndex;
        Debug.Log(index);

        if (index == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscInput();
        }                
    }

    void OnEscInput()
    {       
        switch (index)
        {
            case 0:
                Application.Quit();
                break;
            case 1:
                SceneManager.LoadScene(0);
                break;
            case 2:
                SceneManager.LoadScene(0);
                break;
            default:
                Debug.LogError("Invalid scene index");
                break;
        }        
    }

    public void OnPositiveButton()
    {
        if (index < 2)
        {
            int nextIndex = index + 1;
            SceneManager.LoadScene(nextIndex);
        }
        else if (index == 2)
        {
            SceneManager.LoadScene(1);
        }      
    }

    public void OnNegativeButton()
    {
        Debug.Log("Exit");
        Application.Quit();

        if (index != 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
