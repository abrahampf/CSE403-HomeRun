<!---
Baseball Unity test examples

Example 1: To test if we print homerun when the bat hits the ball.

```
using NUnit.Framework;
using UnityEngine;

public class BallControllerTests
{
    public void HomeRunMessageLoggedOnBatCollision()
    {
        GameObject ballObject = new GameObject("Ball");
        BallController ballController = ballObject.AddComponent<BallController>();

        GameObject batObject = new GameObject("Bat");
        batObject.tag = "Bat";

        Collision collision = new Collision();
        collision.gameObject = batObject;

        // Act
        ballController.OnCollisionEnter(collision);

        // Assert
        LogAssert.Expect(LogType.Log, "Home Run!");
    }
}
```

Example 2: Checks if the ball exists in the scene

```
using NUnit.Framework;
using UnityEngine;

public class BaseballGameTests
{

    public void BallExistsInScene()
    {
        // Arrange
        GameObject ball = new GameObject("Ball");

        // Act
        BallController ballController = ball.AddComponent<BallController>();

        // Assert
        Assert.NotNull(ballController, "BallController component should exist on the Ball object");
    }
}
```

Example 3: Checks if the player scores increments when a hit occurs

```
using NUnit.Framework;
using UnityEngine;

public class BaseballGameTests
{

    public void ScoreIncrementsOnHit()
    {
        // Arrange
        GameObject gameManagerObject = new GameObject();
        GameManager gameManager = gameManagerObject.AddComponent<GameManager>();

        // Act
        gameManager.OnHit();

        // Assert
        Assert.AreEqual(1, gameManager.GetScore(), "Score should increment to 1 after a hit");
    }
}
```
--->
