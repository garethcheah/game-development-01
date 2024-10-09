using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    public GameObject[] nodeObjects;
    public float minSize = 0.1f;
    public float maxSize = 1.0f;
    public float fraction = 0.75f;
    public float fractalAngle = 30.0f;
    public int count = 0;
    public Vector3 startPos;
    public Vector3 startDirection;

    private void Start()
    {
        GenerateFractal(startPos, Vector3.zero, maxSize);
    }

    private void GenerateFractal(Vector3 startPosition, Vector3 angle, float size)
    {
        if (size > minSize)
        {
            int randomIndex = 0;
            float randomAngle = 0.0f;

            if (count > 20)
            {
                randomIndex = Random.Range(1, nodeObjects.Length);
            }

            if (count > 0)
            {   
                randomAngle = Random.Range(-15.0f, 15.0f);
            }

            Transform baseNode = Instantiate(nodeObjects[randomIndex]).transform;
            
            baseNode.position = startPosition;

            baseNode.Rotate(new Vector3(angle.x + randomAngle, angle.y + randomAngle, angle.z + randomAngle));
            baseNode.localScale = Vector3.one * size;

            Vector3 nodeEndPosition = startPosition + baseNode.up * size;

            GenerateFractal(nodeEndPosition, baseNode.eulerAngles + new Vector3(fractalAngle, 0, 0), size * fraction);
            GenerateFractal(nodeEndPosition, baseNode.eulerAngles + new Vector3(-fractalAngle, 0, 0), size * fraction);
            GenerateFractal(nodeEndPosition, baseNode.eulerAngles + new Vector3(0, 0, fractalAngle), size * fraction);
            GenerateFractal(nodeEndPosition, baseNode.eulerAngles + new Vector3(0, 0, -fractalAngle), size * fraction);

            count++;
        }
    }
}
