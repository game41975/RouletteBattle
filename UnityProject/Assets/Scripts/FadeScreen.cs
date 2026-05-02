using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    [SerializeField]
    private RawImage m_rawImage;

    private bool m_isFading = false;
    /// <summary>フェード処理中か</summary>
    public bool IsFading => m_isFading;

    /// <summary>フェード画面の初期カラー</summary>
    private readonly Color InitFadeColor = new Color(1, 1, 1, 0);

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        m_rawImage.color = InitFadeColor;
    }

    public void FadeIn(float fadeTimeSecond = 1.0f)
    {
        StartCoroutine(FadeAsync(true, fadeTimeSecond));
    }

    public void FadeOut(float fadeTimeSecond = 1.0f)
    {
        StartCoroutine(FadeAsync(false, fadeTimeSecond));
    }

    public void SetColor(Color color)
    {
        if(m_rawImage != null)
        {
            m_rawImage.color = color;
        }
    }

    private IEnumerator FadeAsync(bool isFadeIn, float time)
    {
        if(m_rawImage == null)
        {
            yield break;
        }

        m_isFading = true;

        Color initColor = m_rawImage.color;
        Color setColor = initColor;
        float initAlpha = isFadeIn ? 0f : 1f;
        float targetAlpha = isFadeIn ? 1f : 0f;

        if(time > 0f)
        {
            initColor.a = initAlpha;
            m_rawImage.color = initColor;

            float timer = 0f;
            while (true)
            {
                if (timer >= time)
                {
                    break;
                }

                timer += Time.deltaTime;

                setColor.a =  Mathf.Lerp(initAlpha, targetAlpha, timer / time);
                m_rawImage.color = setColor;
                yield return null;
            }
        }
        else
        {
            //フェード時間無しの場合は、即フェード後の表示に切り替える
            setColor.a = targetAlpha;
            m_rawImage.color = setColor;
        }

        m_isFading = false;

        yield break;
    }
}
