using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Enemy : MonoBehaviour, IDamageable
{
    [Range(1, 5)]
    [SerializeField] private int hp;
    [SerializeField] private int points;
    public void TakingDamage(int Damage)
    {
        hp -= Damage;

        if (IsLive(hp)) 
        {
            return;
        }

        DestroySelf();
    }

    private bool IsLive(int hp) 
    {
        return hp > 0;
    }

    private void DestroySelf()
    {
        GameManager.Instance.UpdateScore(points);
        Destroy(gameObject);
    }
}