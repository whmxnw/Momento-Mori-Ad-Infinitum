using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneScript : MonoBehaviour
{

    public Scene scene;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            LoadLevel("Assets/CF_Assets/CF_DungeonScripts/CF_DungeonRooms/CF_Stage1Main.unity");
            scene = SceneManager.GetSceneByPath("Assets/CF_Assets/CF_DungeonScripts/CF_DungeonRooms/CF_Stage1Main.unity");
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
