using System;
using System.Collections.Generic;
using System.IO;

namespace SeaObjectApp
{
    public class GraphReader
    {
        public void ReadGraph(string path, out string[] uniqueNodes, out string[][] adjacencyList)
        {
            string[] lines = File.ReadAllLines(path);

            List<string> fromList = new List<string>();
            List<string> toList = new List<string>();
            List<string> nodes = new List<string>();

            foreach (string line in lines)
            {
                int index = line.IndexOf("--|>");
                if (index != -1)
                {
                    string from = line.Substring(0, index).Trim();
                    string to = line.Substring(index + 4).Trim();

                    fromList.Add(from);
                    toList.Add(to);

                    if (!nodes.Contains(from)) nodes.Add(from);
                    if (!nodes.Contains(to)) nodes.Add(to);
                }
            }

            uniqueNodes = nodes.ToArray();
            adjacencyList = new string[uniqueNodes.Length][];

            for (int i = 0; i < uniqueNodes.Length; i++)
            {
                string currentNode = uniqueNodes[i];
                List<string> neighbors = new List<string>();

                for (int j = 0; j < fromList.Count; j++)
                {
                    if (fromList[j] == currentNode)
                    {
                        neighbors.Add(toList[j]);
                    }
                }

                adjacencyList[i] = neighbors.ToArray();
            }
        }
    }
}