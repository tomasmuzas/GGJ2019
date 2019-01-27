using System;
using System.Collections;
using Assets.Scripts._2018.UI;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class PowerUp : MonoBehaviour, IDamageDealer
{
    public bool Enabled = false;
    public double Radius;
    public int durationInSeconds;
    public int tickSpeed;

    public HealthObjectType type;

    public Coroutine coroutine;


    [SerializeField]
    private double _damage;

    public double Damage { get { return _damage; } private set { _damage = value; } }

    // Activate main effect after the player touches the powerup
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !Enabled)
        {
            Enabled = true;
            Activate();
        }
    }
    
    // Deal damage to pedestrians after
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Enabled)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            //Damamge
            coroutine = StartCoroutine(ExecuteAfter(tickSpeed, () => player._healthManager.AddHealth(type, 1)));
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        StopCoroutine(coroutine);
    }

    void IncreaseColliderRadius()
    {
        CircleCollider2D circle = gameObject.GetComponent<CircleCollider2D>();
        circle.radius = (float)Radius;
    }

    // Call all the main effects
    void Activate()
    {
        PlaySound();
        IncreaseColliderRadius();
        StartDisapperCountdown();
    }

    void StartDisapperCountdown()
    {
        StartCoroutine(DisappearAfter(durationInSeconds));
    }

    void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }


    IEnumerator DisappearAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }

    IEnumerator ExecuteAfter(float second, Action action)
    {
        yield return new WaitForSeconds(1f);
        action();
    }
}
