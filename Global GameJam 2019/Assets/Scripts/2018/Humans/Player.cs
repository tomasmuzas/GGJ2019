﻿using System.Collections;

using Assets.Scripts._2018.UI;

using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    Left, Right
}

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IMovable
{
    public Direction direction;
    public GameObject PowerUp;
    public GameObject SkillPrefab;

    public Buttons _buttons { get; set; }


    public HealthManager _healthManager { get; set; }

    [SerializeField]
    private float _speed;
    public float Speed { get { return _speed; } set { _speed = value; } }


    private new Rigidbody2D rigidbody;
    private Animator animator;

    public GameObject Mama = null;
    private bool shotgun;

    public bool canShoot = true;
    public float activeTime = 0.025f;

    public void Shoot()
    {
        if (SkillPrefab != null && canShoot)
        {
            if (shotgun)
            {
                var spread = 0.25f;
                // Middle
                GameObject actualProjectile = Instantiate(SkillPrefab, transform.position, transform.rotation);
                Skill skillScript = actualProjectile.GetComponent<Skill>();
                skillScript.direction = this.direction;

                // Top
                var upPosition = transform.position;
                upPosition.y += spread;
                actualProjectile = Instantiate(SkillPrefab, upPosition, transform.rotation);
                skillScript = actualProjectile.GetComponent<Skill>();
                skillScript.direction = this.direction;

                // Bottom
                var bottomPosition = transform.position;
                bottomPosition.y -= spread;
                actualProjectile = Instantiate(SkillPrefab, bottomPosition, transform.rotation);
                skillScript = actualProjectile.GetComponent<Skill>();
                skillScript.direction = this.direction;
            }
            else
            {
                GameObject actualProjectile = Instantiate(SkillPrefab, transform.position, transform.rotation);
                Skill skillScript = actualProjectile.GetComponent<Skill>();
                skillScript.direction = this.direction;
            }
            canShoot = false;
            StartCoroutine(ActivateAgain());
        }
    }

    public IEnumerator ActivateAgain()
    {
        yield return new WaitForSeconds(activeTime);
        canShoot = true;
    }


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0f;
        _healthManager = GetComponent<HealthManager>();
        _buttons = GameObject.Find("Engine").GetComponent<Buttons>();
        // TODO: animator = GetComponent<Animator>();
    }


    private void Update()
    {
        Move();
        CheckForShooting();
    }

    private void CheckForShooting()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("x"))
        {
            Shoot();
        }
    }

    public void Move()
    {
        var verticalSpeed = _buttons.VerticalAxis;
        var horizontalSpeed = _buttons.HorizontalAxis;

        if (verticalSpeed > 0 || verticalSpeed < 0)
        {
            // TODO: animator.SetBool("Walking", true);
        }
        if (verticalSpeed == 0)
        {
            // TODO: animator.SetBool("Walking", false);
        }

        if (horizontalSpeed > 0)
        {
            // TODO: animator.SetBool("Walking", true);
            FlipRight();
        }
        if (horizontalSpeed < 0)
        {
            // TODO: animator.SetBool("Walking", true);
            FlipLeft();
        }
        if (horizontalSpeed == 0)
        {
            // TODO: animator.SetBool("Walking", false);
        }
        rigidbody.velocity = new Vector2(horizontalSpeed * Speed, verticalSpeed * Speed);
    }

    private void FlipLeft()
    {
        direction = Direction.Left;
        GetComponent<SpriteRenderer>().flipX = false;
    }

    private void FlipRight()
    {
        direction = Direction.Right;
        GetComponent<SpriteRenderer>().flipX = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Mama")
        {
            // TODO: Animation/sound
            Destroy(gameObject);
            GameObject.Find("Main Camera").GetComponent<LevelManager>().GameLose();
        }
    }

    public void DecreaseHP()
    {
        _healthManager.DealDamage(HealthObjectType.Health, 1);
    }

    public void IncreaseHP(int count)
    {
        _healthManager.AddHealth(HealthObjectType.Health, 1);
    }

    public void GiveShotgun()
    {
        shotgun = true;
    }

    public void GiveSkill(GameObject newSkill)
    {
        SkillPrefab = newSkill;
        var powerImage = GameObject.Find("Power1Button").GetComponent<Image>();
        powerImage.sprite = newSkill.GetComponent<Skill>().UISprite;
        var tempColor = powerImage.color;
        tempColor.a = 1;
        powerImage.color = tempColor;

    }
}

