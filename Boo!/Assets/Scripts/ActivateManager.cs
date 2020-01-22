using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateManager : MonoBehaviour
{
    [SerializeField]    private GameObject _eyes, _ghost, _lights, _lightsAudio, _chair, _pentLight, _ultScare;
    private int score;

    void Update()
    {
        if (score == 3)
        {
            StartCoroutine(WaitAndScareRoutine());
            score = 0;
        }        
    }

    IEnumerator WaitAndScareRoutine()
    {
        yield return new WaitForSeconds(4.0f);
        _ultScare.SetActive(true);
    }

    public void ActivateEyes()
    {        
        _eyes.SetActive(true);
        ++score;
    }

    public void ActivateGhost()
    {
        _ghost.SetActive(true);
        Destroy(_ultScare.gameObject);
    }

    public void ActivateSwitch()
    {
        _lights.SetActive(false);
        _lightsAudio.SetActive(true);
        ++score;
    }

    public void ActivateChair()
    {
        _chair.GetComponent<Chair>().MoveAside();
        ++score;
        _pentLight.SetActive(true);
    }        
}
