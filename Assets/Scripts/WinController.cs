using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public GameObject winScene, startScene;
    private GameData gameData;
    private WinSceneData winSceneData;
    private DataController dataController;

    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        gameData = dataController.GetGameData();
        winSceneData = gameData.winSceneData;
    }

    public void TapToContinueClick()
    {
        winScene.SetActive(false);
        startScene.SetActive(true);
    }
}


