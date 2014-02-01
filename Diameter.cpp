// MaximumDiameter.cpp : Defines the entry point for the console application.
//
// Also contains code for prime numbers

#include "stdafx.h"
#include <iostream>

using namespace std;

typedef struct Node
{
    int data;
    Node* left;
    Node* right;
} Node;

Node* newNode(int value)
{
    Node* node = new Node();
    node->data = value;
    node->left = NULL;
    node->right = NULL;

    return node;
}

int height(Node* root)
{
    if (root == NULL)
    {
        return 0;
    }

    return 1 + max(height(root->left), height(root->right));
}

int diameter (Node* root)
{
    if (root == NULL)
    {
        return 0;
    }

    int leftHeight = height(root->left);
    int rightHeight = height(root->right);

    int leftDiameter = diameter(root->left);
    int rightDiameter = diameter(root->right);

    return max(1 + leftHeight + rightHeight, max(leftDiameter, rightDiameter));
}

int max(int a, int b)
{
    return a >= b ? a : b;
}


int _tmain(int argc, _TCHAR* argv[])
{
  Node *root =        newNode(1);
  root->left        = newNode(2);
  root->right       = newNode(3);
  root->left->left  = newNode(4);
  root->left->right = newNode(5);
 
  cout << "Diameter of the given binary tree is " << diameter(root) << endl;
 
  return 0;
}
