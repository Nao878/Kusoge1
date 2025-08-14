using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    TextMeshProUGUI timerText;
    private float time = 98.0f;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        Debug.Log(timerText);
        timerText.text = time.ToString();
    }

    void Update()
    {
        time -= Time.deltaTime;
        timerText.text = time.ToString("F0") + "•b";
        if(time < 85.0f)
        {
            Debug.Log("ao");
            SceneManager.LoadScene("TitleScene");
        }
    }
}
