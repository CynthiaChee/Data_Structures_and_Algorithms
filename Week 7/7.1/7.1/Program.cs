//using System;

//namespace _7._1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//        }
//    }
//}

// C# implementation of the approach
using System;
using System.Collections.Generic;

class GFG
{

    /* A Binary Tree node */
    public class TNode
    {
        public int data;
        public TNode left;
        public TNode right;
    }


    /* Function to con AVL tree
    from a sorted array */
    static TNode sortedArrayToBST(int[] arr,
                        int start, int end)
    {
        /* Base Case */
        if (start > end)
            return null;

        /* Get the middle element
        and make it root */
        int mid = (start + end) / 2;
        TNode root = newNode(arr[mid]);

        /* Recursively construct the
        left subtree and make it
        left child of root */
        root.left = sortedArrayToBST(arr, start, mid - 1);

        /* Recursively construct  the
        right subtree and make it
        right child of root */
        root.right = sortedArrayToBST(arr, mid + 1, end);

        return root;
    }

    /* Helper function that allocates
    a new node with the given data
    and null to the left and
    the right pointers. */
    static TNode newNode(int data)
    {
        TNode node = new TNode();
        node.data = data;
        node.left = null;
        node.right = null;

        return node;
    }

    // This function is used for testing purpose
    static void printLevelOrder(TNode root)
    {
        if (root == null) return;

        Queue<TNode> q = new Queue<TNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            TNode node = q.Peek();
            Console.Write(node.data + " ");
            q.Dequeue();
            if (node.left != null)
                q.Enqueue(node.left);
            if (node.right != null)
                q.Enqueue(node.right);
        }
    }

    /* Driver code */
    public static void Main()
    {

        // Assuming the array is sorted
        int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
        int n = arr.Length;

        /* Convert List to AVL tree */
        TNode root = sortedArrayToBST(arr, 0, n - 1);
        printLevelOrder(root);
    }
}