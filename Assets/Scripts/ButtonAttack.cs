using UnityEngine;

public class ButtonAttack : MonoBehaviour
{
    private PlayerShooting _playerShooting;
    public static ButtonAttack Instance;
    private bool shoot = false;

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

    public void NewPlayer(PlayerShooting playerShooting) 
    {
        _playerShooting = playerShooting;
    }

    public void PointerDown()
    {
        shoot = true;
    }

    public void PointerUp()
    {
        shoot = false;
    }

    private void Update()
    {
        if (shoot) 
        {
            _playerShooting.Shoot();
        }
    }
}
