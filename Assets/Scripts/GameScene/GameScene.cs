using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public GameObject canvas;

    public Image result;
    public Texture2D source;
    public Texture2D[] pieces;

    private GameObject[] puzzleCellImages; // puzzleCell - should be a different class!

    PuzzleCellSettings puzzleCellSettings;

    Vector2 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        PrepareCalculation();
        PrepareLevel();
    }

    void PrepareCalculation()
    {
        int height = Screen.height / GameFieldSettings.height;
        int width = Screen.width / GameFieldSettings.width;

        puzzleCellSettings = new PuzzleCellSettings(width, height);

        puzzleCellImages = new GameObject[GameFieldSettings.width * GameFieldSettings.height];

        startPoint = new Vector2((-Screen.width / 2 + puzzleCellSettings.width / 2), (Screen.height / 2 - puzzleCellSettings.height / 2));
    }

    void PrepareLevel()
    {
        int cellCounter = 0;
        for (int i = 0; i < GameFieldSettings.width; i++)
            for (int j = 0; j < GameFieldSettings.height; j++)
            {
                GameObject newObject = new GameObject("PuzzleCell"+cellCounter);
                newObject.transform.SetParent(canvas.transform);
                newObject.AddComponent<RectTransform>();
                newObject.GetComponent<RectTransform>().sizeDelta = new Vector3(puzzleCellSettings.width, puzzleCellSettings.height, 0);
                newObject.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                newObject.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                newObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                newObject.GetComponent<RectTransform>().transform.localPosition = new Vector3(puzzleCellSettings.height*i, puzzleCellSettings.height * j, 0);

                newObject.AddComponent<Image>();

                puzzleCellImages[cellCounter] = newObject;

                newObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                cellCounter++;
            }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void BuildPieces()
    //{
    //    for (int i = 0; i < 3; i++)
    //    {
    //        for (int j = 0; j < 3; j++)
    //        {
    //            int index = i * 3 + j;
    //            pieces[index] = new Texture2D(104, 104);
    //            var pixels = source.GetPixels(104 * i, 104 * j, 104, 104);
    //            pieces[index].SetPixels(pixels);
    //            pieces[index].Apply();
    //        }
    //    }
    //}

    void FA1()
    {
        Rect rec = new Rect(0, 0, pieces[4].width, pieces[4].height);
        Vector2 pivot = new Vector2(0.5f, 0.5f);

        //result.sprite = Sprite.Create(pieces[4], rec, pivot);

        Sprite newSprite = Sprite.Create(source, new Rect(200, 200, 200, 200), new Vector2(0.5f, 0.5f));
        result.sprite = newSprite;
    }
}

static public class GameFieldSettings
{
    public const int height = 3;
    public const int width = 3;
}

public class PuzzleCellSettings
{
    public PuzzleCellSettings(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public int width { get; private set; }
    public int height { get; private set; }
}
