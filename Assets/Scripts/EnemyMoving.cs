using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]


public class EnemyMoving : MonoBehaviour
{
    public static EnemyMoving Instance;

    [Header("Player Speed")]
    [SerializeField] private float Velocity = 5f;

    [SerializeField] private Transform rightLimitPos;
    [SerializeField] private Transform leftLimitPos;
    [SerializeField] private Transform DefeatPos;

    private float rightLimit;
    private float leftLimit;
    public float offset;
    public bool isGoingLeft = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        rightLimit = rightLimitPos.position.x;
        leftLimit = leftLimitPos.position.x;
    }

    private void Update()
    {
        if (transform.position.x <= leftLimit + offset)
        {
            isGoingLeft = false;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        }
        else if (transform.position.x >= rightLimit - offset)
        {
            isGoingLeft = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        }

        Move();

        if (transform.position.y <= DefeatPos.position.y) 
        {
            GameManager.Instance.TriggerGameOver();
        }
    }

    private void Move()
    {
        Vector3 direction = isGoingLeft ? Vector3.left : Vector3.right;

        transform.Translate(direction * Velocity * Time.deltaTime);
    }
}
