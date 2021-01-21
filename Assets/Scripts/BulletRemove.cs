using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemove : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Objects") {
            SoundManager.PlaySound("bullet_surface_hit");

        }
        Destroy(gameObject);
    }

}
