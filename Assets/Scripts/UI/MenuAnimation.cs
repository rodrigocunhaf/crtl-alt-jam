using UnityEngine;
using System.Collections;
using DentedPixel;

public class MenuAnimation : MonoBehaviour
{
    public GameObject BTN_jogar;
    public GameObject BTN_ajustes;
    public GameObject BTN_creditos;
    public GameObject BTN_sair;

    void Start()
    {
        // Pega as posições iniciais (pontos X)
        Vector3 startPosJogar = BTN_jogar.transform.position;
        Vector3 startPosAjustes = BTN_ajustes.transform.position;
        Vector3 startPosCreditos = BTN_creditos.transform.position;
        Vector3 startPosSair = BTN_sair.transform.position;

        // Define as posições finais (pontos Y)
        Vector3 finalPosJogar = new Vector3(xFinalJogar, yFinalJogar, zFinalJogar);
        Vector3 finalPosAjustes = new Vector3(xFinalAjustes, yFinalAjustes, zFinalAjustes);
        Vector3 finalPosCreditos = new Vector3(xFinalCreditos, yFinalCreditos, zFinalCreditos);
        Vector3 finalPosSair = new Vector3(xFinalSair, yFinalSair, zFinalSair);

        // Move os botões para suas posições finais
        LeanTween.moveLocal(BTN_jogar, finalPosJogar, 1.0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(BTN_ajustes, finalPosAjustes, 1.0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(BTN_creditos, finalPosCreditos, 1.0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(BTN_sair, finalPosSair, 1.5f).setEase(LeanTweenType.linear);
    }

    // BTN_jogar
    float xFinalJogar = 24f;
    float yFinalJogar = 23f;
    float zFinalJogar = -1f;

    // BTN_ajustes
    float xFinalAjustes = -28f;
    float yFinalAjustes = -386f;
    float zFinalAjustes = -1f;

    // BTN_creditos
    float xFinalCreditos = 24f;
    float yFinalCreditos = -4f;
    float zFinalCreditos = -3f;

    // BTN_sair
    float xFinalSair = -2f;
    float yFinalSair = -490f;
    float zFinalSair = 0f;
}
