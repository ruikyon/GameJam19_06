using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreShower : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText, returnText;
    private int score = 0;
    private bool show = false, fin = false;

    private void Start()
    {
        if (GameManager.result > 0)
        {
            Scheduler.AddEvent(() => show = true, 1);
        }
        else
        {
            returnText.gameObject.SetActive(true);
            fin = true;
        }
    }

    private void Update()
    {
        if(fin && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Title");
        }
    }

    void FixedUpdate()
    {
        if (!show) return;
        score+=50;
        scoreText.text = score.ToString();
        if(score == GameManager.result)
        {
            show = false;
            returnText.gameObject.SetActive(true);
            fin = true;
        }
    }
}
