using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 2;
    private Animator deathAnim;
    public GameObject enemy;

    [HideInInspector]public Sprite enemySprite;
    public Sprite corpse;
    private GameObject cloneBullet;

    enum EnemyStates {
        idle,
        combat,
        dead,
    }
    EnemyStates enemyCurrentState;

    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentState = EnemyStates.idle;
        
        deathAnim = this.GetComponent<Animator>();
        enemySprite = this.gameObject.GetComponent<Sprite>();

        if(this.gameObject.name == "Enemy_Steady") {
            this.gameObject.GetComponent<Follow>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            Debug.Log("ENEMY DEAD " + enemy.name);
            enemyCurrentState = EnemyStates.dead;
            enemy.GetComponent<Follow>().enabled = false;
            enemy.GetComponent<EnemyPatrol>().enabled = false;
            enemySprite = corpse;
            deathAnim.SetBool("isDead", true);
            enemyCurrentState = EnemyStates.dead;
            Destroy(this.transform.GetComponent<Collider2D>());
            Invoke("ClearDead", 5f);
        }
    }

    void ClearDead() {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        cloneBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        if (collision.gameObject.tag == "Bullet") {
            this.health--;
        }
        Destroy(cloneBullet);
    }

    void PerformDead() {
        SoundManager.PlaySound("dead");
    }

}
