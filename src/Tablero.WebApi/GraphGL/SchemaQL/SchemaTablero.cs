using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.GraphGL.Queries;

namespace Tablero.WebApi.GraphGL.SchemaQL
{
    public class SchemaTablero : Schema
    {
        public SchemaTablero(IDependencyResolver resolver): base(resolver)
        {
            this.Query = resolver.Resolve<Query>();
        }
    }
}
