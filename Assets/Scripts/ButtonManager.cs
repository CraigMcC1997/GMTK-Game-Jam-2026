using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Scenes/Prototype Level");
    }
}
