using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootScene : MonoBehaviour
{
    [SerializeField]
    private FadeScreen m_fadeScreen;

    public IEnumerator Start()
    {
        SceneManager.LoadScene("Title");

        yield break;
    }
}