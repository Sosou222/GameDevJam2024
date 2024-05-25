using Godot;
using System;

using Godot.Collections;
using Constants;

public partial class AnimationsManager : Node
{
    private string animationSpritesPath = "res://Resources/AnimatedSprites/";
    private string animationLibrariesPath = "res://Resources/Animations/";

    private Dictionary<string, SpriteFrames> animationSprites = new();
    private Dictionary<string, AnimationLibrary> animationLibraries = new();

    private static AnimationsManager instance;

    public override void _Ready()
    {
        if (instance != null)
        {
            QueueFree();
            return;
        }
        instance = this;
        LoadAnimationSprites();
        LoadAniamtionLibraries();
    }

    public static SpriteFrames GetSpritesFrames(string name)
    {
        return instance.animationSprites[name];
    }

    public static AnimationLibrary GetAnimationLibrary(string name)
    {
        return instance.animationLibraries[name];
    }

    private void LoadAnimationSprites()
    {
        foreach (string enemyType in EnemyType.All)
        {
            SpriteFrames spriteFrames = GD.Load<SpriteFrames>($"{animationSpritesPath}{enemyType}SpriteFrames.tres");
            if (spriteFrames == null)
            {
                GD.Print($"Failed loading sprite frames for:{enemyType}");
                continue;
            }

            animationSprites.Add(enemyType, spriteFrames);
        }
    }

    private void LoadAniamtionLibraries()
    {
        foreach (string enemyType in EnemyType.All)
        {
            AnimationLibrary spriteFrames = GD.Load<AnimationLibrary>($"{animationLibrariesPath}{enemyType}AnimationLibrary.res");
            if (spriteFrames == null)
            {
                GD.Print($"Failed loading animation library for:{enemyType}");
                continue;
            }

            animationLibraries.Add(enemyType, spriteFrames);
        }
    }

}
