using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public delegate void InputFieldEdited(BoggleWord word);
    public event InputFieldEdited inputFieldEdited;

    /// <summary>
    /// Current screen that is visible
    /// </summary>
    public BaseScreen currentScreen;
    /// <summary>
    /// Text which shows any message or error
    /// </summary>
    public Text mesageText;

    public Loader loader;

    /// <summary>
    /// Singleton of this class
    /// </summary>
    static public UIManager instance;


    public BaseScreen boggleWordScreen;
    public BaseScreen setIndexScreen;


    void Awake()
    {

        if (instance == null)
            instance = this;
       
    }

    /// <summary>
    /// Active the current screen and deactivate the previous screen
    /// </summary>
    /// <param name="screen"></param>
    public void ChangeScreen(BaseScreen screen)
    {
        currentScreen.gameObject.SetActive(false);
        currentScreen = screen;
        currentScreen.gameObject.SetActive(true);
        DisableMessage(0);
    }

    /// <summary>
    /// Shows the message
    /// </summary>
    /// <param name="message"></param>
    public void ShowMessage(string message)
    {
        mesageText.text = message;
        StartCoroutine(DisableMessage(2));
    }

    /// <summary>
    /// Disables message after given time
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    IEnumerator DisableMessage(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        mesageText.text = "";

    }

    /// <summary>
    /// Shows the loader
    /// </summary>
    public void ShowLoading()
    {
        loader.Load();
    }


    /// <summary>
    /// Hides the loader
    /// </summary>
    public void HideLoading()
    {
        loader.UnLoad();
    }

    public void InputFieldEdit(BoggleWord word)
    {
        if(inputFieldEdited!=null)
        {
            inputFieldEdited(word);
        }
    }
}
