using UnityEngine;
using UnityEngine.SceneManagement;
public class scenechanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void scenechange(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
