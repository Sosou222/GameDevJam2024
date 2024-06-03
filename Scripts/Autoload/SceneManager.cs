using Godot;
using System;

public partial class SceneManager : Node
{
    public static SceneManager instance { private set; get; }

    private string SceneFolder = "Nodes/Scenes";

    public override void _Ready()
    {
        if (instance != null)
        {
            QueueFree();
            return;
        }
        instance = this;
    }

    public static void LoadScene(string sceneName)
    {
        string sceneToLoad = $"res://{instance.SceneFolder}/{sceneName}.tscn";
        Error er = instance.GetTree().ChangeSceneToFile(sceneToLoad);
        if (er != Error.Ok)
        {
            GD.Print($"Error:{er}");
        }

    }

    public static void ReloadScene()
    {
        instance.GetTree().ReloadCurrentScene();
    }

    public static void QuitGame()
    {
        instance.GetTree().Quit();
    }
}
