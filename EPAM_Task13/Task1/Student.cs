using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task13.Task1
{
    class DataProcess
    {
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"students.txt");

        public void WriteStudentToFile(List<Node> nodes)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Node s in nodes)
                {
                    writer.Write(s.id);
                    writer.Write(s.name);
                    writer.Write(s.testName);
                    writer.Write(s.testDate);
                    writer.Write(s.testMark);
                }
            }
        }

        public Tree ReadStudentsFromFile()
        {
            Tree treeStudents = new Tree();

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    Node student = new Node();

                    student.id = reader.ReadInt32();
                    student.name = reader.ReadString();
                    student.testName = reader.ReadString();
                    student.testDate = reader.ReadString();
                    student.testMark = reader.ReadString();

                    treeStudents.nodes.Add(student);
                }
            }
            return treeStudents;
        }
    }

    class Node
    {
        public int id;
        public string name;
        public string testName;
        public string testDate;
        public string testMark;

        public Node left;
        public Node right;
    }

    class Tree
    {
        public List<Node> nodes = new List<Node>();

        public Node Insert(Node root, int id, string name, string testName, string testDate, string testMark)
        {
            if (root != null && !nodes.Contains(root))
            {
                nodes.Add(root);
            }

            if (root == null)
            {
                root = new Node();
                root.id = id;
                root.name = name;
                root.testName = testName;
                root.testDate = testDate;
                root.testMark = testMark;
            }
            else if (id < root.id)
            {
                root.left = Insert(root.left, id, name, testName, testDate, testMark);

                if (root != null && !nodes.Contains(root.left))
                {
                    nodes.Add(root.left);
                }
            }
            else
            {
                root.right = Insert(root.right, id, name, testName, testDate, testMark);

                if (root != null && !nodes.Contains(root.right))
                {
                    nodes.Add(root.right);
                }
            }

            return root;
        }

        public Node Find(Node root, int id)
        {
            if (root != null)
            {
                if (id == root.id) return root;

                if (id < root.id)
                    return Find(root.left, id);
                else
                    return Find(root.right, id);
            }
            return null;
        }
    }



}
