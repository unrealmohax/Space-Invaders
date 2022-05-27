using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    internal static SpawnerEnemy Instance;

    [Header("Spawning")]
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform royEnemies;
    [Range(3, 9)]
    [SerializeField] private int column;
    [Range(3, 5)]
    [SerializeField] private int row;

    private EnemyShooting[,] invaders;

    [SerializeField] private Transform startPos;
    private Vector2 spawnPos;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    private int enemyLive = 0;

    [SerializeField] private Transform Roy;

    private void Start()
    {
        int virtcolumn = column;
        invaders = new EnemyShooting[column, row];
        if (column % 2 != 0)
        {
            virtcolumn -= 1;
        }

        spawnPos = new Vector2(startPos.position.x - offsetX * virtcolumn / 2, startPos.position.y);
        EnemyMoving.Instance.offset = offsetX * virtcolumn / 2 + 0.5f;

        Spawn();
    }

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
    }


    private void Update()
    {
        UpdateEnemies();
    }

    private void Spawn()
    {
        for (int i = 0; i < column; i++)
            for (int j = 0; j < row; j++)
            {
                int index = Mathf.Clamp(j, 0, enemyPrefab.Length - 1);
                GameObject enemy = Instantiate(enemyPrefab[index], new Vector3(spawnPos.x + offsetX * i, spawnPos.y - offsetY * j, 0), Quaternion.identity, royEnemies);
                invaders[i, j] = enemy.GetComponent<EnemyShooting>();
            }

        for (int i = 0; i < column; i++)
            invaders[i, row-1].canShooting = true;
    }

    private void UpdateEnemies() 
    {
        for (int i = 0; i < column; i++)
            for (int j = 0; j < row; j++)
            {
                if (invaders[i, j] == null)
                {
                    int index = Mathf.Clamp(j - 1, 0, row - 1);
                    invaders[i, index].canShooting = true;
                }
                else 
                {
                    enemyLive++;
                }
                
            }

        if (enemyLive == 0) 
        {
            Roy.position = new Vector3(0, 0, 0);
            Spawn();
        }
            
        enemyLive = 0;
    }
}