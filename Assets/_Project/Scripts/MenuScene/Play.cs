using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    [SerializeField] private Button _play;

    private void OnEnable()
    {
        _play.onClick.AddListener(OpenLevelMenu);
    }

    private void OnDisable()
    {
        _play.onClick.RemoveListener(OpenLevelMenu);
    }

    private void OpenLevelMenu()
    {
        SceneManager.LoadScene(0);
    }
}

