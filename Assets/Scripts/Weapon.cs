using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private string weaponType;
    private float weaponMoveSpeed = 400f;

    // Type set and get
    public void SetWeaponType(string typeOfWeapon)
    {
        weaponType = typeOfWeapon;
    }
    public string GetWeaponType()
    {
        return weaponType;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -weaponMoveSpeed);
    }

    public void CollectWeapon()
    {
        Destroy(gameObject);
    }

}
