using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following items and priorities: item1 (1),
    // item2 (2), item3 (3) and dequeue an item from the queue that will have the
    // highest priority.
    // Expected Result: "item3"
    // Defect(s) Found: The Dequeue method did not return the value with the highest
    // priority, since the loop used to determine the index of the item with the highest
    // priority did not take into account all the elements in the list, and this is
    // necessary to ensure that all the elements are evaluated. The method was not
    // removing the item from the queue either After correcting this error the test is successful.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("item1", 1);
        priorityQueue.Enqueue("item2", 2);
        priorityQueue.Enqueue("item3", 3);

        PriorityItem expectedResult = new PriorityItem("item3", 3);

        var actualResult = priorityQueue.Dequeue();
        Assert.AreEqual(expectedResult.Value, actualResult, "The value to be returned should be item3, since it has the highest priority.");
    }

    [TestMethod]
    // Scenario: Create queue with the following items and priorities: item1 (1),
    // item2 (6), item3 (2), item4 (6) and dequeue an item from the queue that will
    // have the highest priority and its position will be at the front of the queue
    // or closer to it, even if there are items with the same priority.
    // Expected Result: "item2"
    // Defect(s) Found: The Dequeue method did not evaluate all the elements, since the
    // complete list was not taken into consideration. Also, the method allowed that if
    // there were values of equal priorities the returned value was the last one found,
    // not the one at the front of the queue it was not removing the item from the
    // queue either. After correcting these errors the test was successful.
    public void TestPriorityQueue_FrontHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("item1", 1);
        priorityQueue.Enqueue("item2", 6);
        priorityQueue.Enqueue("item3", 2);
        priorityQueue.Enqueue("item4", 6);

        PriorityItem expectedResult = new PriorityItem("item2", 6);
        var actualResult = priorityQueue.Dequeue();
        Assert.AreEqual(expectedResult.Value, actualResult, "The value to be returned should be item2, since it has the highest priority and is at the front of the queue.");
    }

    [TestMethod]
    // Scenario: Create queue with the following items and priorities: item1 (10),
    // item2 (6), item3 (2), item4 (6), item5 (10), item6 (5), item7 (2), item8 (1)
    // Run it until the queue is empty and record the order in which the items were
    // dequeued.
    // Expected Result: item1, item5, item2, item4, item6, item3, item7, item8
    // Defect(s) Found: The Dequeue method did not evaluate all the elements, since the
    // complete list was not taken into consideration. Also, the method allowed that if
    // there were values of equal priorities the returned value was the last one found,
    // not the one at the front of the queue and it was not removing the item from the
    // queue either. After correcting these errors the test was successful.
    public void TestPriorityQueue_HighestPriorityArray()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("item1", 10);
        priorityQueue.Enqueue("item2", 6);
        priorityQueue.Enqueue("item3", 2);
        priorityQueue.Enqueue("item4", 6);
        priorityQueue.Enqueue("item5", 10);
        priorityQueue.Enqueue("item6", 5);
        priorityQueue.Enqueue("item7", 2);
        priorityQueue.Enqueue("item8", 1);

        string[] expectedResult = ["item1", "item5", "item2", "item4", "item6", "item3", "item7", "item8"];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var actualResult = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], actualResult);
        }
    }

    [TestMethod]
    // Scenario: Try to the dequeue an item from an empty queue.
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: There is no defect in this case because the error is handled
    // correctly when the queue is empty, and the message is the same as expected in the test.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}