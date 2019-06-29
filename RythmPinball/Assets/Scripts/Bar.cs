using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField]
    private bool isLeft;
    private int state = 0;
    private float rotSpeed=500, maxDeg = 260, minDeg = 285, timeStep = 0.02f, deg;
    private KeyCode inputKey = KeyCode.A;
    //private Rigidbody2D rig;
    private Vector3 pos = new Vector3(-1.8f, -2, 0);

    // Start is called before the first frame update
    void Start()
    {
        //rig = GetComponent<Rigidbody2D>();
        if (!isLeft)
        {
            rotSpeed *= -1;
            maxDeg = 75;
            minDeg = 100;
            inputKey = KeyCode.D;
            pos = new Vector3(1.8f, -2, 0);
        }
        deg = isLeft ? maxDeg : minDeg;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = pos;
        if (Input.GetKeyDown(inputKey))
        {
            state = 1;
        }
        else if (Input.GetKeyUp(inputKey))
        {
            state = -1;
        }
    }

    private void FixedUpdate()
    {
        deg += state * rotSpeed * timeStep;
        if (deg > minDeg)
        {
            state = 0;
            deg = minDeg;
        }
        else if (deg < maxDeg)
        {
            state = 0;
            deg = maxDeg;
        }
        transform.eulerAngles = Vector3.forward * deg;
    }
}
