using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Vector2 movement;
    public Transform player;
    private Rigidbody2D rb;
    public float speed = .005f;

    public GameObject bulletPrefab;
    public Transform weaponPoint;
    public float bulletForce = 5f;

    private float timeBtwShots = 1;
    private float startTimeShoots;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        startTimeShoots = timeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        if(timeBtwShots <= 0) {
            Shoot();
            timeBtwShots = startTimeShoots;
        } else {
            timeBtwShots -= Time.deltaTime;
        }

    }


    private void FixedUpdate() {
        moveCharacter(movement);

    }
    void Shoot() {
        SoundManager.PlaySound("enemy_fire");
        GameObject bullet = Instantiate(bulletPrefab, weaponPoint.position, weaponPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weaponPoint.up * bulletForce, ForceMode2D.Impulse);

    }

    void moveCharacter(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
