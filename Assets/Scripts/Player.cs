using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Spaceship;
    [SerializeField] Image FrontShoot;
    [SerializeField] Image SideShoot;
    [SerializeField] Image Body;
    [SerializeField] Image Rocket;

    public string[] weapons;

    public int score;
    private bool rocket;
    private bool frontShoot;
    private bool sideShoot;

    public void MoveSpaceship()
    {
        // Move object based on mouse coordinates
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }

    private void Awake()
    {
        FrontShootHide();
        SideShootHide();
        RocketHide();
    }

    private void Update()
    {
        MoveSpaceship();
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
