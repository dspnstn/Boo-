using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _target;
    [SerializeField]    private GameObject _actManager;
    private ActivateManager _actM;

    void Start()
    {
        _actM = _actManager.GetComponent<ActivateManager>();
        if(!_actM)
        {
            Debug.LogError("The AM is void on the Player.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                _target = hit.transform;
                WhoWeHit(_target.tag);
            }
        }
    }

    void WhoWeHit(string tag)
    {
        switch (tag)
        {
            case "Bed":
                _actM.ActivateEyes();
                StartCoroutine(CursorRoutine());
                _target.tag = "Untagged";
                break;
            case "Switch":
                _actM.ActivateSwitch();
                StartCoroutine(CursorRoutine());
                _target.tag = "Untagged";
                break;
            case "Chair":
                _actM.ActivateChair();
                StartCoroutine(CursorRoutine());
                _target.tag = "Untagged";
                break;            
            default:
                //Do nothing
                break;
        }        
    }

    IEnumerator CursorRoutine()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yield return new WaitForSeconds(4.5f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
