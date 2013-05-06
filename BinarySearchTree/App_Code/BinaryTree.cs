using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BinaryTree
/// </summary>
public class BinaryTree
{
    public TreeNode root;

    public void setRoot(int data)
    {
        root = new TreeNode(null, null, data);
    }

    public void insert(TreeNode root, int data) 
    {
        internalInsert(root, data);
    }

    private void internalInsert(TreeNode node, int data)
    {
        if (data.Equals(node.getData()))
        { 
            return; 
        }
        else if (data < node.getData())
        {
            if (node.getLeft()==null) 
            {
                node.left = new TreeNode(null, null, data);
            }
            else
            {
                internalInsert(node.getLeft(), data);
            }
        }
        else if (data > node.getData())
        {
            if (node.getRight()==null)
            {
                node.right = new TreeNode(null, null, data);
            }
            else
            {
                internalInsert(node.getRight(), data);
            }
        }

    }

    public string inorder(TreeNode root)
    {
        string output = "";
        internalInorder(root,ref output);
        return output;
    }

    private void internalInorder(TreeNode node, ref string output) 
    {
        if (node != null)
        {
            internalInorder(node.getLeft(), ref output);
            output += Convert.ToString(node.getData());
            output += " ";
            internalInorder(node.getRight(), ref output);
        }
    }

    public string postorder(TreeNode root)
    {
        string output = "";
        internalPostOrder(root, ref output);
        return output;
    }

    private void internalPostOrder(TreeNode node, ref string output)
    {
        if (node != null)
        {
            internalPostOrder(node.left, ref output);
            internalPostOrder(node.right, ref output);
            output += Convert.ToString(node.getData());
            output += " ";
        }
    }
    public string preorder(TreeNode root)
    {
        string output = "";
        internalPreorder(root, ref output);
        return output;
    }
    private void internalPreorder(TreeNode node, ref string output)
	{
		if(node!=null)
		{
            output += Convert.ToString(node.getData());
            output += " ";
            internalPreorder(node.getLeft(), ref output);
            internalPreorder(node.getRight(), ref output);
		}
	}

	public BinaryTree()
	{

	}
}