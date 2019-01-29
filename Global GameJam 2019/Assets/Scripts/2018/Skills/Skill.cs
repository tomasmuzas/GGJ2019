using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
[CreateAssetMenu(fileName = "Skill", menuName = "Skills/Skill")]
public class Skill : MonoBehaviour, IDamageDealer, IMovable
{
    public Sprite UISprite;
    public Sprite ShootingSprite;
    public Vector2 direction;
    [SerializeField]
    private double _damage;
    public double Damage { get { return _damage; } private set { _damage = value; } }
    [SerializeField]
    private float _speed;
    public float Speed { get { return _speed; } private set { _speed = value; } }
    public float projectileTime;


    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = ShootingSprite;
        PlaySound();

        Debug.Log("x" + direction.x);
        Debug.Log("y" + direction.y);
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

        if (direction.x > 0)
        {
            xSpeed = direction.x + Speed;
        }
        if (direction.x < 0)
        {
            xSpeed = direction.x - Speed;
        }
        if (direction.y > 0)
        {
            ySpeed = direction.y + Speed;
        }
        if (direction.y < 0)
        {
            ySpeed = direction.y - Speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}

