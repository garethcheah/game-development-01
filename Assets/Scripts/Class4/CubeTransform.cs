using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTransform : MonoBehaviour
{
    public float translateSpeed = 1f;
    public float rotateSpeed = 1f;
    public float translatedXAngleRotation = 90f;
    public float translatedYAngleRotation = 0f;
    public float translatedZAngleRotation = 0f;

    private Vector3 spawnPosition;
    private Vector3 rotationVector;
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Transform targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        //Store initial position of the game object
        spawnPosition = transform.localPosition;

        rotationVector.Set(translatedXAngleRotation, translatedYAngleRotation, translatedZAngleRotation);
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        TranslateCube();
        ChangeColour();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            translateSpeed = 0f;
        }
    }

    private void TranslateCube()
    {
        transform.Translate(targetPosition.localPosition * Time.deltaTime * translateSpeed, Space.World);
        transform.Rotate(rotationVector * Time.deltaTime * rotateSpeed, Space.Self);
    }

    private void ChangeColour()
    {
        if (translateSpeed == 0f && rotateSpeed == 0f)
        {
            meshRenderer.material.color = Color.black;
        }
        else if (translateSpeed == 0f) {
            meshRenderer.material.color = Color.red;
        }
        else if (translateSpeed >= 0.2f)
        {
            meshRenderer.material.color = Color.yellow;
        }
        else
        {
            meshRenderer.material.color = Color.green;
        }

        if (translateSpeed == 0.5f || rotateSpeed == 0.5f)
        {
            meshRenderer.material.color = Color.blue;
        }

        if (translateSpeed != 0f)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
}
