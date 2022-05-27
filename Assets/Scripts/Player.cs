using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour, IDamageable
{
    [Header("Player Parameters")]
    [Range (1,3)]
    [SerializeField] private int hp = 2;

    public void TakingDamage(int Damage)
    {
        hp -= Damage;

        if (IsLive(hp))
        {
            return;
        }

        GameManager.Instance.UpdateLives();
        DestroySelf();
    }

    private bool IsLive(int hp)
    {
        return hp > 0;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
