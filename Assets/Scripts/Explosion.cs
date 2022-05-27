using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private AudioClip explosion;

    [Header("Bullets parametrs")]
    [SerializeField] private float lifeTime = 1f;

    private void Start()
    {
        GameManager.Instance.PlaySfx(explosion);
        Invoke("DestroySelf", lifeTime);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
