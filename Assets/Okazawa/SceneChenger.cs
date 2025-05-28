using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// ˆÚ“®‚µ‚½‚¢Sceneæ‚Ì–¼‘O‚ğ“ü‚ê‚é
    /// </summary>
    /// <param name="loadScene"></param>
    public void SceneLoad(string loadScene)
    {
        SceneManager.LoadScene(loadScene);
    }
}