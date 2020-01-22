using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portrait : MonoBehaviour
{
    [SerializeField]    private GameObject _scream, _buttons, _audio;
    private bool _over;

    void Update()
    {
        if (_over)
        {
            _buttons.SetActive(true);
            this.gameObject.tag = "Untagged";
        }
    }

    public void ActivateHorror()
    {        
        StartCoroutine(FlickRoutine());
    }

    IEnumerator FlickRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        _scream.SetActive(true);
        _audio.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _scream.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        _scream.SetActive(true);
        _scream.SetActive(false);
        _scream.SetActive(true);
        _scream.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        _over = true;
    }
}
