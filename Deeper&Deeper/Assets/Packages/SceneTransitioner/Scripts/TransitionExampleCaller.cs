using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionExampleCaller : MonoBehaviour
{
    [SerializeField] private SceneTransitionController transition;


    //important tidbit, be sure to turn off all the transitions you dont want.

    //void Update()
    //{
    //    if (Input.GetKeyDown("space"))
    //    {
    //        transition.TransitionCall(null, "Diagonal"); //since it says null, it will go to whichever scene is next in the build index.
    //    }
    //    if (Input.GetKeyDown("a"))
    //    {
    //        transition.TransitionCall("name", "CrossFade"); //Will now try and find the scene you've named "Name", and will use a crossfade.
    //    }
    //    if (Input.GetKeyDown("d"))
    //    {
    //        transition.TransitionCall(null, "Other"); 
    //        //should you want to add your own option, then you can copy paste one of the others and slot it in at the Other slot in the SceneTransitionController.
    //    }
    //}


    public void NextScene(string name)
    {
        transition.TransitionCall(null, "Fade");
        Debug.Log("loading: " + name);
    }

    public void SceneUp()
    {
        transition.TransitionCall(null, "Fade");

    }

    public void SceneDown()
    {
        transition.TransitionCall("down", "Fade");
    }

    public void Win()
    {
        //to final scene.
    }

}
