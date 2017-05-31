using System;
using System.Collections.Generic;
using System.Text;

namespace STLBuilder
{
    public class Mesh
    {
        public string Name { get; private set; }
        public IEnumerable<Facet> Facets { get; private set; }

        public Mesh(string name, IEnumerable<Facet> facets)
        {
            this.Name = name;
            this.Facets = new List<Facet>(facets);
        }
    }
}
