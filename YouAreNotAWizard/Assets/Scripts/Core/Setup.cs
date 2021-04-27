using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    int frameCount = 0;
    float dt = 0.0f;
    float fps = 0.0f;
    float updateRate = 2.0f; // updates per second
     
   
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 140;
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        dt += Time.deltaTime;
        if (dt > 1.0f/updateRate)
        {
            fps = frameCount / dt ;
            frameCount = 0;
            dt -= 1.0f/updateRate;
            // Debug.Log((int)fps + " fps");
        }
        
        
    }
}
