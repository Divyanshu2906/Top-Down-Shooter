using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] int magazinesize = 12;
    [SerializeField] float reloadtime = 1.5f;
    [SerializeField] float firerate = 2f;
    [SerializeField] GameObject bulletprefab;
    [SerializeField] int damage = 10;

    public int MagazineSize => magazinesize;
    public float ReloadTime => reloadtime;
    public float FireRate => firerate;
    public GameObject BulletPrefab => bulletprefab;
    public int Damage => damage;
}
