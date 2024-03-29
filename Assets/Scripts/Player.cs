﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float paddingX = 100f;
    [SerializeField] float paddingTop = 300f;
    [SerializeField] float paddingBottom = 100f;

    [SerializeField] Image FrontShoot;
    [SerializeField] Image SideShoot;
    [SerializeField] Image Body;
    [SerializeField] Image Rocket;
    [SerializeField] GameObject mainBulletPrefab;
    [SerializeField] GameObject frontBulletPrefab;
    [SerializeField] GameObject sideBulletPrefab;

    [SerializeField] Transform gameSpace;

    public int score;
    private bool rocket;
    private bool frontShoot;
    private bool sideShoot;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    Coroutine mainBulletFiringCoroutine;
    Coroutine frontBulletFiringCoroutine;
    Coroutine sideBulletFiringCoroutine;

    private void Awake()
    {
        RocketHide();
        FrontShootHide();
        SideShootHide();
        SetupMoveBoundaries();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        MainBulletFire();
        if (frontShoot)
        {
            FrontBulletFire();
        }
        if (sideShoot)
        {
            SideBulletFire();
        }
        
    }

    private void SideBulletFire()
    {
        if (Input.GetKeyDown("space"))
        {
            sideBulletFiringCoroutine = StartCoroutine(SideBulletsFireContinuously());
        }
        if (Input.GetKeyUp("space"))
        {
            StopCoroutine(sideBulletFiringCoroutine);
        }
    }

    private void FrontBulletFire()
    {
        if (Input.GetKeyDown("space"))
        {
            frontBulletFiringCoroutine = StartCoroutine(FrontBulletsFireContinuously());
        }
        if (Input.GetKeyUp("space"))
        {
            StopCoroutine(frontBulletFiringCoroutine);
        }
    }

    private void MainBulletFire()
    {
        if (Input.GetKeyDown("space"))
        {
            mainBulletFiringCoroutine = StartCoroutine(MainBulletsFireContinuously());
        }
        if (Input.GetKeyUp("space"))
        {
            StopCoroutine(mainBulletFiringCoroutine);
        }
    }

    private void Move()
    {
        // Move object based on mouse coordinates
        float mouseX = Mathf.Clamp(Input.mousePosition.x, xMin, xMax);
        float mouseY = Mathf.Clamp(Input.mousePosition.y, yMin, yMax);
        transform.position = Camera.main.ScreenToWorldPoint(new Vector2(mouseX, mouseY));
    }

    // Main Bullet
    IEnumerator MainBulletsFireContinuously()
    {
        while (true)
        {
            // Create a new bullet where the mouse is
            GameObject mainBullet = Instantiate(mainBulletPrefab, transform.position, Quaternion.identity) as GameObject;
            // Set a gameSpace as the bullet's parent
            mainBullet.transform.SetParent(gameSpace);
            // Conenct to the script of the bullet
            MainBullet mainBulletScript = mainBullet.GetComponent<MainBullet>();
            // Move the bullet to the head of its gun
            mainBullet.transform.Translate(mainBulletScript.GetOffset());
            // Move the bullet in its direction until it hits something
            mainBulletScript.Move();
            // Repeat every fireRate times a seconds
            yield return new WaitForSeconds(mainBulletScript.GetFireRate());
        }
    }

    // Front Bullets
    IEnumerator FrontBulletsFireContinuously()
    {
        while(true)
        {
            // --- RIGHT BULLET
            // Create a new bullet where the mouse is
            GameObject frontBullet1 = Instantiate(frontBulletPrefab, transform.position, Quaternion.identity) as GameObject;
            GameObject frontBullet2 = Instantiate(frontBulletPrefab, transform.position, Quaternion.identity) as GameObject;
            // Set a gameSpace as the bullet's parent
            frontBullet1.transform.SetParent(gameSpace);
            frontBullet2.transform.SetParent(gameSpace);
            // Conenct to the script of the bullet
            FrontBullet frontBulletScript1 = frontBullet1.GetComponent<FrontBullet>();
            FrontBullet frontBulletScript2 = frontBullet2.GetComponent<FrontBullet>();
            // Move the bullet to the head of its gun
            frontBullet1.transform.Translate(frontBulletScript1.GetOffsetLeft());
            frontBullet2.transform.Translate(frontBulletScript2.GetOffsetRight());
            // Move the bullet in its direction until it hits something
            frontBulletScript1.Move();
            frontBulletScript2.Move();
            // Repeat every fireRate times a seconds
            yield return new WaitForSeconds(frontBulletScript1.GetFireRate());
        }
    }

    // Side Bullets
    IEnumerator SideBulletsFireContinuously()
    {
        while (true)
        {
            // --- SIDE BULLET
            // Create a new bullet where the mouse is
            // 13 is an angle of rotation for the bullet to match the gun direction
            GameObject sideBullet1 = Instantiate(sideBulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 13))) as GameObject;
            GameObject sideBullet2 = Instantiate(sideBulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -13))) as GameObject;
            // Set a gameSpace as the bullet's parent
            sideBullet1.transform.SetParent(gameSpace);
            sideBullet2.transform.SetParent(gameSpace);
            // Conenct to the script of the bullet
            SideBullet sideBulletScript1 = sideBullet1.GetComponent<SideBullet>();
            SideBullet sideBulletScript2 = sideBullet2.GetComponent<SideBullet>();
            // Move the bullet to the head of its gun
            sideBullet1.transform.Translate(sideBulletScript1.GetOffsetLeft());
            sideBullet2.transform.Translate(sideBulletScript2.GetOffsetRight());
            // Move the bullet in its direction until it hits something
            sideBulletScript1.MoveLeft();
            sideBulletScript2.MoveRight();
            // Repeat every fireRate times a seconds
            yield return new WaitForSeconds(sideBulletScript1.GetFireRate());
        }
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + paddingX;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddingX;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddingBottom;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - paddingTop;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Weapon weaponScript = collision.gameObject.GetComponent<Weapon>();
            weaponScript.CollectWeapon();
            CollectNewWeapon(weaponScript.GetWeaponType());
        }
    }

    private void CollectNewWeapon(string weaponType)
    {
        switch (weaponType)
        {
            case "front":
                frontShoot = true;
                FrontShootShow();
                break;
            case "side":
                sideShoot = true;
                SideShootShow();
                break;
            case "rocket":
                rocket = true;
                RocketShow();
                break;
        }
    }

    // Hide weapons
    public void FrontShootHide()
    {
        FrontShoot.enabled = false;
    }
    public void SideShootHide()
    {
        SideShoot.enabled = false;
    }
    public void RocketHide()
    {
        Rocket.enabled = false;
    }
    // Show weapons
    public void FrontShootShow()
    {
        FrontShoot.enabled = true;
    }
    public void SideShootShow()
    {
        SideShoot.enabled = true;
    }
    public void RocketShow()
    {
        Rocket.enabled = true;
    }
}
