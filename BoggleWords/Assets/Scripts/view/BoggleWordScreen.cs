
using UnityEngine;
using UnityEngine.UI;

public  class BoggleWordScreen:BaseScreen
 {
    [SerializeField]
    BoggleWord boogleWordPrefab;
    [SerializeField]
     BoggleWordLogic boggleWordLogic;
    [SerializeField]
    Transform parentOfBoggleCharacters;
    [SerializeField]
    InputField searchWord;
    [SerializeField]
    GridLayoutGroup gridLayOut;
    [SerializeField]
    Text showAnswer;

    InputField selectedInputField;

    void Awake()
    {
       
        boggleWordLogic = BoggleWordLogic.instance;
    }

    
    void Disable()
    {
     //   UIManager.instance.inputFieldEdited -= GetNextInputField;
    }

  

    public void OnEnable()
    {
      //  UIManager.instance.inputFieldEdited += GetNextInputField;
        SetGrid();

    }
    /// <summary>
    /// Sets the grid when this screen gets active
    /// </summary>
    public void SetGrid()
    {
        Reset();
        SetGridLayout();
   
      
        for (int i=0;i< boggleWordLogic.Length;i++)
        {
            for (int j = 0; j < boggleWordLogic.Height; j++)
            {
               {
                    InstantiateBoggleWord(i, j);
                }
            }
        }
        SetselectedInputField( boggleWordLogic.boggleWordList[0, 0]);

    }

    /// <summary>
    /// Instantiate all inputfields of characters
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    void InstantiateBoggleWord(int i, int j)
    {
        BoggleWord boggleWord = Instantiate(boogleWordPrefab);
        boggleWord.transform.SetParent(parentOfBoggleCharacters);
        boggleWord.SetPosition(i, j);

        boggleWordLogic.boggleWordList[i, j] = boggleWord;

    }

    /// <summary>
    /// Get Next inputfield to select
    /// </summary>
    /// <param name="word"></param>
    //void GetNextInputField(BoggleWord word)
    //{
    //    BoggleWord nextBoggleWord = null;
    //    if(word.iPosition== boggleWordLogic.Length - 1 &&
    //        word.jPosition == boggleWordLogic.Height - 1)
    //    {
    //        nextBoggleWord = boggleWordLogic.boggleWordList[0, 0];
    //    }
    //    else if(word.iPosition == boggleWordLogic.Length-1)
    //    {
          
    //        nextBoggleWord = boggleWordLogic.boggleWordList[word.iPosition +1,word.jPosition];
    //    }
    //    else
    //    {
          
    //        nextBoggleWord = boggleWordLogic.boggleWordList[word.iPosition,word.jPosition + 1];
    //    }
    //    SetselectedInputField(nextBoggleWord);
    //}

    /// <summary>
    /// Its select the inputfield if something typed it will select
    /// </summary>
    /// <param name="word"></param>
    void SetselectedInputField(BoggleWord word)
    {
        InputField field = word.GetComponent<InputField>();
        field.Select();
        selectedInputField = field;
    }

    /// <summary>
    /// Sets the grid layout group according to height and length
    /// </summary>
    void SetGridLayout()
    {
        gridLayOut.constraintCount = boggleWordLogic.Length;
        float maximumIndexLength = Mathf.Max(new float[] { boggleWordLogic.Length,
        boggleWordLogic.Height});
        float size = parentOfBoggleCharacters.GetComponent<RectTransform>().sizeDelta.y / maximumIndexLength;
        gridLayOut.cellSize = new Vector2(size,size);
        gridLayOut.spacing = new Vector2((parentOfBoggleCharacters.GetComponent<RectTransform>().sizeDelta.x -
           size * boggleWordLogic.Length) / boggleWordLogic.Length
            , (parentOfBoggleCharacters.GetComponent<RectTransform>().sizeDelta.y -
           size * boggleWordLogic.Height) / boggleWordLogic.Height);
        gridLayOut.padding.left = (int)(gridLayOut.spacing.x) / 2;
        gridLayOut.padding.top = (int)(gridLayOut.spacing.y) / 2;
    }

   

    /// <summary>
    /// Resets all text fields and Input fields
    /// </summary>
    void Reset()
    {
        foreach(Transform t in parentOfBoggleCharacters)
        {
            Destroy(t.gameObject);
        }
        searchWord.text = "";
        showAnswer.text = "";
    }

    /// <summary>
    /// Find word ...calls from the button
    /// </summary>
    public void FindWord()
    {
       
        //foreach (BoggleWord bw in boggleWordLogic.boggleWordList)
        //{
        //    Debug.Log(bw.character.ToString());
        //    if(string.IsNullOrEmpty(bw.character.ToString()) )
        //    {
        //        ShowMessage(Constants.INPUTISBLANK);
        //        return;
        //    }

        //}

        if (string.IsNullOrEmpty(searchWord.text))
        {
            ShowMessage(Constants.INPUTISBLANK);
            return;
        }

        boggleWordLogic.SearchWordLogic(searchWord.text, WordFound);
        
    }

    /// <summary>
    /// Callback function which will get whether the word found or not from BoggleWordLogic class
    /// </summary>
    /// <param name="wordFound"></param>
    void WordFound(bool wordFound)
    {
        if(wordFound)
        {
            Debug.Log("WORD FOUND");
            showAnswer.text = "WORD FOUND";
        }
        else
        {
            showAnswer.text = "WORD NOT FOUND";
            Debug.Log("WORD NOT FOUND");
        }

    }

 }
