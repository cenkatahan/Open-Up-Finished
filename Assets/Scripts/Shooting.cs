using UnityEngine;
using TMPro;


public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 40f;
    [HideInInspector] public int magSize;
    [HideInInspector] public Animator reloadAnim;
    public bool isReloading;
    //public GameObject muzzleAnim;

    public const int FULL_MAG = 7;
    [HideInInspector]public const int EMPTY_MAG = 0;

    public GameObject bulletCountHUD;
    [HideInInspector] public string bulletsLeft;


    // Start is called before the first frame update
    void Start()
    {
        magSize = FULL_MAG;
        reloadAnim = GetComponent<Animator>();
        isReloading = false;

    }

    // Update is called once per frame
    void Update()
    {

        //Shoot with left mouse
        if (isReloading == false) {
            if (Input.GetButtonDown("Fire1") && magSize != EMPTY_MAG) {
                Invoke("Shoot", .1f);
            }
            bulletCountHUD.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = magSize.ToString();
        }

        if(magSize == EMPTY_MAG && Input.GetButtonDown("Fire1")) {
            SoundManager.PlaySound("empty_mag");
        }

        //Reload Animation
        if (Input.GetKey(KeyCode.R) && magSize != FULL_MAG) {
            reloadAnim.SetBool("isMagEmpty", true);
            magSize = FULL_MAG;
            isReloading = true;
        } else {
            reloadAnim.SetBool("isMagEmpty", false);
            Invoke("PerformReload", 3f);
        }

    }

    void Shoot() {
        SoundManager.PlaySound("fire");
        magSize--;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void PerformReload() {
        isReloading = false;
    }

    public bool getReloadState() {
        return isReloading;
    }

    public int getMagSize() {
        return magSize;
    }

    void PerformRifleReload() {
        SoundManager.PlaySound("reloading");
    }

}
