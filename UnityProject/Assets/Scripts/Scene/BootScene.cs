using System.Collections;
using UnityEngine;

public class BootScene : MonoBehaviour
{
    [SerializeField]
    private FadeScreen m_fadeScreen;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(3);

        m_fadeScreen.FadeIn(2);

        yield return new WaitWhile(() => m_fadeScreen.IsFading);

        Debug.Log("Boot");

        yield break;
    }
}