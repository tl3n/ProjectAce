using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    [UnityTest]
    public IEnumerator HorizontalMove()
    {
        var gameObject = new GameObject();

        yield return null;

        Assert.AreEqual(1, 1);
    }
}
