using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenuWithLevels : MonoBehaviour
{
    public void GoMenuWithDelay(float delay)
        => StartCoroutine(OpenMenu(delay));

    private IEnumerator OpenMenu(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(0);
    }
}
