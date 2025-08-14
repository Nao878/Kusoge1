using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDown2 : MonoBehaviour
{
    [SerializeField] float time2 = 10.0f;
    [SerializeField] string nextScene;

    void Update()
    {
        time2 -= Time.deltaTime;
        if(time2 < 0.0f)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
