using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;

    private Rigidbody2D enemyRb;

    public Transform[] moveSpots;
    private int randomSpot;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = 0;
        enemyRb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        //direction change according to spots positions
        Vector3 direction = moveSpots[randomSpot].position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemyRb.rotation = angle;

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < .2f) {
            
            randomSpot++;
            randomSpot = randomSpot % moveSpots.Length;
        }
    }

}
