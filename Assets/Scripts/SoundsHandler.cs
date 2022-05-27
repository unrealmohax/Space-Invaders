using UnityEngine;

public class SoundsHandler : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    internal void StopPlaying() => source.Stop();

}
