using UnityEngine;

public class MobileUI : MonoBehaviour
{
    [SerializeField] private GameObject[] mobileUI;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            foreach (GameObject ui in mobileUI)
                ui.SetActive(false);
        }
    }
}
