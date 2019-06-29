using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score = 0, rank = 0, stageCount=2;
    [SerializeField]
    private int[] rankUp;
    private float interval=3.8f;
    private Color[] bgColor = {Color.green, Color.cyan, Color.yellow, new Color(1, 0.6f, 0.4f, 1)};
    [SerializeField]
    private GameObject[] stages;
    [SerializeField]
    TextMeshProUGUI difficulty, scoreText;

    private int count = -1;
    public static int result = 0;

    public bool gameEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Scheduler.AddEvent(ChangeStage, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd)
        {
            result = score;
            gameEnd = false;
            //end scene
            SceneManager.LoadScene("End");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Title");
        }
    }

    private void ChangeStage()
    {
        if(count > -1) stages[count].SetActive(false);
        count = (count + 1) % stageCount;
        stages[count].SetActive(true);
       Camera.main.backgroundColor = bgColor[count];

        Scheduler.AddEvent(ChangeStage, interval);
    }

    public void AddScore(int point)
    {
        Debug.Log("add point");
        score += point;
        scoreText.text = score.ToString();
        if (score > rankUp[rank])
        {
            switch (rank)
            {
                case 0:
                    stageCount = 4;
                    interval = 1.9f;
                    difficulty.text = "HARD";
                    break;
                case 1:
                    rank--;
                    break;
            }
            rank++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ball")
        {
            collision.gameObject.GetComponent<Ball>().Respawn();
            score -= 500;
            scoreText.text = score.ToString();
        }
    }
}
