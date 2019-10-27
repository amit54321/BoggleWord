using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScreen : MonoBehaviour, IShowMessage
 {
    
    public void ShowMessage(string message)
    {
        UIManager.instance.ShowMessage(message);

    }
    public void ShowLoader()
    {
        UIManager.instance.ShowLoading();

    }
}
