using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float Velocity = 5f;

    private Rigidbody2D rigidbodyplayer;
    private Transform player;

    private void Start()
    {
        rigidbodyplayer = GetComponent<Rigidbody2D>();
        player = transform;
    }

    private void FixedUpdate()
    {
        #region ПК-версия
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
        #endregion

        #region Мобильная версия
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Vector2 swipeDelta = Input.touches[0].position;
                Move(swipeDelta);
            }
        }
        #endregion
    }

    private void Move(Vector2 swipeDelta)
    {
        rigidbodyplayer.MovePosition(new Vector2(player.position.x + Velocity * swipeDelta.x * Time.deltaTime, player.position.y + Velocity * swipeDelta.y * Time.deltaTime));
    }
}
