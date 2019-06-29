using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdder : MonoBehaviour
{
    [SerializeField]
    private int point;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ball")
        {
            GameManager.Instance.AddScore(point);
        }
    }
}
