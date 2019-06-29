using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int point)
    {
        score += point;
    }

    private void RespawnBall(Transform ball)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ball")
        {
            RespawnBall(collision.transform);
            score -= 500;
        }
    }
}
