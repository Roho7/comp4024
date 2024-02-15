using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update

    public Button LvlSelectBtnPrefab;
    public GameObject LevelPanel;
    void Start () { 

        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;     
        string[] scenes = new string[sceneCount];

        for( int i = 0; i < sceneCount; i++ ) {
            string sceneToAdd = System.IO.Path.GetFileNameWithoutExtension( UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( i ) );
            string checkString = sceneToAdd.Substring(0,5);
            if ( checkString == "Level"){
                scenes[i] = sceneToAdd;
                Debug.Log(scenes[i]);
                addLevelButton(sceneToAdd);
            }
        }

    }

    public void addLevelButton(string sceneName){
        Button LvlSelectBtn = Instantiate( LvlSelectBtnPrefab ) ;
        LvlSelectBtn.transform.SetParent(LevelPanel.transform, false);
        LvlSelectBtn.onClick.AddListener(delegate() { SceneManager.LoadScene(sceneName); });
    }
        
}
