using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
[CreateAssetMenu(fileName = "Skill", menuName = "Skills/Skill")]
public class Skill : MonoBehaviour, IDamageDealer, IMovable
{
    public Sprite UISprite;
    public Sprite ShootingSprite;
    public Direction direction;
    [SerializeField]
    private double _damage;
    public double Damage { get { return _damage; } private set { _damage = value; }}
    [SerializeField]
    private float _speed;
    public float Speed { get { return _speed; } private set { _speed = value; } }
    public float projectileTime;


    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = ShootingSprite;
        PlaySound();
        BeginDestruction();
    }

    void BeginDestruction()
    {
        StartCoroutine(DestructionCountdown(projectileTime));
    }

    IEnumerator DestructionCountdown(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        float xSpeed = 0;
        float ySpeed = 0;

        if (direction == Direction.Right || direction == Direction.Left)
        {
            xSpeed = direction == Direction.Left ? -Speed : Speed;
            ySpeed = 0;
        }
        else
        {
            xSpeed = 0;
            ySpeed = direction == Direction.Bottom ? -Speed : Speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}

