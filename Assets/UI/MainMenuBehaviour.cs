using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Threading;

public class MainMenuBehaviour : MonoBehaviour
{
    UIDocument mainMenu;
    //main buttons
    Button playButton;
    Button controlButton;
    Button optionsButton;
    Button creditsButton;
    //volume
    Slider volumeSlider;
    //controls
    Button backButton1;
    VisualElement controlsContainer;
    //credits
    Button backButton2;
    VisualElement creditsContainer;
    //options
    Button backButton3;
    VisualElement optionsContainer;

    private void OnEnable()
    {
        //root document
        mainMenu = GetComponent<UIDocument>();

        //play button
        playButton = mainMenu.rootVisualElement.Q("play") as Button;

        // volume slider
        volumeSlider = mainMenu.rootVisualElement.Q("volumenSlider") as Slider;

        //controls
        controlButton = mainMenu.rootVisualElement.Q("controls") as Button;
        controlsContainer = mainMenu.rootVisualElement.Q("controlsmenu") as VisualElement;
        backButton1 = mainMenu.rootVisualElement.Q("backbutton1") as Button;

        //options
        optionsButton = mainMenu.rootVisualElement.Q("options") as Button;
        optionsContainer = mainMenu.rootVisualElement.Q("optionsmenu") as VisualElement;
        backButton2 = mainMenu.rootVisualElement.Q("backbutton2") as Button;

        //credits
        creditsButton = mainMenu.rootVisualElement.Q("credits") as Button;
        creditsContainer = mainMenu.rootVisualElement.Q("creditsmenu") as VisualElement;
        backButton3 = mainMenu.rootVisualElement.Q("backbutton3") as Button;


        if (volumeSlider != null) { Debug.Log("si encontro volume"); }
    

        //callbacks
        playButton.RegisterCallback<ClickEvent>(playOpen);
        controlButton.RegisterCallback<ClickEvent>(controlOpen);
        optionsButton.RegisterCallback<ClickEvent>(optionsOpen);
        creditsButton.RegisterCallback<ClickEvent>(creditsOpen);
        backButton1.RegisterCallback<ClickEvent>(controlClose);
        backButton2.RegisterCallback<ClickEvent>(optionsClose);
        backButton3.RegisterCallback<ClickEvent>(creditsClose);
    }

    public void playOpen(ClickEvent evnt)
    {
        Debug.Log("play button clicked");
        SceneManager.LoadScene("OnlyLevel4444", LoadSceneMode.Single);
    }


    public void controlOpen(ClickEvent evnt)
    {
        Debug.Log("cntr button clicked");
        if (creditsContainer.ClassListContains("derecha3-active") || optionsContainer.ClassListContains("derecha2-active"))
        {
            optionsClose(evnt);
            creditsClose(evnt);
            Thread.Sleep(500);
        }
        controlsContainer.AddToClassList("derecha-active");
        controlsContainer.RemoveFromClassList("derecha");

    }

    public void creditsOpen(ClickEvent evnt)
    {
        Debug.Log("credits button clicked");
        if(controlsContainer.ClassListContains("derecha-active") || optionsContainer.ClassListContains("derecha2-active"))
        {
            optionsClose(evnt);
            controlClose(evnt);
            Thread.Sleep(500);
        }
        creditsContainer.AddToClassList("derecha3-active");
        creditsContainer.RemoveFromClassList("derecha");
        
    }

    public void optionsOpen(ClickEvent evnt)
    {
        Debug.Log("opns button clicked");
        if (controlsContainer.ClassListContains("derecha-active") || creditsContainer.ClassListContains("derecha3-active"))
        {
            creditsClose(evnt);
            controlClose(evnt);
            Thread.Sleep(500);
        }
            
        optionsContainer.AddToClassList("derecha2-active");
        optionsContainer.RemoveFromClassList("derecha");
    }

    public void controlClose(ClickEvent evnt)
    {
        controlsContainer.RemoveFromClassList("derecha-active");
        controlsContainer.AddToClassList("derecha");
    }

    public void creditsClose(ClickEvent evnt)
    {
        creditsContainer.RemoveFromClassList("derecha3-active");
        creditsContainer.AddToClassList("derecha");
    }
    public void optionsClose(ClickEvent evnt)
    {
        optionsContainer.RemoveFromClassList("derecha2-active");
        optionsContainer.AddToClassList("derecha");
    }
}