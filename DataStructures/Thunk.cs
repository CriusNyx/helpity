using System;

namespace Helpity
{
  /// <summary>
  /// A thunk represents a value that will not be ready until requested.
  /// After the value is requested the first time the thunk will keep the result in memory until it is garbage collected.
  /// Thunks are useful for lazily computing expensive functions, or for caching the result of an expensive computation.
  /// Thunks can also be used to assign default values to fields.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class Thunk<T>
  {
    private Func<T> generator;
    private bool generated = false;
    private T _value = default;
    public T value
    {
      get
      {
        if (!generated)
        {
          generated = true;
          _value = generator();
        }
        return _value;
      }
    }

    public Thunk(Func<T> generator)
    {
      this.generator = generator;
    }
  }
}
