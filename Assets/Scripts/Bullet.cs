using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]


public class Bullet : MonoBehaviour
{
    [Header("Bullets parametrs")]
    [SerializeField] private Rigidbody2D Rigidbodybullet;
    [SerializeField] private float velocity = 20f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private int damage = 1;

    [Header("Bullets Effect")]
    [SerializeField] private GameObject explosionPrefab;

    private Transform bullet;

    private void Start()
    {
        bullet = transform;
        Rigidbodybullet = GetComponent<Rigidbody2D>();
        Invoke("DestroySelf", lifeTime);
    }

    private void FixedUpdate()
    {
        Rigidbodybullet.MovePosition(new Vector2(bullet.position.x, bullet.position.y + velocity * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent<IDamageable>(out IDamageable enemy))
            enemy.TakingDamage(damage);

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        DestroySelf();
    }

    private void DestroySelf() 
    {
        Destroy(gameObject);
    }
}
