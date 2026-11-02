using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - Test the priority queue against the requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities.
    // The highest priority item is added last.
    // Expected Result: C, B, A
    // Defect(s) Found: The original code skips the last item
    // when searching for the highest priority. It also
    // returns items without removing them from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add three items with the same priority.
    // Expected Result: A, B, C in FIFO order.
    // Defect(s) Found: The original code uses >= when
    // comparing priorities, causing later items to be
    // selected before earlier items with equal priority.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add one item and remove it from the queue.
    // Expected Result: The item is returned and the queue
    // becomes empty.
    // Defect(s) Found: The original code does not remove
    // the item after returning its value.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Only", 2);

        Assert.AreEqual("Only", priorityQueue.Dequeue());
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Attempt to remove an item from an empty queue.
    // Expected Result: InvalidOperationException with the
    // message "The queue is empty."
    // Defect(s) Found: No defect found. The original code
    // already handles an empty queue correctly.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
    }

    [TestMethod]
    // Scenario: Add four items with mixed priorities.
    // Two items share the highest priority.
    // Expected Result: B, D, C, A
    // Defect(s) Found: The original code does not remove
    // dequeued items and does not correctly preserve
    // FIFO order when priorities are equal.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 5);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }
}