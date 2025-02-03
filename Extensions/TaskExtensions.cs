using System;
using System.Threading.Tasks;

public static class TaskExtensions
{
  public static Task OnMainThread(this Task task, Action action)
  {
    return Task.Run(async () =>
    {
      await task;
      await Scheduler.OnMainThread(action);
    });
  }

  public static Task OnMainThread<T>(this Task<T> task, Action<T> action)
  {
    return Task.Run(async () =>
    {
      var args = await task;
      await Scheduler.OnMainThread(() => action(args));
    });
  }

  public static Task<T> OnMainThread<T>(this Task task, Func<T> func)
  {
    return Task.Run(async () =>
    {
      await task;
      return await Scheduler.OnMainThread(func);
    });
  }

  public static Task<U> OnMainThread<T, U>(this Task<T> task, Func<T, U> func)
  {
    return Task.Run(async () =>
    {
      var args = await task;
      return await Scheduler.OnMainThread(() => func(args));
    });
  }
}
