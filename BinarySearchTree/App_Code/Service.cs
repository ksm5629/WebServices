using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    static BinaryTree bt = null;
    /*
     [OperationContract]
	void CreateTree();

    [OperationContract]
    void setRoot(int data);

    [OperationContract]
    string TraverseInorder();


    [OperationContract]
    string TraversePreorder();


    [OperationContract]
    string TraversePostorder();


    [OperationContract]
    void AddElement(int data);
     */
    public void CreateTree()
    {
        bt = new BinaryTree();
    }

    public void setRoot(int data)
    {
        bt.setRoot(data);
    }

    public void AddElement(int data)
    {
        bt.insert(bt.root, data);
    }

    public void AddElements(string data)
    {
        int[] arr = stringToIntArray(data);
        foreach (var a in arr)
        {
            bt.insert(bt.root, a);
        }
        
    }


    private int[] stringToIntArray(String input)
    {
        String[] arr = input.Split(' ');
        int[] newArr = new int[arr.Length];
        int count = 0;
        foreach (var a in arr)
        {
            newArr[count] = Convert.ToInt32(a);
            count++;
        }
        return newArr;
    }

    public string TraverseInorder()
    {
        string output = "";
        output = bt.inorder(bt.root);
        return output;
    }

    public string TraversePreorder()
    {
        string output = "";
        output = bt.preorder(bt.root);
        return output;
    }

    public string TraversePostorder()
    {
        string output = "";
        output = bt.postorder(bt.root);
        return output;
    }
}
