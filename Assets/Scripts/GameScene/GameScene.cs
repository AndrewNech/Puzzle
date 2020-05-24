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
    }

    void PrepareLevel()
    {
        int cellCounter = 0;
        for (int i = 0; i < GameFieldSettings.width; i++)
            for (int j = 0; j < GameFieldSettings.height; j++)
            {
                GameObject newObject = new GameObject("ObjectName"+cellCounter);
                newObject.AddComponent<RectTransform>();
                newObject.GetComponent<RectTransform>().sizeDelta = new Vector2(puzzleCellSettings.width, puzzleCellSettings.height);
                newObject.AddComponent<Image>();

                puzzleCellImages[cellCounter] = newObject;
                puzzleCellImages[cellCounter].transform.position = new Vector3(50 * i, 50*j, 0);

                puzzleCellImages[cellCounter].transform.SetParent(canvas.transform);

                //canvas.AddComponent<Image>(puzzleCellImages[cellCounter]);

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
    public const int height = 5;
    public const int width = 5;
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
