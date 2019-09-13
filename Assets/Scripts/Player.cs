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

    [SerializeField] Transform gameSpace;

    public int score;
    private bool rocket;
    private bool frontShoot;
    private bool sideShoot;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    Coroutine firingCoroutine;

    private void Awake()
    {
        FrontShootHide();
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
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    public void Move()
    {
        // Move object based on mouse coordinates
        float mouseX = Mathf.Clamp(Input.mousePosition.x, xMin, xMax);
        float mouseY = Mathf.Clamp(Input.mousePosition.y, yMin, yMax);
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0));
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject mainBullet = Instantiate(mainBulletPrefab, transform.position, Quaternion.identity) as GameObject;
            mainBullet.transform.SetParent(gameSpace);
            MainBullet mainBulletScript = mainBullet.GetComponent<MainBullet>();
            Debug.Log(mainBulletScript.GetSpeed());
            mainBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, mainBulletScript.GetSpeed());
            yield return new WaitForSeconds(mainBulletScript.GetFireRate());
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
