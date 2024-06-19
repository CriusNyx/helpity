using System;

namespace Helpity
{
  public class EnumArr<TEnum, TElement> where TEnum : Enum
  {
    TElement[] arr;

    public TElement this[TEnum index]
    {
      get { return arr[Convert.ToInt32(index)]; }
      set { arr[Convert.ToInt32(index)] = value; }
    }

    public EnumArr()
    {
      int len = Enum.GetValues(typeof(TEnum)).Length;
      arr = new TElement[len];
    }
  }
}
