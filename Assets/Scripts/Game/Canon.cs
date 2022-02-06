using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject ballInCanon;
    [SerializeField] Transform ballPos;
    [SerializeField] Transform target;
    private bool canonReload;
    [SerializeField] private float canonReloadTime = 3f;
    [SerializeField] private float force = 10f;
    void Start()
    {
        
    }

    
    public void Fire()
    {
        if (!canonReload)
        {
            ballInCanon.SetActive(false);
            canonReload = true;
            Invoke(nameof(ResetBallInCanon), canonReloadTime);
            var ball = Instantiate(ballPrefab, ballPos.position, Quaternion.identity);
            var rb = ball.GetComponent<Rigidbody>();
            rb.AddForce((target.position - ball.transform.position) * force, ForceMode.Impulse);
        }        
    }
    private void ResetBallInCanon()
    {
        ballInCanon.SetActive(true);
        canonReload = false;
    }
}
