using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [SerializeField] private Button _quit;

    private void OnEnable() => _quit.onClick.AddListener(Exit);

    private void OnDisable() => _quit.onClick.RemoveListener(Exit);

    private void Exit() => Application.Quit();
}
