using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TreeNode
/// </summary>
public class TreeNode
{
    public TreeNode left;
    public TreeNode right;
    public int data;

    public TreeNode() { }
	
    public TreeNode(TreeNode left , TreeNode right , int data)
	{
        this.left = left;
        this.right = right;
        this.data = data;
	}

    public TreeNode getLeft() 
    {
        return left;
    }
    public TreeNode getRight()
    {
        return right;
    }

    public int getData()
    {
        return data;
    }
}