using System.Collections;
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

    private void Awake()
    {
        SideShootHide();
        RocketHide();
        SetupMoveBoundaries();
    }

    private void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        MainBulletFire();
        FrontBulletFire();
    }

    private void FrontBulletFire()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        {
            frontBulletFiringCoroutine = StartCoroutine(FrontBulletsFireContinuously());
        }
        if (Input.GetButtonUp("Fire1") || Input.GetKeyUp("space"))
        {
            StopCoroutine(frontBulletFiringCoroutine);
        }
    }

    private void MainBulletFire()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        {
            mainBulletFiringCoroutine = StartCoroutine(MainBulletsFireContinuously());
        }
        if (Input.GetButtonUp("Fire1") || Input.GetKeyUp("space"))
        {
            StopCoroutine(mainBulletFiringCoroutine);
        }
    }

    public void Move()
    {
        // Move object based on mouse coordinates
        float mouseX = Mathf.Clamp(Input.mousePosition.x, xMin, xMax);
        float mouseY = Mathf.Clamp(Input.mousePosition.y, yMin, yMax);
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0));
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

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + paddingX;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddingX;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddingBottom;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - paddingTop;
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
