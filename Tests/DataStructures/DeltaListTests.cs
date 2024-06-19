using NUnit.Framework;
using Helpity;
using FluentAssertions;
using UnityEditor;
using System;

public class DeltaListTests
{
  [Test]
  public void CanCreateADeltaList()
  {
    var deltaList = DeltaList<string>.Create();

    CompareDeltaList(deltaList, (new string[] { }, new string[] { }, new string[] { }));
  }

  [Test]
  public void CanCompareDeltaListsWithAddedElements()
  {
    var deltaList = DeltaList<string>.Create().Diff(new string[] { "a" });
    CompareDeltaList(deltaList, (new string[] { "a" }, new string[] { "a" }, new string[] { }));
  }

  [Test]
  public void CanCompareDeltaListsWithRemovedElements()
  {
    var deltaList = DeltaList<string>.Create(new string[] { "a" }).Diff(new string[] { });
    CompareDeltaList(deltaList, (new string[] { }, new string[] { }, new string[] { "a" }));
  }

  static void CompareDeltaList<T>(
    DeltaList<T> list,
    (T[] elements, T[] added, T[] removed) expected
  )
  {
    list.elements
      .Should()
      .BeEquivalentTo(expected.elements, options => options.WithStrictOrdering());
    list.added.Should().BeEquivalentTo(expected.added, options => options.WithStrictOrdering());
    list.removed.Should().BeEquivalentTo(expected.removed, options => options.WithStrictOrdering());
  }
}
