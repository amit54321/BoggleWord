
using UnityEngine;

[System.Serializable]
public  class BoggleWord:MonoBehaviour
  {

    public int iPosition, jPosition;
    public char character;

    /// <summary>
    /// Sets the boggle word i and j indexPosition
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    public void SetPosition(int i,int j)
    {
        iPosition = i;
        jPosition = j;
    }

    /// <summary>
    /// Sets the character which is written on Inpufield 
    /// </summary>
    /// <param name="s"></param>
   public void SetCharacter(string s)
    {
        character = char.Parse(s);
        UIManager.instance.InputFieldEdit(this);
    }


  }

