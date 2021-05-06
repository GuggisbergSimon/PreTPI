using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    [SerializeField] private float timeScale = 0.5f;
    [SerializeField] private float timeToTimeScale = 2f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameManager.Instance.ChangeTimeScale(timeScale, timeToTimeScale);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            GameManager.Instance.ChangeTimeScale(1f, timeToTimeScale / 10f);
        }
    }
}