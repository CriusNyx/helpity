using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Scheduler : MonoBehaviour
{
  static Scheduler Instance;
  Queue<Action> queue;

  public void Awake()
  {
    queue = new Queue<Action>();
    if (Instance != null)
    {
      DestroyImmediate(gameObject);
    }
    Instance = this;
  }

  private static void Enqueue(Action action)
  {
    lock (Instance.queue)
    {
      Instance.queue.Enqueue(action);
    }
  }

  public static async Task<T> OnMainThread<T>(Func<T> func)
  {
    TaskCompletionSource<T> taskSource = new TaskCompletionSource<T>();
    Enqueue(() =>
    {
      taskSource.SetResult(func());
    });
    return await taskSource.Task;
  }

  public static async Task OnMainThread(Action action)
  {
    TaskCompletionSource<bool> taskSource = new TaskCompletionSource<bool>();
    Enqueue(() =>
    {
      action();
      taskSource.SetResult(true);
    });
    await taskSource.Task;
  }

  void Update()
  {
    Action[] elements;
    lock (Instance.queue)
    {
      elements = queue?.ToArray() ?? new Action[] { };
      queue.Clear();
    }
    foreach (var element in elements)
    {
      try
      {
        element?.Invoke();
      }
      catch (Exception e)
      {
        Debug.LogError(e);
      }
    }
  }
}
