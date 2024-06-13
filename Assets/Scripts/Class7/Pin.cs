using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StoreStartVectors();
    }

    // Update is called once per frame
    void Update()
    {
        if (HasChanged())
        {
            Debug.Log(transform.parent.name + " has changed position/rotation");
        }
    }

    // Need to account for pins that fall off the game area and continue to change position/rotation
    public bool HasChanged()
    {
        return transform.localPosition != _startPosition || transform.localRotation != _startRotation;
    }

    public void ResetPin()
    {
        _rb.velocity = Vector3.zero;
        transform.localRotation = _startRotation;
        transform.localPosition = _startPosition;
    }

    private void StoreStartVectors()
    {
        _startPosition = transform.localPosition;
        _startRotation = transform.localRotation;

        Debug.Log("Start position for " + transform.parent.name + ": " + _startPosition.ToString());
        Debug.Log("Start rotation for " + transform.parent.name + ": " + _startRotation.ToString());
    }
}
