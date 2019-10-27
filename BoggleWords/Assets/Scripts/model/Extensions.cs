
  public static  class Extensions
    {
        /// <summary>
        /// Extension Function to check the validation of string whether string is integer or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
     public static bool CheckValidString(this string str)
     {

           if(string.IsNullOrEmpty(str))
           {
               return false;
           }

            int refrenceInteger;
            if (!int.TryParse(str, out refrenceInteger))
            {
                return false;
            }
            return true;
            
        }
    }

