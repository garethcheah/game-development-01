using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayAndLoopExamples : MonoBehaviour
{
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        InitArray();
        ExampleForLoop();
        WhileLoopExample();
        ForEachExample();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitArray()
    {
        enemies = new GameObject[3];
        enemies[0] = GameObject.Find("Enemy1");
        enemies[1] = GameObject.Find("Enemy2");
        enemies[2] = GameObject.Find("Enemy3");
    }

    private void ExampleForLoop()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Value of i=" + i);
        }
    }

    private void WhileLoopExample()
    {
        int i = 0;

        while (i < 5)
        {
            i++;
            Debug.Log("Value of i=" + i);
        }

        bool exitLoop = false;

        while (!exitLoop)
        {
            // would loop until exitLoop = true
            exitLoop = true;
        }
    }

    private void ForEachExample()
    {
        string[] names = { "Steve", "Kevin", "Barb" };

        foreach (string name in names)
        {
            Debug.Log("Name: " +  name);
        }
    }
}
