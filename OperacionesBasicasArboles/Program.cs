using System;
class Program
{
    static void Main(string[] args)
    {
        BinaryTree binaryTree = new BinaryTree();

        // Insertion
        binaryTree.Insert(50);
        binaryTree.Insert(30);
        binaryTree.Insert(70);
        binaryTree.Insert(20);
        binaryTree.Insert(40);
        binaryTree.Insert(60);
        binaryTree.Insert(80);

        // Display the Binary Tree after Insertion
        Console.WriteLine("Binary Tree after Insertion:");
        Console.WriteLine("In-Order Traversal:");
        binaryTree.InOrderTraversal(); // Start traversal from the root
        Console.WriteLine();

        // Search
        int searchValue = 40;
        bool found = binaryTree.Search(searchValue);
        Console.WriteLine($"Search for {searchValue}: {found}");

        // Deletion
        int deleteValue = 30;
        binaryTree.Delete(deleteValue);
        Console.WriteLine($"Deleted {deleteValue} from the Binary Tree:");

        // Display the Binary Tree after Deletion
        Console.WriteLine("In-Order Traversal after Deletion:");
        binaryTree.InOrderTraversal(); // Start traversal from the root
        Console.WriteLine();
    }
}
class TreeNode
{
    public int Data;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int data)
    {
        Data = data;
        Left = Right = null;
    }
}

class BinaryTree
{
    private TreeNode root;

    public BinaryTree()
    {
        root = null;
    }
    public void InOrderTraversal()
    {
        InOrderRecursive(root);
    }
    private void InOrderRecursive(TreeNode node)
    {
        if (node != null)
        {
            InOrderRecursive(node.Left);
            Console.Write(node.Data + " ");
            InOrderRecursive(node.Right);
        }
    }


    // Insertion operation
    public void Insert(int data)
    {
        root = InsertRecursive(root, data);
    }

    private TreeNode InsertRecursive(TreeNode current, int data)
    {
        if (current == null)
        {
            return new TreeNode(data);
        }

        if (data < current.Data)
        {
            current.Left = InsertRecursive(current.Left, data);
        }
        else if (data > current.Data)
        {
            current.Right = InsertRecursive(current.Right, data);
        }

        return current;
    }

    // Deletion operation
    public void Delete(int data)
    {
        root = DeleteRecursive(root, data);
    }

    private TreeNode DeleteRecursive(TreeNode current, int data)
    {
        if (current == null)
        {
            return current;
        }

        if (data < current.Data)
        {
            current.Left = DeleteRecursive(current.Left, data);
        }
        else if (data > current.Data)
        {
            current.Right = DeleteRecursive(current.Right, data);
        }
        else
        {
            if (current.Left == null)
            {
                return current.Right;
            }
            else if (current.Right == null)
            {
                return current.Left;
            }

            current.Data = FindMinValue(current.Right);
            current.Right = DeleteRecursive(current.Right, current.Data);
        }

        return current;
    }

    private int FindMinValue(TreeNode node)
    {
        int minValue = node.Data;
        while (node.Left != null)
        {
            minValue = node.Left.Data;
            node = node.Left;
        }
        return minValue;
    }

    // Search operation
    public bool Search(int data)
    {
        return SearchRecursive(root, data);
    }

    private bool SearchRecursive(TreeNode current, int data)
    {
        if (current == null)
        {
            return false;
        }

        if (data == current.Data)
        {
            return true;
        }

        if (data < current.Data)
        {
            return SearchRecursive(current.Left, data);
        }

        return SearchRecursive(current.Right, data);
    }
}
