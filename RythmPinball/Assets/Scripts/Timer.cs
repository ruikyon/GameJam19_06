using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI left;
    private int gameTime = 60;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var leftTime = gameTime - Time.time;
        if(leftTime < 0)
        {
            leftTime = 0;
            GameManager.Instance.gameEnd = true;
        }
        left.text = ((int)leftTime).ToString();
    }
}
