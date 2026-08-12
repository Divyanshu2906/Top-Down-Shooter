using System.Collections;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    InputActions inputActions;
    [SerializeField] Transform firepoint;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] int MagazineSize = 12;
    [SerializeField] float ReloadTime = 1.5f;
    [SerializeField] float FireRate = 2f;
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
        CurrentAmmo = MagazineSize;
    }

    void Update()
    {
        HandleShooting();
        HandleReload();
    }

    private void HandleReload()
    {
        if(!isReloading && CurrentAmmo < MagazineSize)
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
                    NextFireTime = Time.time + (1f / FireRate);
                    CurrentAmmo--;
                    Instantiate(BulletPrefab, firepoint.position, firepoint.rotation);
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
        yield return new WaitForSeconds(ReloadTime);
        CurrentAmmo = MagazineSize;
        isReloading = false;
    }

    void OnDisable()
    {
        inputActions.Disable();
    }
}
