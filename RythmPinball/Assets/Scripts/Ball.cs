using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rig;
    private bool sleep = false;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (sleep)
        {
            transform.position = Vector3.zero;
        }    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rig.velocity.sqrMagnitude > 400)
        {
            rig.velocity *= 20 / rig.velocity.magnitude;
        }
    }

    public void Respawn()
    {
        sleep = true;
        Scheduler.AddEvent(() =>
        {
            sleep = false;
            rig.velocity = Vector3.zero;
        }, 1);
        rig.velocity = Vector3.zero;
    }
}
