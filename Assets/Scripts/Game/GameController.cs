using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject canon;
    [SerializeField] private Joystick joystick;
    [SerializeField] float _rotateSpeed = 50;
    [SerializeField] GameObject winWindow;
    float previousRotY;
    Quaternion rot;

    public static GameController instance;
    void Start()
    {
        if (null == instance) instance = this;
        else Destroy(gameObject);
        rot = canon.transform.rotation;
    }

    private void Update()
    {
        rot = canon.transform.rotation;
        if (rot.y < 0.5f && joystick.Horizontal > 0)
        {
           canon.transform.Rotate(Vector3.up, joystick.Horizontal * _rotateSpeed * Time.deltaTime);
        }
        else if(rot.y > -0.5f && joystick.Horizontal < 0)
        {
            canon.transform.Rotate(Vector3.up, joystick.Horizontal * _rotateSpeed * Time.deltaTime);
        }
    }

    public void Reload()
    {
        winWindow.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void Win()
    {
        winWindow.SetActive(true);
    }

    public void TouchDown()
    {
        previousRotY = rot.y;
    }
    public void TouchUp()
    {
        if(previousRotY == rot.y)
        {
            CanonFire();
        }
    }

    private void CanonFire()
    {
        canon.GetComponent<Canon>().Fire();
    }

    public void Exit()
    {
        Application.Quit();
    }

}
