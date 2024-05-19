using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject optionsPanel;
    public GameObject mainMenu;
    public GameObject exitButton;

    private void Start()
    {
        // Desativa o painel no início da cena
        creditsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void OpenCreditsPanel()
    {
        creditsPanel.SetActive(true);
        optionsPanel.SetActive(false);
        mainMenu.SetActive(false);
        exitButton.SetActive(false);
    }

    public void OpenOptionsPanel()
    {
        creditsPanel.SetActive(false);
        optionsPanel.SetActive(true);
        mainMenu.SetActive(false);
        exitButton.SetActive(false);
    }

    public void ClosePanel()
    {
        creditsPanel.SetActive(false);
        optionsPanel.SetActive(false);
        mainMenu.SetActive(true);
        exitButton.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("ACena");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Aplicação encerrada.");
    }

}
