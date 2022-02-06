using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject canon;
    [SerializeField] private Joystick joystick;
    [SerializeField] float _rotateSpeed = 50;
    float previousRotY;
    Quaternion rot;
    
    
    void Start()
    {
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
