using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{

    public Transform firePoint;
    public GameObject muzzlePrefab;
    [HideInInspector] public Shooting reloadState;
    [HideInInspector] public bool isRealoading;
    [HideInInspector] public int bulletsLeft;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isRealoading = this.transform.parent.GetComponent<Shooting>().getReloadState();
        bulletsLeft = this.transform.parent.GetComponent<Shooting>().getMagSize();
      
        if(isRealoading == false) {
            if(Input.GetButtonDown("Fire1") && bulletsLeft != 0) {

                Invoke("BulletMuzzle", .1f);
            }
        }
    }

    void BulletMuzzle() {
        GameObject effect = Instantiate(muzzlePrefab, firePoint.position, firePoint.rotation);
        Destroy(effect, 0.03f);
    }
}
