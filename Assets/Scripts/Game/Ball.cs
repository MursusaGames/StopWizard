using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wizard"))
        {
            Destroy(other.gameObject);
            GameController.instance.Win();
        }
        if (other.gameObject.CompareTag("Cube"))
        {
            Destroy(other.gameObject,0.1f);
        }
    }


}
