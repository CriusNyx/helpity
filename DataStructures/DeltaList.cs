using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Helpity
{
  public class DeltaList<T>
  {
    /// <summary>
    /// The elements in the current list.
    /// </summary>
    public readonly IReadOnlyList<T> elements;

    /// <summary>
    /// /// Elements that were added.
    /// </summary>
    public readonly IReadOnlyList<T> elementsAdded;

    /// <summary>
    /// Elements that were removed.
    /// </summary>
    public readonly IReadOnlyList<T> elementsRemoved;

    /// <summary>
    /// Comparison function.
    /// </summary>
    public readonly Comparer<T> comparer;

    public DeltaList(
      IReadOnlyList<T> elements,
      IReadOnlyList<T> elementsAdded,
      IReadOnlyList<T> elementsRemoved,
      Comparer<T> comparer
    )
    {
      this.elements = elements;
      this.elementsAdded = elementsAdded;
      this.elementsRemoved = elementsRemoved;
      this.comparer = comparer;
    }

    public static DeltaList<T> Create(IEnumerable<T> elements, Comparer<T> comparer = null)
    {
      var arr = elements.ToArray();
      Array.Sort(arr);

      return new DeltaList<T>(
        new ReadOnlyCollection<T>(arr),
        new ReadOnlyCollection<T>(new T[0]),
        new ReadOnlyCollection<T>(new T[0]),
        comparer ?? Comparer<T>.Default
      );
    }

    public DeltaList<T> Diff(IEnumerable<T> newElements)
    {
      var newElementsSorted = newElements.ToArray();
      Array.Sort(newElementsSorted);

      List<T> elementsAdded = new List<T>(newElementsSorted.Length);
      List<T> elementsRemoved = new List<T>(elements.Count());

      int i = 0;
      int j = 0;

      while (i < elements.Count() && j < newElements.Count())
      {
        var a = elements[i];
        var b = newElementsSorted[j];
        var comp = comparer.Compare(a, b);
        if (comp == 0)
        {
          i++;
          j++;
        }
        else if (comp < 0)
        {
          elementsRemoved.Add(a);
          i++;
        }
        else if (comp > 0)
        {
          elementsAdded.Add(b);
          j++;
        }
      }

      while (i < elements.Count())
      {
        elementsRemoved.Add(elements[i]);
        i++;
      }
      while (j < elements.Count())
      {
        elementsAdded.Add(newElementsSorted[j]);
        j++;
      }

      return new DeltaList<T>(
        new ReadOnlyCollection<T>(newElementsSorted),
        new ReadOnlyCollection<T>(elementsAdded.ToArray()),
        new ReadOnlyCollection<T>(elementsRemoved.ToArray()),
        comparer
      );
    }
  }
}
