using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Text title;

    public List<GameObject> gameObjects;

    public void Start()
    {
        PlayerPrefs.SetString("SpawnPoint", "Default");
    }

    // Used to Load the main menu first.
    public void MainMenuGame()
    {
        SceneManager.LoadScene("");
    }
    
    // Used to load the main game scene. Attached to a UI button in the main menu.
    public void PlayGame()
    {
        SceneManager.LoadScene("BarnyardBlitz");
    }

    // Used to load the main menu. Attached to in-game menu button.
    public void doMainMenu()
    {
        SceneManager.LoadScene("MainMenuBB");
    }

    // When called, will close the application. Attached to any "Quit" buttons.
    public void ExitGame()
    {

        Debug.Log("quit");
        Application.Quit();
    }

    public void instructions() {

        foreach (GameObject obj in gameObjects) { 
        
            obj.SetActive(!obj.activeSelf);
        
        }
    
    }

    
}
