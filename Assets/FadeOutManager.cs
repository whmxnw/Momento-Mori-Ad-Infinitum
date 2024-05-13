using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutManager : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    private bool image1Faded = false;
    private bool image2Faded = false;
    private bool image3Faded = false;
    private bool image4Faded = false;
    private bool image5Faded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !image1Faded)
        {
            var tempColor = image1.color;
            tempColor.a = 0f;
            image1.color = tempColor;
            image1Faded = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !image2Faded)
        {
            var tempColor = image2.color;
            tempColor.a = 0f;
            image2.color = tempColor;
            image2Faded = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !image3Faded)
        {
            var tempColor = image3.color;
            tempColor.a = 0f;
            image3.color = tempColor;
            image3Faded = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !image4Faded)
        {
            var tempColor = image4.color;
            tempColor.a = 0f;
            image4.color = tempColor;
            image4Faded = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && image4Faded)
        {
            SceneManager.LoadScene("Assets/CF_Assets/CF_DungeonScripts/CF_DungeonRooms/CF_Stage1Main.Unity");
            SceneManager.GetSceneByPath("Assets / CF_Assets / CF_DungeonScripts / CF_DungeonRooms / CF_Stage1Main.Unity");
        }

    }
}
