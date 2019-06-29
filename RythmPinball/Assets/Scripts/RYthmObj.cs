using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RYthmObj : MonoBehaviour
{
    private readonly float changeVel = 0.02f/0.2375f;
    private float scale= 1;
    private int counter=0;
    private bool flag = false, start = false;

    private void Start()
    {
        Scheduler.AddEvent(() => start = true, 0.2f);
    }

    void FixedUpdate()
    {
        if (!start) return;
        scale += (float)(flag ? -1 : 1) / 6;
        //Debug.Log(scale);
        transform.localScale = Vector3.one * scale;
        counter++;
        if (counter == 12)
        {
            counter = 0;
            flag = !flag;
        }
        transform.eulerAngles += Vector3.forward;
    }
}
