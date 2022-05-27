using UnityEngine;

public class UIHearth : MonoBehaviour
{
    internal static UIHearth Instance;

    [SerializeField] private GameObject[] Hearts;


    public void HeartDisplay(int Count) 
    {
        for (int i = 0; i < Hearts.Length - Count; i++)
        {
            if (Hearts[i] != null) 
            {
                Hearts[i].SetActive(false);
            }
        }     
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
}
