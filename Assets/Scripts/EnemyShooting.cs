using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private AudioClip shooting;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float coolDown;
    [SerializeField] private float minTime = 1;
    [SerializeField] private float maxTime = 3;

    public bool canShooting = false;

    private float currTime;

    private void Start()
    {
        coolDown = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        if (canShooting) 
        {
            if (currTime > coolDown)
            {
                Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
                GameManager.Instance.PlaySfx(shooting);
                currTime = 0f;
            }
        }
        currTime += Time.deltaTime;
    }
}