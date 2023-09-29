using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuBehaviour : MonoBehaviour
{
    UIDocument mainMenu;
    Button playButton;
    Button controlButton;
    Button optionsButton;
    Button creditsButton;
    VisualElement controlsContainer;

    private void OnEnable()
    {
        //root document
        mainMenu = GetComponent<UIDocument>();

        // button asination 
        playButton = mainMenu.rootVisualElement.Q("play") as Button;
        controlButton = mainMenu.rootVisualElement.Q("controls") as Button;
        optionsButton = mainMenu.rootVisualElement.Q("options") as Button;
        creditsButton = mainMenu.rootVisualElement.Q("credits") as Button;
        controlsContainer = mainMenu.rootVisualElement.Q("derecha") as VisualElement;

        if (controlsContainer != null) { Debug.Log("si encontro derecha"); }

        //callbacks
        playButton.RegisterCallback<ClickEvent>(playOpen);
        controlButton.RegisterCallback<ClickEvent>(controlOpen);
    }

    public void playOpen(ClickEvent evnt)
    {
        Debug.Log("play button clicked");
        
    }



    public void controlOpen(ClickEvent evnt)
    {
        Debug.Log("cntr button clicked");
        controlsContainer.AddToClassList("derecha-active");
        controlsContainer.RemoveFromClassList("derecha");
    }
}