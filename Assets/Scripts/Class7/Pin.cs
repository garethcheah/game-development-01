using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool isFallen;

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
        if (gameObject.activeSelf)
        {
            if (HasFallen() && !isFallen)
            {
                isFallen = true;
                Debug.Log(transform.parent.name + " has fallen.");
            }
        }
        
    }

    public bool HasFallen()
    {
        bool rotationChanged = Quaternion.Angle(_startRotation, transform.localRotation) > 5f;

        return rotationChanged;
    }

    public void ResetPin()
    {
        gameObject.SetActive(true);
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
        transform.localRotation = _startRotation;
        transform.localPosition = _startPosition;
        isFallen = false;
        _rb.isKinematic = false;
    }

    private void StoreStartVectors()
    {
        _startPosition = transform.localPosition;
        _startRotation = transform.localRotation;

        Debug.Log("Start position for " + transform.parent.name + ": " + _startPosition.ToString());
        Debug.Log("Start rotation for " + transform.parent.name + ": " + _startRotation.ToString());
    }
}
