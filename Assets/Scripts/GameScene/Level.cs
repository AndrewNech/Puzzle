using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
	GameObject canvas;
	
	Texture2D source;

    private GameObject[] puzzleCellImages; // puzzleCell - should be a different class!

    PuzzleCellSettings puzzleCellSettings;

    int imageWidth;
    int imageHeight;

    public Level(GameObject canvas, Texture2D source)
	{
        this.canvas = canvas;
        this.source = source;

        PrepareCalculation();
        PrepareLevel();
    }

	public void CreateLevel()
	{

	}

    void PrepareCalculation()
    {
        int height = Screen.height / GameFieldSettings.height;
        int width = Screen.width / GameFieldSettings.width;

        puzzleCellSettings = new PuzzleCellSettings(width, height);

        puzzleCellImages = new GameObject[GameFieldSettings.width * GameFieldSettings.height];

        imageWidth = source.width / GameFieldSettings.width;
        imageHeight = source.height / GameFieldSettings.height;
    }

    void PrepareLevel()
    {
        int cellCounter = 0;
        for (int i = 0; i < GameFieldSettings.width; i++)
            for (int j = 0; j < GameFieldSettings.height; j++)
            {
                GameObject newObject = new GameObject("PuzzleCell" + cellCounter);
                newObject.transform.SetParent(canvas.transform);
                newObject.AddComponent<RectTransform>();
                newObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                newObject.GetComponent<RectTransform>().sizeDelta = new Vector3(puzzleCellSettings.width, puzzleCellSettings.height, 0);
                newObject.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
                newObject.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);

                newObject.GetComponent<RectTransform>().transform.localPosition += new Vector3(puzzleCellSettings.width / 2 + puzzleCellSettings.width * i, -(puzzleCellSettings.height / 2 + puzzleCellSettings.height * j), 0);

                newObject.AddComponent<Image>();

                Sprite newSprite = Sprite.Create(source, new Rect(imageWidth * i, source.height - (imageHeight * (j + 1)), imageWidth, imageHeight), new Vector2(0.5f, 0.5f));
                newObject.GetComponent<Image>().sprite = newSprite;

                puzzleCellImages[cellCounter] = newObject;

                cellCounter++;
            }
    }
}
