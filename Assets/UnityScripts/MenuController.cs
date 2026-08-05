using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnExitClick()
    {
#if Unity_Editor
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
