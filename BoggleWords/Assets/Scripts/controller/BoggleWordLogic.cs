
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoggleWordLogic:MonoBehaviour
{
    private int height, length;

    public int Height{
        get { return height; }
      
        }

    public int Length
    {
        get { return length; }
      
    }

    public   BoggleWord[,] boggleWordList;
    public BoggleWord lastWord;
    public List<BoggleWord> alreadyChecked;
    public List<CheckIndex> checkIndexes;

    public static BoggleWordLogic instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    /// <summary>
    /// Sets the value of grids calls when this screen gets active
    /// </summary>
    /// <param name="length"></param>
    /// <param name="height"></param>
    public void SetGrid(int length,int height)
    {
        this.height = height;
        this.length = length;
        boggleWordList = new BoggleWord[length, height];
        SetCheckIndexes();
    }

    /// <summary>
    /// Added this function because here adding 8 adjacent neighbours indexes..
    /// In case of other requirement can add other neighbours here
    /// </summary>
    public void SetCheckIndexes()
    {
        checkIndexes = new List<CheckIndex>();
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                {

                }
                else
                {
                    CheckIndex checkIndex = new CheckIndex();
                    checkIndex.i = i;
                    checkIndex.j = j;
                    checkIndexes.Add(checkIndex);
                }
            }
        }
    }


    /// <summary>
    /// Main logic function calls from the UI script BoggleWordScreen..
    /// Need to call this function to begin the search
    /// </summary>
    /// <param name="str"></param>
    /// <param name="returnFunc"></param>
    public void SearchWordLogic(string str,UnityAction<bool> returnFunc)
    {
        alreadyChecked = new List<BoggleWord>();
        str = str.ToUpper();
        char[] allCharacters = str.ToCharArray();
        bool foundTheWord = true;
        for (int i = 0; i < allCharacters.Length; i++)
        {

            if (!Check(allCharacters[i], i))
            {
                foundTheWord = false;
                break;
            }
           
        }
        returnFunc(foundTheWord);
    }

    /// <summary>
    /// Checks if any Boggle character already checked before
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    bool CheckIfAlreadyExist(BoggleWord word)
    {
        if (alreadyChecked.Contains(word))
            return false;

      
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="c"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    bool Check(char c, int index)
    {
       
        if (index == 0)
        {
            foreach (BoggleWord bw in boggleWordList)
            {
                if (CheckIfAlreadyExist(bw))
                {
                    if (bw.character == c)
                    {
                        alreadyChecked.Add(bw);
                        lastWord = bw;
                        return true;
                    }
                }
            }


        }

        else
        {

            lastWord = SearchIfCharacterFound(c);
         
            if (lastWord != null)
            {
                alreadyChecked.Add(lastWord);
                return true;
            }


        }
       
        return false;

    }

    /// <summary>
    /// Searches if character found and return that boggleWord
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    BoggleWord SearchIfCharacterFound(char c)
    {

       
        foreach (CheckIndex checkIndex in checkIndexes)
        {

            int lastindexXPos = lastWord.iPosition + checkIndex.i;
            int lastindexYPos = lastWord.jPosition + checkIndex.j;
            if (CheckLegalIndex(lastindexXPos,
                lastindexYPos))
            {
               
                if (CheckIfAlreadyExist(boggleWordList[lastindexXPos,
                   lastindexYPos]))
                {
                   
                    if (boggleWordList[lastindexXPos,
                    lastindexYPos].character == c)
                    {
                       
                        return boggleWordList[lastindexXPos,
                        lastindexYPos];
                    }
                }
            }
        }
        return null;

    }

    /// <summary>
    /// Checks if index not going out of bound
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    bool CheckLegalIndex(int i, int j)
    {
       
        if (i >= 0 && i < Length && j >= 0 && j < Height)
        {
            return true;
        }
        return false;
    }


}

[System.Serializable]
public class CheckIndex
{
    public int i, j;
}