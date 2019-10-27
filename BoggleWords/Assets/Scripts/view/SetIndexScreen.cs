
using UnityEngine;
using UnityEngine.UI;

public class SetIndexScreen : BaseScreen
{ 
    [SerializeField]
    InputField lengthOfGrid, heightOfGrid;
   
    /// <summary>
    /// Sets the grid ...Calls by button
    /// </summary>
    public void SetGrid()
    {

      
        if(!lengthOfGrid.text.CheckValidString())
        {
            ShowMessage(Constants.INPUTISBLANK);
            return;
        }

        if (!heightOfGrid.text.CheckValidString())
        {
            ShowMessage(Constants.INPUTISBLANK);
            return;
        }

    BoggleWordLogic.instance.SetGrid(int.Parse(lengthOfGrid.text),
                          int.Parse(heightOfGrid.text));
       
        UIManager.instance.ChangeScreen(UIManager.instance.boggleWordScreen);


    }

   

	
}
