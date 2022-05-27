using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    public static UnityEvent<int> Victory = new UnityEvent<int>();
    public static UnityEvent<int> Defeat = new UnityEvent<int>();
}
