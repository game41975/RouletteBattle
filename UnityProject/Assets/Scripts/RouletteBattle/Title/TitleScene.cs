using UnityEngine;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private RawImage m_imageTitle;

    [SerializeField]
    private RawImage m_imagePressKey;

    public void Start()
    {
        
    }

    public void Update()
    {
        float alpha = 1f * Mathf.Abs(Mathf.Sin(Time.time));

        Color color = m_imagePressKey.color;
        color.a = alpha;
        m_imagePressKey.color = color;
    }
}
