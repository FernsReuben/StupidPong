using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minStopTime = 1f;
    public float maxStopTime = 3f;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(StopBall());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 direction = rb2d.velocity.normalized;
        rb2d.velocity = direction * speed;
    }

    private IEnumerator StopBall(){
        while (true){
            yield return new WaitForSeconds(Random.Range(minStopTime, maxStopTime));
            rb2d.velocity = Vector2.zero;
            yield return new WaitForSeconds(Random.Range(minStopTime, maxStopTime));
            rb2d.velocity = Random.insideUnitCircle.normalized * speed;
        }
    }
}
