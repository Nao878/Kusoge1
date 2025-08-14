using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaitiScript : MonoBehaviour
{
    [SerializeField] string nextScene;
    private string enemyTag = "enemy";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == enemyTag)
        {
            Debug.Log("–î‚É“–‚½‚Á‚½");
            SceneManager.LoadScene(nextScene);
        }
    }
}
