using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    float touchXDelta = 0;
    float newX = 0;
    float newYRotate = -180.0f;
    public float xSpeed;
    public float limitX;
    public GameObject Player;

    bool kontrol = false;
    Button btn;
    public Button StartButton;
    public Button QuitButton;
    public GameObject GameName;
    public GameObject Score;

    void Start()
    {
        btn = StartButton.GetComponent<Button>();
        btn.onClick.AddListener(StartBtn);
        Player.transform.Rotate(0.0f, newYRotate, 0.0f);
    }

    void Update()
    {
        SwipeCheck();
    }

    private void SwipeCheck()
    {
        if (kontrol == true)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
            }

            else if (Input.GetMouseButton(0))
            {
                touchXDelta = Input.GetAxis("Mouse X");
            }

            else
            {
                touchXDelta = 0;
            }

            newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
            newX = Mathf.Clamp(newX, -limitX, limitX);

            Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
            transform.position = newPosition;
        }
        
    }

    public void StartBtn()
    {
        kontrol = true;
        StartButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
        GameName.gameObject.SetActive(false);
        Score.gameObject.SetActive(true);
    }

    public void QuitBtn()
    {
        Debug.Log("Oyundan Çýkýlýyor..");
        Application.Quit();
    }
}
