#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class SceneLoader : MonoBehaviour
{
    private static void Open(string sceneName)
    {
        bool continueLoad = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        if (continueLoad)
        {
            EditorSceneManager.OpenScene($"Assets/_Scenes/{sceneName}.unity");
        }
    }

    private static void OpenAdditive(string sceneName)
    {
        bool continueLoad = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        if (continueLoad)
        {
            EditorSceneManager.OpenScene($"Assets/_Scenes/{sceneName}.unity", OpenSceneMode.Additive);
        }
    }

    [MenuItem("[SCENELOAD]/LevelLoader", false, 0)]
    private static void GoToLevelLoader()
    {
        Open("LevelLoader");
    }

    [MenuItem("[SCENELOAD]/MainMenu", false, 1)]
    private static void GoToMainMenu()
    {
        Open("MainMenu");
    }

    [MenuItem("[SCENELOAD]/PinballTable", false, 2)]
    private static void GoToPinballTable()
    {
        Open("PinballTable");
    }

    [MenuItem("[SCENELOAD]/AutoBattler", false, 3)]
    private static void GoToAutoBattler()
    {
        Open("AutoBattler");
    }

    [MenuItem("[SCENELOAD]/Environment", false, 4)]
    private static void GoToEnvironment()
    {
        Open("Environment");
    }

    [MenuItem("[SCENELOAD]/AutoBattler + Environment", false, 5)]
    private static void GoToAutoEnv()
    {
        Open("Autobattler");
        OpenAdditive("Environment");
    }

    [MenuItem("[SCENELOAD]/*Game Scenes*", false, 6)]
    private static void GoToGameScenes()
    {
        Open("AutoBattler");
        OpenAdditive("Environment");
        OpenAdditive("PinballTable");
        OpenAdditive("Environment");
    }

}
