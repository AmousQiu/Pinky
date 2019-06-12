using UnityEngine;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    public GameObject gameScene, startScene,gameOverScene,winScene;
    private DataController dataController;
    private GameData gameData;
    private StartSceneData startSceneData;
    private string startSceneHeadingString, buttonTextString;


    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        startScene.SetActive(true);
        gameScene.SetActive(false);
        gameOverScene.SetActive(false);
        winScene.SetActive(false);
    }


    public void TapToContinueClick()
    {
        startScene.SetActive(false);
        gameScene.SetActive(true);
        gameOverScene.SetActive(false);
    }
}

