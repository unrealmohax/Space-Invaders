using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private AudioClip shooting;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float coolDown;
    private float currTime;

    private void Update()
    {
        currTime += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space)) 
        {
            if (currTime > coolDown)
            {
                Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
                GameManager.Instance.PlaySfx(shooting);
                currTime = 0f;
            }
        }
    }
}