using System;
using System.IO;

namespace STLBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Build a Mesh");
            Console.WriteLine("How Big Should It Be?");
            var lineWidth = Console.ReadLine();
            var width = Int32.Parse(lineWidth);
            var halfWidth = width / 2;

            var mesh = MeshBuilder.Create()
                .Name("Box")
                // Top
                .WithFacet(new Vertex() { Y = 1 }, new Vertex(halfWidth, halfWidth, halfWidth), new Vertex(halfWidth, halfWidth, -halfWidth), new Vertex(-halfWidth, halfWidth, -halfWidth))
                .WithFacet(new Vertex() { Y = 1 }, new Vertex(halfWidth, halfWidth, halfWidth), new Vertex(-halfWidth, halfWidth, halfWidth), new Vertex(-halfWidth, halfWidth, -halfWidth))
                // Bottom
                .WithFacet(new Vertex() { Y = -1 }, new Vertex(halfWidth, -halfWidth, halfWidth), new Vertex(halfWidth, -halfWidth, -halfWidth), new Vertex(-halfWidth, -halfWidth, -halfWidth))
                .WithFacet(new Vertex() { Y = -1 }, new Vertex(halfWidth, -halfWidth, halfWidth), new Vertex(-halfWidth, -halfWidth, halfWidth), new Vertex(-halfWidth, -halfWidth, -halfWidth))
                // Left
                .WithFacet(new Vertex() { X = 1 }, new Vertex(halfWidth, halfWidth, halfWidth), new Vertex(halfWidth, halfWidth, -halfWidth), new Vertex(halfWidth, -halfWidth, -halfWidth))
                .WithFacet(new Vertex() { X = 1 }, new Vertex(halfWidth, halfWidth, halfWidth), new Vertex(halfWidth, -halfWidth, halfWidth), new Vertex(halfWidth, -halfWidth, -halfWidth))
                 // Right
                .WithFacet(new Vertex() { X = -1 }, new Vertex(-halfWidth, halfWidth, halfWidth), new Vertex(-halfWidth, halfWidth, -halfWidth), new Vertex(-halfWidth, -halfWidth, -halfWidth))
                .WithFacet(new Vertex() { X = -1 }, new Vertex(-halfWidth, halfWidth, halfWidth), new Vertex(-halfWidth, -halfWidth, halfWidth), new Vertex(-halfWidth, -halfWidth, -halfWidth))
                // Forward
                .WithFacet(new Vertex() { Z = 1 }, new Vertex(halfWidth, halfWidth, halfWidth), new Vertex(halfWidth, -halfWidth, halfWidth), new Vertex(-halfWidth, -halfWidth, halfWidth))
                .WithFacet(new Vertex() { Z = 1 }, new Vertex(halfWidth, halfWidth, halfWidth), new Vertex(-halfWidth, halfWidth, halfWidth), new Vertex(-halfWidth, -halfWidth, halfWidth))
                // Back
                .WithFacet(new Vertex() { Z = -1 }, new Vertex(halfWidth, halfWidth, -halfWidth), new Vertex(halfWidth, -halfWidth, -halfWidth), new Vertex(-halfWidth, -halfWidth, -halfWidth))
                .WithFacet(new Vertex() { Z = -1 }, new Vertex(halfWidth, halfWidth, -halfWidth), new Vertex(-halfWidth, halfWidth, -halfWidth), new Vertex(-halfWidth, -halfWidth, -halfWidth))
                .Build();

            File.WriteAllText("generated.stl", StlBuilder.Build(mesh));
        }
    }
}