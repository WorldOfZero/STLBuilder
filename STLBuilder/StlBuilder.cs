using System;
using System.Collections.Generic;
using System.Text;

namespace STLBuilder
{
    public static class StlBuilder
    {
        public static string Build(Mesh mesh)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"solid {mesh.Name}");

            foreach (var facet in mesh.Facets)
            {
                builder.AppendLine($"facet normal {facet.Normal.X} {facet.Normal.Y} {facet.Normal.Z}");
                builder.AppendLine($"  outer loop");
                foreach (var vertex in facet.Vertices)
                {
                    builder.AppendLine($"    vertex {vertex.X} {vertex.Y} {vertex.Z}");
                }
                builder.AppendLine($"  endloop");
                builder.AppendLine($"endfacet");
            }

            builder.AppendLine($"endsolid {mesh.Name}");
            return builder.ToString();
        }
    }
}
