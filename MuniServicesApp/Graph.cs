using System;
using System.Collections.Generic;
using System.Linq;

namespace MuniServicesApp.DataStructures
{
    public class Graph<T>
    {
        private Dictionary<T, List<GraphEdge<T>>> adjacencyList;
        private bool isDirected;

        public int VertexCount => adjacencyList.Count;

        public Graph(bool directed = true)
        {
            adjacencyList = new Dictionary<T, List<GraphEdge<T>>>();
            isDirected = directed;
        }

        public void AddVertex(T vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new List<GraphEdge<T>>();
            }
        }

        public void AddEdge(T source, T destination, double weight = 1.0)
        {
            AddVertex(source);
            AddVertex(destination);

            adjacencyList[source].Add(new GraphEdge<T>(destination, weight));

            if (!isDirected)
            {
                adjacencyList[destination].Add(new GraphEdge<T>(source, weight));
            }
        }

        public List<T> GetNeighbors(T vertex)
        {
            if (adjacencyList.ContainsKey(vertex))
            {
                return adjacencyList[vertex].Select(e => e.Destination).ToList();
            }
            return new List<T>();
        }

        public List<GraphEdge<T>> GetEdges(T vertex)
        {
            if (adjacencyList.ContainsKey(vertex))
            {
                return new List<GraphEdge<T>>(adjacencyList[vertex]);
            }
            return new List<GraphEdge<T>>();
        }

        public List<T> BreadthFirstSearch(T start)
        {
            List<T> visited = new List<T>();
            Queue<T> queue = new Queue<T>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                T current = queue.Dequeue();

                foreach (var edge in adjacencyList[current])
                {
                    if (!visited.Contains(edge.Destination))
                    {
                        visited.Add(edge.Destination);
                        queue.Enqueue(edge.Destination);
                    }
                }
            }

            return visited;
        }

        public List<T> DepthFirstSearch(T start)
        {
            List<T> visited = new List<T>();
            DFSRecursive(start, visited);
            return visited;
        }

        private void DFSRecursive(T vertex, List<T> visited)
        {
            visited.Add(vertex);

            if (adjacencyList.ContainsKey(vertex))
            {
                foreach (var edge in adjacencyList[vertex])
                {
                    if (!visited.Contains(edge.Destination))
                    {
                        DFSRecursive(edge.Destination, visited);
                    }
                }
            }
        }

        public List<T> TopologicalSort()
        {
            Dictionary<T, int> inDegree = new Dictionary<T, int>();
            foreach (var vertex in adjacencyList.Keys)
            {
                inDegree[vertex] = 0;
            }

            foreach (var vertex in adjacencyList.Keys)
            {
                foreach (var edge in adjacencyList[vertex])
                {
                    inDegree[edge.Destination]++;
                }
            }

            Queue<T> queue = new Queue<T>();
            foreach (var vertex in inDegree.Keys)
            {
                if (inDegree[vertex] == 0)
                {
                    queue.Enqueue(vertex);
                }
            }

            List<T> result = new List<T>();
            while (queue.Count > 0)
            {
                T current = queue.Dequeue();
                result.Add(current);

                foreach (var edge in adjacencyList[current])
                {
                    inDegree[edge.Destination]--;
                    if (inDegree[edge.Destination] == 0)
                    {
                        queue.Enqueue(edge.Destination);
                    }
                }
            }

            return result;
        }

        public List<GraphEdge<T>> MinimumSpanningTree()
        {
            if (adjacencyList.Count == 0)
            {
                return new List<GraphEdge<T>>();
            }

            List<GraphEdge<T>> mst = new List<GraphEdge<T>>();
            HashSet<T> visited = new HashSet<T>();
            MinHeap<MSTEdge<T>> edgeHeap = new MinHeap<MSTEdge<T>>();

            T start = adjacencyList.Keys.First();
            visited.Add(start);

            foreach (var edge in adjacencyList[start])
            {
                edgeHeap.Insert(new MSTEdge<T>(start, edge.Destination, edge.Weight));
            }

            while (edgeHeap.Count > 0 && visited.Count < adjacencyList.Count)
            {
                MSTEdge<T> minEdge = edgeHeap.ExtractMin();

                if (visited.Contains(minEdge.Destination))
                {
                    continue;
                }

                visited.Add(minEdge.Destination);
                mst.Add(new GraphEdge<T>(minEdge.Destination, minEdge.Weight));

                foreach (var edge in adjacencyList[minEdge.Destination])
                {
                    if (!visited.Contains(edge.Destination))
                    {
                        edgeHeap.Insert(new MSTEdge<T>(minEdge.Destination, edge.Destination, edge.Weight));
                    }
                }
            }

            return mst;
        }

        public Dictionary<T, double> DijkstraShortestPath(T start)
        {
            Dictionary<T, double> distances = new Dictionary<T, double>();
            HashSet<T> visited = new HashSet<T>();
            MinHeap<DijkstraNode<T>> priorityQueue = new MinHeap<DijkstraNode<T>>();

            foreach (var vertex in adjacencyList.Keys)
            {
                distances[vertex] = double.MaxValue;
            }
            distances[start] = 0;

            priorityQueue.Insert(new DijkstraNode<T>(start, 0));

            while (priorityQueue.Count > 0)
            {
                DijkstraNode<T> current = priorityQueue.ExtractMin();

                if (visited.Contains(current.Vertex))
                {
                    continue;
                }

                visited.Add(current.Vertex);

                foreach (var edge in adjacencyList[current.Vertex])
                {
                    double newDistance = distances[current.Vertex] + edge.Weight;
                    if (newDistance < distances[edge.Destination])
                    {
                        distances[edge.Destination] = newDistance;
                        priorityQueue.Insert(new DijkstraNode<T>(edge.Destination, newDistance));
                    }
                }
            }

            return distances;
        }

        public List<T> GetAllVertices()
        {
            return new List<T>(adjacencyList.Keys);
        }

        public void Clear()
        {
            adjacencyList.Clear();
        }
    }

    public class GraphEdge<T>
    {
        public T Destination { get; set; }
        public double Weight { get; set; }

        public GraphEdge(T destination, double weight)
        {
            Destination = destination;
            Weight = weight;
        }
    }

    internal class MSTEdge<T> : IComparable<MSTEdge<T>>
    {
        public T Source { get; set; }
        public T Destination { get; set; }
        public double Weight { get; set; }

        public MSTEdge(T source, T destination, double weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }

        public int CompareTo(MSTEdge<T> other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    internal class DijkstraNode<T> : IComparable<DijkstraNode<T>>
    {
        public T Vertex { get; set; }
        public double Distance { get; set; }

        public DijkstraNode(T vertex, double distance)
        {
            Vertex = vertex;
            Distance = distance;
        }

        public int CompareTo(DijkstraNode<T> other)
        {
            return Distance.CompareTo(other.Distance);
        }
    }
}
