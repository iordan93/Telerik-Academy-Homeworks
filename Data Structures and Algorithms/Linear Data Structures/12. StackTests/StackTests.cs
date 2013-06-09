using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;

[TestClass]
public class StackTests
{
    [TestMethod]
    public void TestStackConstructor()
    {
        Stack<int> stack = new Stack<int>();
        Assert.IsNotNull(stack);
        Assert.AreEqual(0, stack.Count);
    }

    [TestMethod]
    public void TestStackPushSingleValue()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(3);

        Assert.AreEqual(1, stack.Count);
        Assert.AreEqual(3, stack.First());
    }

    [TestMethod]
    public void TestStackPushManyValues()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(15);
        stack.Push(54865);
        stack.Push(215);
        stack.Push(892140);
        stack.Push(16545);
        stack.Push(1856512);
        stack.Push(150156);
        stack.Push(517);
        stack.Push(156);
        stack.Push(456512);

        Assert.AreEqual(10, stack.Count);
        Assert.AreEqual(456512, stack.First());
        Assert.AreEqual(156, stack.Skip(1).First());
        Assert.AreEqual(517, stack.Skip(2).First());
        Assert.AreEqual(150156, stack.Skip(3).First());
        Assert.AreEqual(1856512, stack.Skip(4).First());
        Assert.AreEqual(16545, stack.Skip(5).First());
        Assert.AreEqual(892140, stack.Skip(6).First());
        Assert.AreEqual(215, stack.Skip(7).First());
        Assert.AreEqual(54865, stack.Skip(8).First());
        Assert.AreEqual(15, stack.Skip(9).First());
    }

    [TestMethod]
    public void TestStackPopSingleValue()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(15);
        stack.Push(54865);
        stack.Push(215);
        stack.Push(892140);
        stack.Push(16545);
        stack.Push(1856512);
        stack.Push(150156);
        stack.Push(517);
        stack.Push(156);
        stack.Push(456512);

        int first = stack.First();
        int popped = stack.Pop();

        Assert.AreEqual(first, popped);
    }

    [TestMethod]
    public void TestStackPopManyValues()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(15);
        stack.Push(54865);
        stack.Push(215);
        stack.Push(892140);
        stack.Push(16545);
        stack.Push(1856512);
        stack.Push(150156);
        stack.Push(517);
        stack.Push(156);
        stack.Push(456512);
        int stackCount = stack.Count;

        for (int i = 0; i < stackCount; i++)
        {
            int first = stack.First();
            int popped = stack.Pop();

            Assert.AreEqual(first, popped);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestStackPopEmpty()
    {
        Stack<int> stack = new Stack<int>();
        stack.Pop();
    }

    [TestMethod]
    public void TestStackPeek()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(15);
        stack.Push(54865);
        stack.Push(215);
        stack.Push(892140);
        stack.Push(16545);
        stack.Push(1856512);
        stack.Push(150156);
        stack.Push(517);
        stack.Push(156);
        stack.Push(456512);

        int first = stack.First();
        int topElement = stack.Peek();

        Assert.AreEqual(first, topElement);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestStackPeekEmpty()
    {
        Stack<int> stack = new Stack<int>();
        stack.Peek();
    }

    [TestMethod]
    public void TestStackClear()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(15);
        stack.Push(54865);
        stack.Push(215);
        stack.Push(892140);
        stack.Push(16545);
        stack.Push(1856512);
        stack.Push(150156);
        stack.Push(517);
        stack.Push(156);
        stack.Push(456512);

        stack.Clear();

        Assert.IsNotNull(stack);
        Assert.AreEqual(0, stack.Count);
    }
}