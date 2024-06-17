using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{
    // Start is called before the first frame update
    int c = 11;
    int b = 12;



    void OnIntCompare()
    {
        if (c == b)
        {
            Debug.Log("Both numbers are equal.");
        }
        else
        {
            if (c > b)
                Debug.Log($"The larger number is: {c}");
            else
                Debug.Log($"The larger number is: {b}");
        }
    }

    void OnLoopNums()
    {
        for (int i  = 1; i <= 10; ++i)
        {
            Debug.Log($"{i}");
        }
    }


    void OnHelloWorld()

    {
        int count = 0;
        while (count < 10)
        {
            Debug.Log("Hello World"); count++;
        }
    }
       


    // Update is called once per frame
    void Update()
    {
        
    }
}
