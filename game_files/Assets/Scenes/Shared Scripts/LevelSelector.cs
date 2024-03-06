using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update

    public Button LvlSelectBtnPrefab;
    public GameObject LevelPanel;

    private int level = 1;
    void Start () { 

        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;     
        string[] scenes = new string[sceneCount];

        for( int i = 0; i < sceneCount; i++ ) {
            string sceneToAdd = System.IO.Path.GetFileNameWithoutExtension( UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( i ) );
            string checkString = sceneToAdd.Substring(0,5);
            if ( checkString == "Level"){
                scenes[i] = sceneToAdd;
                addLevelButton(sceneToAdd);
                Debug.Log(scenes[i] + " has been added to levels");
            }else{
                Debug.Log(sceneToAdd + " has not been added to levels");

            }
        }

    }

    public void addLevelButton(string sceneName){
        Button LvlSelectBtn = Instantiate( LvlSelectBtnPrefab ) ;
        LvlSelectBtn.transform.SetParent(LevelPanel.transform, false);
        LvlSelectBtn.onClick.AddListener(delegate() { Debug.Log("scene: " + sceneName + " should be loaded."); SceneManager.LoadScene(sceneName); });
        LvlSelectBtn.GetComponentInChildren<TMP_Text>().text = "" + level;
        level++;
    }
        

    public int getNumberOfButtons()
    {
        int i = 0;
        foreach (Transform child in LevelPanel.transform)
        {
            if (child.tag == "lvlButton")
            {
                i++;
            }
        }
        Debug.Log("buttons:" + i);
        return i;
    }
}
