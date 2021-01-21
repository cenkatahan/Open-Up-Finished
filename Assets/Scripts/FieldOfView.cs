using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius = 5;
    public float viewAngle = 135;
    Collider2D[] playerInRadius;
    public LayerMask obstacleMask, PlayerMask;
    public List<Transform> visiblePlayer = new List<Transform>();
    public static bool isMoving = false;


    // Update is called once per frame
    void FixedUpdate() {
        FindVisiblePlayer();
    }

    void FindVisiblePlayer() {
        playerInRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius);
        visiblePlayer.Clear();

        checkPlayerOnSight();

        for (int i = 0; i < playerInRadius.Length; i++) {
            Transform player = playerInRadius[i].transform;
            Vector2 dirPlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            if (Vector2.Angle(dirPlayer, transform.right) < viewAngle / 2) {
                float distancePlayer = Vector2.Distance(transform.position, player.position);

                if (!Physics2D.Raycast(transform.position, dirPlayer, distancePlayer, obstacleMask)) {
                    if (player.CompareTag("Player")) {
                        visiblePlayer.Add(player);
                        this.GetComponent<Follow>().enabled = true;
                        
                    }
                }
            }
        }
    }

    public Vector2 DirFromAngle(float angleDeg, bool global) {
        if (!global) {
            angleDeg += transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Cos(angleDeg * Mathf.Deg2Rad), Mathf.Sin(angleDeg * Mathf.Deg2Rad));
    }

    public void checkPlayerOnSight() {
        
        if(visiblePlayer.Count == 0) {
            this.GetComponent<Follow>().enabled = false;
        } 
    }
}
