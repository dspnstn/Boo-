using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]    private Transform _target;
    private float _speed = 2.5f;

    void Update()
    {
        float velocity = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, _target.position, velocity);
        if (transform.position.y >= 4.3f)
        {
            GameObject.FindGameObjectWithTag("VG").GetComponent<Portrait>().ActivateHorror();
            Destroy(this.gameObject, 1.0f);
        }
    }        
}
