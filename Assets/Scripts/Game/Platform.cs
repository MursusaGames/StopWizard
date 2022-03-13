using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float deltaSpeed = 2f;
    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20f);
        var minSpeed = speed - deltaSpeed;
        var maxSpeed = speed + deltaSpeed;
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var pos = transform.position;
        pos.z += 0.002f * currentSpeed;
        transform.position = pos;
    }
}
