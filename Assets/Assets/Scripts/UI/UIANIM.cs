using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIANIM : MonoBehaviour
{
    public Image titleImage;
    public RectTransform blur;
    public Shader blurShader;
    // Start is called before the first frame update
    void Start()
    {
        blurShader = Shader.Find("BLUR");
        DoTitle();
    }

    // Update is called once per frame
    void DoTitle()
    {
        Vector3 blurvalor = new Vector3(0, 0, 0);
        blur.DOScale(blurvalor, 2).SetEase(Ease.OutQuint);
        titleImage.DOFade(1f, 7).SetEase(Ease.OutQuint);

    }

}
