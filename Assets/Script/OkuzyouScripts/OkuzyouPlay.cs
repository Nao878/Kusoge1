using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OkuzyouPlay : MonoBehaviour
{
    public float speed = 1.8f;
    private Rigidbody2D rb = null;
    public GameObject massagePanel, aibouPic,akanaiText,sikabaneText,zihankiText;
    private bool moveCheck = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) && moveCheck)
        {
            rb.velocity = new Vector2(0, speed);
            AibouController.aibouStop = false;
        }

        if (Input.GetKey(KeyCode.DownArrow) && moveCheck)
        {
            rb.velocity = new Vector2(0, -speed);
            AibouController.aibouStop = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && moveCheck)
        {
            rb.velocity = new Vector2(-speed, 0);
            AibouController.aibouStop = false;
        }

        if (Input.GetKey(KeyCode.RightArrow) && moveCheck)
        {
            rb.velocity = new Vector2(speed, 0);
            AibouController.aibouStop = false;
        }

        if (!Input.anyKey)
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            ButtonClick();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Untagged")
        {
            massagePanel.SetActive(true);
            aibouPic.SetActive(true);
            moveCheck = false;
            rb.velocity = new Vector2(0, 0);
            Invoke("AibouStop",0.1f);
        }

        if (other.gameObject.tag == "Finish")
        {
            akanaiText.SetActive(true);
            sikabaneText.SetActive(false);
            zihankiText.SetActive(false);
        }
        if (other.gameObject.name == "ObShikabane")
        {
            sikabaneText.SetActive(true);
            akanaiText.SetActive(false);
            zihankiText.SetActive(false);
        }
        if (other.gameObject.name == "ObjZihanki")
        {
            zihankiText.SetActive(true);
            akanaiText.SetActive(false);
            sikabaneText.SetActive(false);
        }
    }

    public void ButtonClick()
    {
        moveCheck = true;
        massagePanel.SetActive(false);
        aibouPic.SetActive(false);
    }

    void AibouStop()
    {
        AibouController.aibouStop = true;
    }
}