using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JustRestartScene : MonoBehaviour
{
    public void restartScene(){
        SceneManager.LoadScene("SpaceshipScene", LoadSceneMode.Single);
    }
}
