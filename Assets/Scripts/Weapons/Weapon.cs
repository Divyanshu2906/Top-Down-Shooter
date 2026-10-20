using System.Collections;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    InputActions inputActions;
    Bullet bullet;
    [SerializeField] WeaponData weaponData;
    [SerializeField] Transform firepoint;

    int CurrentAmmo;
    bool isReloading;
    float NextFireTime = 0f ; 

    void Awake()
    {
        inputActions = new InputActions();
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void Start()
    {
        CurrentAmmo = weaponData.MagazineSize;
    }

    void Update()
    {
        HandleShooting();
        HandleReload();
    }

    private void HandleReload()
    {
        if(!isReloading && CurrentAmmo < weaponData.MagazineSize)
        {
            if (inputActions.Player.Reload.triggered)
            {
                if (!isReloading)
                {
                    StartCoroutine(Reload());
                }
            }
        }
    }

    private void HandleShooting()
    {
        if (isReloading) return;
        if (inputActions.Player.Fire.triggered)
        {
            if (Time.time >= NextFireTime)
            {
                if (CurrentAmmo > 0)
                {
                    NextFireTime = Time.time + (1f / weaponData.FireRate);
                    CurrentAmmo--;
                    GameObject bulletObject = Instantiate(weaponData.BulletPrefab, firepoint.position, firepoint.rotation);
                    bulletObject.GetComponent<Bullet>().setdamage(weaponData.Damage);
                }

                else
                {
                    Debug.Log("No Ammo");
                    
                    
                }
            }
        }
    }

    IEnumerator Reload()
    {
        Debug.Log("reloading");
        isReloading = true;
        yield return new WaitForSeconds(weaponData.ReloadTime);
        CurrentAmmo = weaponData.MagazineSize;
        isReloading = false;
    }

    void OnDisable()
    {
        inputActions.Disable();
    }
}
