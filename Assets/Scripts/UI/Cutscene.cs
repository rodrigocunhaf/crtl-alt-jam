using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public GameObject cutscene01;
    public GameObject cutscene02;
    public GameObject cutscene03;
    public GameObject cutscene04;
    public GameObject cutscene05;

    public GameObject robot;

    public string sceneToLoad = "01 Level";

    float xFinalRobot = 2f;
    float yFinalRobot = 332f;
    float zFinalRobot = -1f;

    public void Cutscene02()
    {
        cutscene02.SetActive(true);
        cutscene01.SetActive(false);
        cutscene03.SetActive(false);
        cutscene04.SetActive(false);
        cutscene05.SetActive(false);

    }

    public void Cutscene03()
    {
        cutscene02.SetActive(false);
        cutscene01.SetActive(false);
        cutscene03.SetActive(true);
        cutscene04.SetActive(false);
        cutscene05.SetActive(false);

    }

    public void Cutscene04()
    {
        cutscene02.SetActive(false);
        cutscene01.SetActive(false);
        cutscene03.SetActive(false);
        cutscene04.SetActive(true);
        cutscene05.SetActive(false);

        // Pega as posições iniciais (pontos X)
        Vector3 startPosRobot = robot.transform.position;

        Vector3 finalPosRobot = new Vector3(xFinalRobot, yFinalRobot, zFinalRobot);

        LeanTween.moveLocal(robot, finalPosRobot, 1.0f).setEase(LeanTweenType.linear);

    }

    public void Cutscene05()
    {
        cutscene02.SetActive(false);
        cutscene01.SetActive(false);
        cutscene03.SetActive(false);
        cutscene04.SetActive(false);
        cutscene05.SetActive(true);

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
