using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float maxX = -17.93f;
    public float speedScroll = 0.01f;
    private float currentPositionX = 0f;
    // Update is called once per frame
    void Update()
    {
        currentPositionX -= speedScroll;
        this.gameObject.transform.position = new Vector3(currentPositionX, 0, 0);
        {
            if (Mathf.Abs(currentPositionX) >= Mathf.Abs(maxX))
            {
                this.gameObject.transform.position = new Vector3(17.93f, 0, 0);
                currentPositionX = 17.93f;
            }
        }
    }
}
