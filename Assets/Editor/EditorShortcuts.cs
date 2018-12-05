using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class EditorShortCuts
{
    [MenuItem("Edit/Save and Play #LEFT+_F5")] // shortcut key F5 to Play (and exit playmode also)
    static void SaveAndPlay()
    {
        if (!Application.isPlaying)
        {
            EditorSceneManager.SaveScene(SceneManager.GetActiveScene(), "", false);
        }

        EditorApplication.ExecuteMenuItem("Edit/Play");
    }

    [MenuItem("Edit/Run _F5")] // shortcut key F5 to Play (and exit playmode also)
    static void Play()
    {
        EditorApplication.ExecuteMenuItem("Edit/Play");

    }
}
