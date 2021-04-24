using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{

    

    [SerializeField] private Animator CrossFade;
    [SerializeField] private Animator Diagonal;
    [SerializeField] private Animator Other;

    static private Animator transition = null;


    //The string will take you to the scene you want, if null, it does level +1.
    public void TransitionCall(string sceneName, string transitionType)
    {
        switch (transitionType)
        {
            //here we can tell the amount of seconds different transitions will take and make sure we call the right ones.
            case "Fade":
            transition = CrossFade;
            break;

            case "Diagonal":
            transition = Diagonal;
            break;

            case "Other":
            transition = Other;
            break;

            default:
            Debug.Log("transition string not recognised, use one of the following: Fade, Diagonal or Other.");
            return;
        }


        if(sceneName == "down")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
        }
        //The string will take you to the scene you want, if null, it does level +1.
        if (sceneName == null)
        {
            int temp = SceneManager.GetActiveScene().buildIndex + 1;
            Debug.Log(temp);
            if (SceneManager.sceneCountInBuildSettings == temp)
            {
                
                Debug.Log("No next scene to load in build Index, Reloading current level instead.");
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
                return;
            }
            Debug.Log("Loading next scene in buildIndex, IndexNumber: " + SceneManager.GetActiveScene().buildIndex + 1);
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            return;
        }

        Debug.Log("Loading in Scene with sceneName: " + sceneName);
        StartCoroutine(LoadLevel(SceneManager.GetSceneByName(sceneName).buildIndex));
 
    }

    //coroutine that makes sure it goes well~
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("SceneTransition");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }


}
