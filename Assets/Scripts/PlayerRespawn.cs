using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private float respawnTime = 20f;

    private void Start()
    {
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        player.enabled = false;
        ChangeSpriteAlpha(0.25f);
        yield return new WaitForSeconds(respawnTime);

        ChangeSpriteAlpha(1.0f);
        player.enabled = true;
    }

    private void ChangeSpriteAlpha(float value)
    {
        Color color = playerSprite.color;
        color.a = value;
        playerSprite.color = color;
    }
}
