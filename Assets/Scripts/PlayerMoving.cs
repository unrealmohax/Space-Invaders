using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float Velocity = 5f;

    private Rigidbody2D rigidbodyplayer;
    private Transform player;

    [SerializeField] private SimpleTouchController leftController;

    private void Start()
    {
        leftController = FindObjectOfType<SimpleTouchController>();
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
        if (leftController.GetTouchPosition.x != 0 || leftController.GetTouchPosition.y != 0)
        {
            Vector2 swipeDelta = leftController.GetTouchPosition;
            Move(swipeDelta);
        }
        #endregion
    }

    private void Move(Vector2 swipeDelta)
    {
        rigidbodyplayer.MovePosition(new Vector2(player.position.x + Velocity * swipeDelta.x * Time.deltaTime, player.position.y + Velocity * swipeDelta.y * Time.deltaTime));
    }
}
