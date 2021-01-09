using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button play;
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMaze()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        SceneManager.LoadScene("maze");
    }
    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    
}
