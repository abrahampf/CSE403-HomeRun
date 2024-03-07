using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
// using DBManager;

public class Database
{
    // A Test behaves as an ordinary method
    [Test]
    public void DBManagerTests() {
        Assert.AreEqual(DBManager.username, null);
        Assert.AreEqual(DBManager.currentScore, 0);
        Assert.AreEqual(DBManager.highscore, 0);
    }

}