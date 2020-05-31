using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public GameObject canvas;

    public Texture2D source;

    Level active_level;

    void Start()
    {
        active_level = new Level(canvas, source);
    }
}

static public class GameFieldSettings
{
    public const int height = 3;
    public const int width = 3;
}
